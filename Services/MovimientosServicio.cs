

using System.Data;
using System.Data.SqlClient;

public class MovimientosServicio {

  private readonly IConfiguration _configuration;

  public MovimientosServicio(IConfiguration configuration) {
    _configuration = configuration;
  }

  public bool GuardarMovimiento(Movimiento movimiento) {
    try {
      using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) {
        connection.Open();
        var command = new SqlCommand("sp_InsertarMovimiento", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@NumeroEmpleado", movimiento.NumeroEmpleado);
        command.Parameters.AddWithValue("@CantidadEnvios", movimiento.CantidadEnvios);
        command.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
        command.ExecuteNonQuery();
        return true;
      }
    } 
    catch (System.Exception) {
      throw;
    }
  }

  public int ObtenerTotalEnvios(int numeroEmpleado, DateTime fechaInicio, DateTime fechaFin) {
    try {
      using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) {
        connection.Open();
        var command = new SqlCommand("sp_TotalEnviosPorEmpleado", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@NumeroEmpleado", numeroEmpleado);
        command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
        command.Parameters.AddWithValue("@FechaFin", fechaFin);
        var reader = command.ExecuteReader();
        if (reader.Read()) {
          return reader.GetInt32(0);
        }
        return 0;
      }
    } 
    catch (System.Exception) {
      throw;
    }
  }
}