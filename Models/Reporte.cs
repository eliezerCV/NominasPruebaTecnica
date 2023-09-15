

public class Reporte {
  public int NumeroEmpleado { get; set; }
  public string NombreEmpleado { get; set; } = string.Empty;
  public string RolEmpleado { get; set; } = string.Empty;
  public int HorasTrabajadas { get; set; }
  public decimal BonoPorHora { get; set; }
  public int CantidadEntregas { get; set; }
  public decimal BonoPorEntrega { get; set; }
  public decimal ValeDespensa { get; set; }
  public decimal SueldoBruto { get; set; }
  public decimal ISRPorcentaje { get; set; }
  public decimal ISRAplicable { get; set; }
  public decimal SueldoNeto { get; set; }
}