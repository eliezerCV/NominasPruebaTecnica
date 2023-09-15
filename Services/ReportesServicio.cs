

public class ReportesServicio {

  private readonly IConfiguration _configuration;
  private readonly EmpleadoServicio _empleadoServicio;
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
    reporte.NumeroEmpleado = empleado.Numero;
    reporte.RolEmpleado = empleado.Rol.Nombre;

    reporte.HorasTrabajadas = 0;
    reporte.BonoPorHora = empleado.Rol.BonoPorHora;
    reporte.CantidadEntregas = 0;
    reporte.BonoPorEntrega = 0;
    reporte.ValeDespensa = 0;
    reporte.SueldoBruto = 0;
    reporte.ISRPorcentaje = 0;
    reporte.ISRAplicable = 0;
    reporte.SueldoNeto = 0;

    return reporte;
  }
}