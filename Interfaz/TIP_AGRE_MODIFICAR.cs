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
    public partial class TIP_AGRE_MODIFICAR : Form
    {
        public Int32 Codigo = 0;
        public TIP_AGRE_MODIFICAR()
        {
            InitializeComponent();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            Negocio.CLI_TIPO tip = new Negocio.CLI_TIPO();
            tip.Nombre = txtnombre.Text.Trim();

            if(Codigo == 0)
            {
                if(tip.Agregar() == true)
                {
                  DialogResult =  DialogResult.OK;
                }
                else
                {
                    MENSAJE_V2.Show("No se pudo grabar", MENSAJE_V2.AlertType.error);
                }

            }
            else
            {
                tip.Codigo = Codigo;
                if (tip.Modificar() == true)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MENSAJE_V2.Show("No se pudo grabar", MENSAJE_V2.AlertType.error);
                }
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
