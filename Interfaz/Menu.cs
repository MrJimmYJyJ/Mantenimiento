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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnventapagos_Click(object sender, EventArgs e)
        {
            CLIENTE fm = CLIENTE.ObtenerInstancia();
            fm.MdiParent = this;
            fm.Show();
        }

        private void btnabonocredito_Click(object sender, EventArgs e)
        {
            CLI_TIPO fm = CLI_TIPO.ObtenerInstancia();
            fm.MdiParent = this;
            fm.Show();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
