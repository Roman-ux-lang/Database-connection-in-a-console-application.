using Microsoft.Data.SqlClient;
using Domain;

namespace Infrastructure;

public class EmpleadosDbContext
{
    private readonly string _connectionString;

    public EmpleadosDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Empleado> List()
    {
        var data = new List<Empleado>();

        var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("SELECT [Id],[Nombre],[Edad] FROM [Empleados]", con);
        try
        {
            con.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                data.Add(new Empleado
                {
                    Id = (Guid)dr["Id"],
                    Nombre = (string)dr["Nombre"],
                    Edad = (byte)dr["Edad"]
                });
            }
            return data;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }

    public Empleado Details(Guid id)
    {
        var data = new Empleado();

        var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("SELECT [Id],[Nombre],[Edad] FROM [Empleados] WHERE [Id] = @id", con);
        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
        try
        {
            con.Open();
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                data.Id = (Guid)dr["Id"];
                data.Nombre = (string)dr["Nombre"];
                data.Edad = (byte)dr["Edad"];
            }
            return data;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }

    public void Create(Empleado data)
    {
        var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("INSERT INTO [Empleados] ([Id],[Nombre],[Edad]) VALUES (@id,@nombre,@edad)", con);
        cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = data.Id;
        cmd.Parameters.Add("nombre", SqlDbType.NVarChar, 128).Value = data.Nombre;
        cmd.Parameters.Add("edad", SqlDbType.Int).Value = data.Edad;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }

    public void Edit(Empleado data)
    {
        var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("UPDATE [Empleados] SET [Nombre] = @nombre, [Edad] = @edad WHERE [Id] = @id", con);
        cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = data.Id;
        cmd.Parameters.Add("nombre", SqlDbType.NVarChar, 128).Value = data.Nombre;
        cmd.Parameters.Add("edad", SqlDbType.Int).Value = data.Edad;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }

    public void Delete(Guid id)
    {
        var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("DELETE FROM [Empleados] WHERE [Id] = @id", con);
        cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }
}