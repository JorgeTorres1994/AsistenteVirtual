using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDominio;

namespace AsistenteVirtual
{
    public partial class RecuperarContraseña : Form
    {
        public RecuperarContraseña()
        {
            InitializeComponent();
        }

        private void FormularioRecuperarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            var usuario = new UsuarioModelo();
            var resultado = usuario.recuperarContraseña(txtRecuperacion.Text);
            lblResultado.Text = resultado;
        }
    }
}
