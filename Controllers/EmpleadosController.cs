

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

  [HttpPost]
  public IActionResult CrearEmpleado([FromBody] Empleado empleado) {
    return Ok(_servicio.CrearEmpleado(empleado));
  }

  [HttpPut("{Numero}")]
  public IActionResult ModificarEmpleado([FromBody] Empleado empleado, int Numero) {
    return Ok(_servicio.ModificarEmpleado(empleado, Numero));
  }
}