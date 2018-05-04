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
 
    public partial class CLI_TIPO : Form
    {
        private static CLI_TIPO _instancia;
        public static CLI_TIPO ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new CLI_TIPO();
            }
            _instancia.BringToFront();
            return _instancia;
        }
        public CLI_TIPO()
        {
            InitializeComponent();
        }

        private void CLI_TIPO_Load(object sender, EventArgs e)
        {
            CargarTipos();
        }
        private void CargarTipos()
        {
            Negocio.CLI_TIPO TIP = new Negocio.CLI_TIPO();
            dgvtipocliente.DataSource = TIP.Listar();

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            TIP_AGRE_MODIFICAR fm = new TIP_AGRE_MODIFICAR();
            fm.lbltitulo.Text = "Nuevo Tipo";
            fm.btngrabar.Text = "Grabar";
            if (fm.ShowDialog() == DialogResult.OK)
            {
                CargarTipos();
                MENSAJE_V2.Show("Grabado con exito", MENSAJE_V2.AlertType.success);
            }
          
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if(dgvtipocliente.SelectedRows.Count > 0)
            {
                TIP_AGRE_MODIFICAR fm = new TIP_AGRE_MODIFICAR();
                fm.lbltitulo.Text = "Modificar Modificar";
                fm.Codigo = Convert.ToInt32(dgvtipocliente.CurrentRow.Cells["Codigo"].Value);
                fm.txtnombre.Text = dgvtipocliente.CurrentRow.Cells["Nombre"].Value.ToString();
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    CargarTipos();
                    MENSAJE_V2.Show("Modificado con exito", MENSAJE_V2.AlertType.success);
                }
            }
            
        }

        private void dgvtipocliente_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvtipocliente.SelectedRows.Count > 0)
            {
                TIP_AGRE_MODIFICAR fm = new TIP_AGRE_MODIFICAR();
                fm.Text = "Modificar Modificar";
                fm.Codigo = Convert.ToInt32(dgvtipocliente.CurrentRow.Cells["Codigo"].Value);
                fm.txtnombre.Text = dgvtipocliente.CurrentRow.Cells["Nombre"].Value.ToString();
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    CargarTipos();
                    MENSAJE_V2.Show("Modificado con exito", MENSAJE_V2.AlertType.success);
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvtipocliente.SelectedRows.Count > 0)
            {
                Negocio.CLI_TIPO tip = new Negocio.CLI_TIPO();
                tip.Codigo = Convert.ToInt32(dgvtipocliente.CurrentRow.Cells["Codigo"].Value.ToString());
                if (tip.Eliminar() == true)
                {
                    CargarTipos();
                    MENSAJE_V2.Show("Tipo Eliminado", MENSAJE_V2.AlertType.success);
                }
                else
                {
                    MENSAJE_V2.Show("No se pudo eliminar", MENSAJE_V2.AlertType.error);
                }
            }
            else
            {
                MENSAJE_V2.Show("No hay Tipos", MENSAJE_V2.AlertType.info);
            }

        }
    }
}
