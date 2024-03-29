using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;
using CapaProteccion.Cache;

namespace AsistenteVirtual
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.05;

                barraCarga.Value++;
                porcentajeCarga.Text = barraCarga.Value.ToString() + "%";

                if (barraCarga.Value == 100)
                {
                    timer1.Stop();
                    timer2.Start();
                }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }

        private void FormularioBienvenida_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = UsuarioLoginCaché.nombres + "  " + UsuarioLoginCaché.apellidos;
            this.Opacity = 0.0;
            timer1.Start();
        }
    }
}
