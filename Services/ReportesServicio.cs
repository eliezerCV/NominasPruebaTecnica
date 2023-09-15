

public class ReportesServicio {

  private readonly IConfiguration _configuration;
  private readonly EmpleadoServicio _empleadoServicio;

  private int HorasLaborales = 8;
  private decimal SueldoBaseHora = 30;
  private decimal BonoPorEntrega = 5;
  private decimal PorcentajeValeDespensa = 0.04m;
  private int SemanasPorMes = 4;
  private int DiasLabolaresPorSemana = 6;
  private decimal PorcentajeISR = 0.09m;
  private decimal PorcentajeISRAdicional = 0.3m;
  private decimal MaximoSueloParaISR = 10000;

  public ReportesServicio(IConfiguration configuration, EmpleadoServicio empleadoServicio) {
    _configuration = configuration;
    _empleadoServicio = empleadoServicio;
  }

  public Reporte GenerarReporte(int Numero) {
    var reporte = new Reporte();

    var empleado = _empleadoServicio.ObtenerEmpleadoPorNumero(Numero);

    if (empleado == null) {
      return reporte;
    }
    reporte.NumeroEmpleado = empleado.Numero;
    reporte.NombreEmpleado = empleado.Nombre;
    
    if (empleado.Rol != null)  {
      reporte.BonoPorHora = empleado.Rol.BonoPorHora;
      reporte.RolEmpleado = empleado.Rol.Nombre;
    } else {
      reporte.BonoPorHora = 0;
      reporte.RolEmpleado = "Sin Rol";
    }
    int HorasTrabajadas = HorasLaborales * DiasLabolaresPorSemana * SemanasPorMes;
    reporte.HorasTrabajadas = HorasTrabajadas;
    reporte.CantidadEntregas = 0;
    reporte.BonoPorEntrega = BonoPorEntrega * reporte.CantidadEntregas;
    reporte.SueldoBruto = HorasTrabajadas * (SueldoBaseHora + reporte.BonoPorHora)/* + reporte.CantidadEntregas * BonoPorEntrega*/;
    reporte.ValeDespensa = reporte.SueldoBruto * PorcentajeValeDespensa;
    decimal porcentajeISRGravable = CalcularISRPorcentaje(reporte.SueldoBruto);
    reporte.ISRPorcentaje = porcentajeISRGravable;
    reporte.ISRAplicable = reporte.SueldoBruto * porcentajeISRGravable;
    reporte.SueldoNeto = reporte.SueldoBruto - reporte.ISRAplicable + reporte.ValeDespensa;

    return reporte;
  }

  private decimal CalcularISRPorcentaje(decimal sueldoBruto) {
    return (sueldoBruto > MaximoSueloParaISR) ? PorcentajeISR+PorcentajeISRAdicional : PorcentajeISR;
  }
}