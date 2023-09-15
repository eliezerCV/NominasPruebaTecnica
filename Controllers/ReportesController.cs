

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/reportes")]
public class ReportesController: ControllerBase {

  private readonly ReportesServicio _servicio;

  public ReportesController(ReportesServicio servicio) {
    _servicio = servicio;
  }

  [HttpGet("{Numero}")]
  public IActionResult Empleados(int Numero) {
    return Ok(_servicio.GenerarReporte(Numero));
  }
}
