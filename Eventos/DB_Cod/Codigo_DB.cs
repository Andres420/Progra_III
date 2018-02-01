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
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO estudiantes VALUES(" + cedula + ",'" + nombre + "','" + fecha_naci + "','" + residencia + "');",conn);
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

        public List<int> Buscar_Estudiantes()
        {
            List<int> lista_estudiantes = new List<int>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432; User Id=postgres;Password=Admin;Database = prueba");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT cedula FROM estudiantes;",conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                        lista_estudiantes.Add(int.Parse(dr["cedula"].ToString())); ;
                    conn.Close();
                    return lista_estudiantes;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se despicho\n" + ex);
                conn.Close();
                return null;
            }
        }

        public object[] Buscar_Estudiantes(int cedula)
        {
            object[] estudiante = null;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432; User Id=postgres;Password=Admin;Database = prueba");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT cedula,nombre,fecha_naci,residencia FROM estudiantes WHERE cedula = " + cedula + ";", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    estudiante = new[]
                    {
                            (object)dr["cedula"],
                            (object)dr["nombre"],
                            (object)dr["fecha_naci"],
                            (object)dr["residencia"]
                        };
                    conn.Close();
                    return estudiante;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se despicho\n" + ex);
                conn.Close();
                return null;
            }
        }
    }
}
