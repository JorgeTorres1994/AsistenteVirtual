using CapaPresentacion;
using CapaProteccion.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsistenteVirtual
{
    public partial class Actividades : Form
    {
        public Actividades()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=DESKTOP-NS0Q4D2;database=AsistenteVirtual;integrated security=true");

        //Drag Form (mover formulario)
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
        int wparam, int lparam);

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            this.Hide();
            principal.Show();
        }

        private void btnSintomas_Click(object sender, EventArgs e)
        {
            Sintomas sintomas = new Sintomas();
            this.Hide();
            sintomas.Show();
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                lblTitulo.Dock = DockStyle.Fill;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CargarDatosUsuario()
        {
            lblNombreUsuario.Text = UsuarioLoginCaché.nombres + " " + UsuarioLoginCaché.apellidos;
            lblCorreoUsuario.Text = UsuarioLoginCaché.correo;
        }

        private void Actividades_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void PanelActividades_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Actividades_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estás seguro de salir de la aplicación?", "warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                Login formLogin = new Login();
                formLogin.Show();
                //this.Hide();
            }
        }
    }
}
