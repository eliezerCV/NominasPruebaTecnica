

public class ReportesServicio {

  private readonly IConfiguration _configuration;
  private readonly EmpleadoServicio _empleadoServicio;
  public ReportesServicio(IConfiguration configuration, EmpleadoServicio empleadoServicio) {
    _configuration = configuration;
    _empleadoServicio = empleadoServicio;
  }

  public Reporte GenerarReporte(int Numero) {
    var reporte = new Reporte();
    var empleado = _empleadoServicio.ObtenerEmpleado(Numero);

    reporte.Nombre = empleado.Nombre;
    reporte.NumeroEmpleado = empleado.Numero;
    // reporte.Rol = empleado.RolID;

    var connectionString = _configuration.GetConnectionString("DefaultConnection");


    return reporte;
  }
}