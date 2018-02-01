using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Cod
{
    public class Codigo_DB
    {

        public bool Insertar_Base_Datos(int cedula, string nombre, string fecha_naci, string residencia)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432; User Id=postgres;Password=Admin;Database = prueba");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO estudiantes VALUES(" + cedula + ",'" + nombre + "','" + fecha_naci + "','" + residencia + "',);");
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se despicho\n" + ex);
                conn.Close();
                return false;
            }
        }

        public List<object[]> Buscar_Estudiantes()
        {
            throw new NotImplementedException();
        }
    }
}
