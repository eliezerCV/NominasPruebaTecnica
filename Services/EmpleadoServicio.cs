

public class EmpleadoServicio {

  private readonly IConfiguration _configuration;

  public EmpleadoServicio(IConfiguration configuration) {
    _configuration = configuration;
  }


  public string ObtenerEmpleados() {
    
    return "Respuesta desde el servicio";
  }
}