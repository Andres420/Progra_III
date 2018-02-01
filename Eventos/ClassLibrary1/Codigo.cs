using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Cod;
using System.Windows;
using System.Windows.Forms;

namespace Cod_Negocio
{
    public class Codigo
    {
        public bool Insertar_Estudiante(int cedula, string nombre, string fecha_naci, string residencia)
        {
            Codigo_DB cod_db = new Codigo_DB();
            DateTime dt = Convert.ToDateTime(fecha_naci);
            string dateString = dt.ToString("yyyyMMdd");
            return cod_db.Insertar_Base_Datos(cedula,nombre,dateString,residencia);
        }

        public void Modificar_Combo(System.Windows.Forms.ComboBox cbEstudiantes)
        {
            Codigo_DB cod_db = new Codigo_DB();
            List<int> lista_estudiante = cod_db.Buscar_Estudiantes();
            int i = 0;
            cbEstudiantes.Items.Clear();
            cbEstudiantes.Items.Add("(Seleccione)");
            while (i < lista_estudiante.Count())
            {
                cbEstudiantes.Items.Add(lista_estudiante.ElementAt(i));
                i++;
            }
            cbEstudiantes.SelectedIndex = 0;
        }

        public void Ver_Informacion_Est(TextBox txtCedulaCon, TextBox txtNombreCon, DateTimePicker dtpFechaNaciCon, TextBox txtResidenciaCon, ComboBox cbEstudiantes, int cedula)
        {
            Codigo_DB cod_db = new Codigo_DB();
            object[] estudiante = cod_db.Buscar_Estudiantes(cedula);
            txtCedulaCon.Text = (int)estudiante[0]+"";
            txtNombreCon.Text = (string)estudiante[1];
            dtpFechaNaciCon.Text = estudiante[2].ToString();
            txtResidenciaCon.Text = (string)estudiante[3];
        }
    }
}
