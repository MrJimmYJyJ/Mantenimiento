using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class CLI_AGRE_MODIFICAR : Form
    {
        public Int64 CodigoCliente = 0;

        public CLI_AGRE_MODIFICAR()
        {
            InitializeComponent();
           
            ListarTipo();
            cbosexo.SelectedIndex = 0;
            txthistoria.Focus();
        }

        private void CLI_AGRE_MODIFICAR_Load(object sender, EventArgs e)
        {
          
        }
        private void ListarTipo()
        {
            Negocio.CLI_TIPO tipo = new Negocio.CLI_TIPO();
            cbotipo.DataSource = tipo.Listar();
        }
        private void btngrabar_Click(object sender, EventArgs e)
        {

            Negocio.CLI_CLIENTE cliente = new Negocio.CLI_CLIENTE();

            cliente.NumHistoria = txthistoria.Text.Trim();
            cliente.Dni = txtdni.Text.Trim();
            cliente.Paterno = txtpaterno.Text.Trim();
            cliente.Materno = txtmaterno.Text.Trim();
            cliente.Nombre = txtnombres.Text.Trim();
            cliente.Direccion = txtdireccion.Text.Trim();
            cliente.Telefono = txttelefono.Text.Trim();
            cliente.Celular = txtcelular.Text.Trim();
            cliente.FechaNaci = Convert.ToDateTime(dtfechanacimiento.Text);
            cliente.Sexo = cbosexo.Text.Substring(0,1);
            cliente.Correo = txtcorreo.Text.Trim();
            cliente.Estado = true;
            cliente.Codtip = new Entidad.CLI_TIPO() { Codigo = Convert.ToInt32(cbotipo.SelectedValue) };
            if (CodigoCliente == 0)
            {
                if (cliente.Agregar() == true)
                    {
                       DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MENSAJE_V2.Show("No se pudo grabar", MENSAJE_V2.AlertType.error);
                    }
            }
            else
            {
                cliente.Codigo = CodigoCliente;
                if (cliente.Modificar() == true)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MENSAJE_V2.Show("No se pudo modificar", MENSAJE_V2.AlertType.error);
                }
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
