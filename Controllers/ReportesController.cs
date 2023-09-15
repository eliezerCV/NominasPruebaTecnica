

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/reportes")]
public class ReportesController: ControllerBase {

  private readonly ReportesServicio _servicio;

  public ReportesController(ReportesServicio servicio) {
    _servicio = servicio;
  }

  [HttpGet("{NumeroEmpleado}")]
  public IActionResult Reporte(int NumeroEmpleado) {
    return Ok(_servicio.GenerarReporte(NumeroEmpleado));
  }
}
