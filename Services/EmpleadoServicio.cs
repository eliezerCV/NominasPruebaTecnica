// using para SqlConnection, SqlCommand, SqlDataReader 
using System.Data;
using System.Data.SqlClient;


public class EmpleadoServicio {

  private readonly IConfiguration _configuration;

  private decimal SueldoBaseHora = 30;

  public EmpleadoServicio(IConfiguration configuration) {
    _configuration = configuration;
  }

  public Empleado ObtenerEmpleadoPorNumero(int Numero) {
    var empleado = new Empleado();

    try {
      using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) {
        connection.Open();
        var command = new SqlCommand("sp_ObtenerEmpleadoYRolPorNumero", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@NumeroEmpleado", Numero);
        var dataReader = command.ExecuteReader();

        if (dataReader.Read()) {
          empleado.Numero = Convert.ToInt32(dataReader["Numero"]);
          empleado.Nombre = Convert.ToString(dataReader["EmpleadoNombre"]) ?? string.Empty;
          empleado.RolID = Convert.ToInt32(dataReader["RolID"]);
          empleado.SueldoBaseHora = Convert.ToDecimal(dataReader["SueldoBaseHora"]);
          empleado.Rol = new Rol() {
            ID = Convert.ToInt32(dataReader["IDRol"]),
            Nombre = Convert.ToString(dataReader["RolNombre"]) ?? string.Empty,
            BonoPorHora = Convert.ToDecimal(dataReader["BonoPorHora"])
          };
        }

        return empleado;
      }
      
    } 
    catch (System.Exception) {
      throw;
    }
  }

  public List<Empleado> ObtenerEmpleados() {
    var empleados = new List<Empleado>();

    try {
      using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) {
        connection.Open();
        var command = new SqlCommand("sp_GetAllEmpleados", connection);
        command.CommandType = CommandType.StoredProcedure;
        var dataReader = command.ExecuteReader();

        while (dataReader.Read()) {
          var empleado = new Empleado();
          empleado.Numero = Convert.ToInt32(dataReader["Numero"]);
          empleado.Nombre = Convert.ToString(dataReader["Nombre"]) ?? string.Empty;
          empleado.RolID = Convert.ToInt32(dataReader["RolID"]);
          empleado.SueldoBaseHora = Convert.ToDecimal(dataReader["SueldoBaseHora"]);
          empleados.Add(empleado);
        }

        return empleados;
      }
      
    } 
    catch (System.Exception) {
      throw;
    }
  }

  public bool CrearEmpleado(Empleado empleado) {
    try {
      using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) {
        connection.Open();
        var command = new SqlCommand("sp_CrearEmpleado", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
        command.Parameters.AddWithValue("@RolID", empleado.RolID);
        command.Parameters.AddWithValue("@SueldoBaseHora", SueldoBaseHora);
        command.ExecuteNonQuery();
        return true;
      }
    } 
    catch (System.Exception) {
      throw;
    }
  }

  public bool ModificarEmpleado(Empleado empleado, int Numero) {
    try {
      using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) {
        connection.Open();
        var command = new SqlCommand("sp_ModificarEmpleado", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Numero", Numero);
        command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
        command.Parameters.AddWithValue("@RolID", empleado.RolID);
        command.Parameters.AddWithValue("@SueldoBaseHora", empleado.SueldoBaseHora);
        command.ExecuteNonQuery();
        return true;
      }
    } 
    catch (System.Exception) {
      throw;
    }
  }
}