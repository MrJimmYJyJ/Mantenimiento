using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class CLIENTE : Form
    {
        private Int64 CodigoCliente = 0;

        private static CLIENTE _instancia;
        public static CLIENTE ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new CLIENTE();
            }
            _instancia.BringToFront();
            return _instancia;
        }
        public CLIENTE()
        {
            InitializeComponent();
        }
        private void CLIENTE_Load(object sender, EventArgs e)
        {
           
            ListarClientes();
          
        }
        private void ListarClientes()
        {
            Negocio.CLI_CLIENTE objcli = new Negocio.CLI_CLIENTE();
            var Lista = from Cliente in objcli.Listar()
                        select new
                        {
                            Codigo = Cliente.Codigo,
                            Historia = Cliente.NumHistoria,
                            Dni = Cliente.Dni,
                            Cliente = Cliente.NombreCompleto,
                            Paterno = Cliente.Paterno,
                            Materno = Cliente.Materno,
                            Nombre = Cliente.Nombre,
                            Direccion = Cliente.Direccion,
                            Telefono = Cliente.Telefono,
                            Celular = Cliente.Celular,
                            Nacimiento = Cliente.FechaNaci,
                            Registro = Cliente.Fechareg,
                            Sexo = Cliente.Sexo,
                            Correo = Cliente.Correo,
                            Estado = Cliente.Estado,
                            CodTip = Cliente.Codtip.Codigo,
                            Tipo = Cliente.Codtip.Nombre,

                        };
            dgvcliente.DataSource = Lista.ToList();
            dgvcliente.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

          
           
            dgvcliente.Columns["Nacimiento"].Visible = false;
            dgvcliente.Columns["Codigo"].Visible = false;
            dgvcliente.Columns["Paterno"].Visible = false;
            dgvcliente.Columns["Materno"].Visible = false;
            dgvcliente.Columns["Nombre"].Visible = false;


            dgvcliente.Columns["CodTip"].Visible = false;
            dgvcliente.Columns["Tipo"].Visible = false;
            

            dgvcliente.Columns["Registro"].Visible = false;
            dgvcliente.Columns["Estado"].Visible = false;

            dgvcliente.Columns["Historia"].Width = 60;
            dgvcliente.Columns["Sexo"].Width = 50;
            dgvcliente.Columns["Dni"].Width = 70;
            dgvcliente.Columns["Telefono"].Width = 80;
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            CLI_AGRE_MODIFICAR fm = new CLI_AGRE_MODIFICAR();
            fm.lbltitulo.Text = "Nuevo Cliente";
            fm.btngrabar.Text = "Registrar";
            if(fm.ShowDialog() == DialogResult.OK)
            {
                ListarClientes();
                MENSAJE_V2.Show("Grabado con exito", MENSAJE_V2.AlertType.success);
            }
         
        }
        private void BuscarCliente()
        {
            Negocio.CLI_CLIENTE objcli = new Negocio.CLI_CLIENTE();
            var Lista = from Cliente in objcli.BuscarPorNombre(txtbuscar.Text.Trim())
                        select new
                        {
                            Codigo = Cliente.Codigo,
                            Historia = Cliente.NumHistoria,
                            Dni = Cliente.Dni,
                            Cliente = Cliente.NombreCompleto,
                            Paterno = Cliente.Paterno,
                            Materno = Cliente.Materno,
                            Nombre = Cliente.Nombre,
                            Direccion = Cliente.Direccion,
                            Telefono = Cliente.Telefono,
                            Celular = Cliente.Celular,
                            Nacimiento = Cliente.FechaNaci,
                            Registro = Cliente.Fechareg,
                            Sexo = Cliente.Sexo,
                            Correo = Cliente.Correo,
                            Estado = Cliente.Estado,
                            CodTip = Cliente.Codtip.Codigo,
                            Tipo = Cliente.Codtip.Nombre,
                        };


            dgvcliente.DataSource = Lista.ToList();
            dgvcliente.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvcliente.Columns["Nacimiento"].Visible = false;
            dgvcliente.Columns["Codigo"].Visible = false;
            dgvcliente.Columns["Paterno"].Visible = false;
            dgvcliente.Columns["Materno"].Visible = false;
            dgvcliente.Columns["Nombre"].Visible = false;


            dgvcliente.Columns["CodTip"].Visible = false;
            dgvcliente.Columns["Tipo"].Visible = false;
           
   

            dgvcliente.Columns["Registro"].Visible = false;
            dgvcliente.Columns["Estado"].Visible = false;

        }

        private void txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarCliente();
        }
        private void dgvcliente_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dgvcliente.Rows.Count > 0)
            {
                CLI_AGRE_MODIFICAR fm = new CLI_AGRE_MODIFICAR();
                fm.lbltitulo.Text = "Actualizar Datos de Cliente";
                fm.CodigoCliente = Convert.ToInt64(dgvcliente.CurrentRow.Cells["Codigo"].Value.ToString());
                //foto.ImageLocation = Program.RutaimagenClientes + CodigoCliente + ".Png";
                fm.txthistoria.Text = dgvcliente.CurrentRow.Cells["Historia"].Value.ToString();
                fm.txtdni.Text = dgvcliente.CurrentRow.Cells["Dni"].Value.ToString();
                fm.txtpaterno.Text = dgvcliente.CurrentRow.Cells["Paterno"].Value.ToString();
                fm.txtmaterno.Text = dgvcliente.CurrentRow.Cells["Materno"].Value.ToString();
                fm.txtnombres.Text = dgvcliente.CurrentRow.Cells["Nombre"].Value.ToString();
                fm.txtdireccion.Text = dgvcliente.CurrentRow.Cells["Direccion"].Value.ToString();
                fm.txttelefono.Text = dgvcliente.CurrentRow.Cells["Telefono"].Value.ToString();
                fm.txtcelular.Text = dgvcliente.CurrentRow.Cells["Celular"].Value.ToString();
                fm.dtfechanacimiento.Text = dgvcliente.CurrentRow.Cells["Nacimiento"].Value.ToString();
                if (dgvcliente.CurrentRow.Cells["Sexo"].Value.ToString() == "M") { fm.cbosexo.SelectedIndex = 0; } else { fm.cbosexo.SelectedIndex = 1; }
                fm.txtcorreo.Text = dgvcliente.CurrentRow.Cells["Correo"].Value.ToString();
                fm.cbotipo.SelectedValue = dgvcliente.CurrentRow.Cells["CodTip"].Value;

                fm.btngrabar.Text = "Actualizar Datos";
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    ListarClientes();
                    MENSAJE_V2.Show("Modificado con exito", MENSAJE_V2.AlertType.success);
                }
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            dgvcliente_CellMouseDoubleClick(null, null);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if(dgvcliente.SelectedRows.Count > 0)
            {
                Negocio.CLI_CLIENTE CLI = new Negocio.CLI_CLIENTE();
                CLI.Codigo = Convert.ToInt64(dgvcliente.CurrentRow.Cells["Codigo"].Value.ToString());
                if (CLI.Eliminar() == true)
                {
                    MENSAJE_V2.Show("Cliente Eliminado", MENSAJE_V2.AlertType.success);
                }
                else
                {
                    MENSAJE_V2.Show("No se pudo eliminar", MENSAJE_V2.AlertType.error);
                }
            }
            else
            {
                MENSAJE_V2.Show("No hay clientes", MENSAJE_V2.AlertType.info);
            }
          
        }
    }
}
