

using Microsoft.AspNetCore.Mvc;

[Route("api/empleados")]
public class EmpleadosController : Controller {
  
  public IActionResult Index() {
    return Ok("Este es el index de Empleados");
  }
}