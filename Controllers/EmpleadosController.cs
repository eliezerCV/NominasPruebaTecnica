

using Microsoft.AspNetCore.Mvc;

[Route("api/empleados")]
public class EmpleadosController : Controller {

  private readonly EmpleadoServicio _servicio;

  public EmpleadosController(EmpleadoServicio servicio)
  {
    _servicio = servicio;
    
  }

  public IActionResult Index() {
    return Ok(_servicio.ObtenerEmpleados());
  }
}