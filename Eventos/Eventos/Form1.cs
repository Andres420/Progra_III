using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cod_Negocio;

namespace Eventos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!txtCedula.Text.Equals("") && !txtNombre.Text.Equals("") && !txtResidencia.Text.Equals(""))
            {
                try
                {
                    Codigo cod = new Codigo();
                    bool agregado = cod.Insertar_Estudiante(int.Parse(txtCedula.Text), txtNombre.Text, dtpFechaNaci.Text, txtResidencia.Text);
                }
                catch (Exception)
                {
                    Console.WriteLine("Se despicho");
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Codigo cod = new Codigo();
            cod.Modificar_Combo(cbEstudiantes);
        }

        private void cbEstudiantes_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
