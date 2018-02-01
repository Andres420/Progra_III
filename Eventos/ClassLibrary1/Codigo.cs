using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Cod;
namespace Cod_Negocio
{
    public class Codigo
    {
        public bool Insertar_Estudiante(int cedula, string nombre, string fecha_naci, string residencia)
        {
            Codigo_DB cod_db = new Codigo_DB();
            return cod_db.Insertar_Base_Datos(cedula,nombre,fecha_naci,residencia);
        }

        public void Modificar_Combo(object cbEstudiantes)
        {
            Codigo_DB cod_db = new Codigo_DB();
            List<object[]> lista_estudiante = cod_db.Buscar_Estudiantes();
            throw new NotImplementedException();
        }
    }
}
