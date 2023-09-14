// using para SqlConnection, SqlCommand, SqlDataReader 
using System.Data;
using System.Data.SqlClient;


public class EmpleadoServicio {

  private readonly IConfiguration _configuration;

  public EmpleadoServicio(IConfiguration configuration) {
    _configuration = configuration;
  }


  public List<Empleado> ObtenerEmpleados() {
    var empleados = new List<Empleado>();

    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) {
      connection.Open();
      var command = new SqlCommand("sp_GetAllEmpleados", connection);
      command.CommandType = CommandType.StoredProcedure;
      var dataReader = command.ExecuteReader();

      while (dataReader.Read()) {
        var empleado = new Empleado();
        empleado.Numero = Convert.ToInt32(dataReader["Numero"]);
        empleado.Nombre = Convert.ToString(dataReader["Nombre"]);
        empleado.RolID = Convert.ToInt32(dataReader["RolID"]);
        empleado.SueldoBaseHora = Convert.ToDecimal(dataReader["SueldoBaseHora"]);
        empleados.Add(empleado);
      }
    }
    return empleados;
  }
}