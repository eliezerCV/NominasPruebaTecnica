

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/movimientos")]
public class MovimientosController: ControllerBase {
  
    private readonly MovimientosServicio _servicio;
  
    public MovimientosController(MovimientosServicio servicio) {
      _servicio = servicio;
    }
  
    [HttpPost]
    public IActionResult GuardarMovimiento(Movimiento movimiento) {
      return Ok(_servicio.GuardarMovimiento(movimiento));
    }
}