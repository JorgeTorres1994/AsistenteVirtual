using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CapaPresentacion
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
        int wparam, int lparam);

        SqlConnection conexion = new SqlConnection("server=DESKTOP-NS0Q4D2;database=AsistenteVirtual;integrated security=true");

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Registrar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtNombres_Enter(object sender, EventArgs e)
        {
            if (txtNombres.Text == "NOMBRES")
            {
                txtNombres.Text = "";
                txtNombres.ForeColor = Color.LightGray;
            }
        }

        private void txtNombres_Leave(object sender, EventArgs e)
        {
            if (txtNombres.Text == "")
            {
                txtNombres.Text = "NOMBRES";
                txtNombres.ForeColor = Color.DimGray;
            }
        }

        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "APELLIDOS")
            {
                txtApellidos.Text = "";
                txtApellidos.ForeColor = Color.LightGray;
            }
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "")
            {
                txtApellidos.Text = "APELLIDOS";
                txtApellidos.ForeColor = Color.DimGray;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "CORREO")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.LightGray;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "CORREO";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            this.Hide();
            formLogin.Show();
        }

        public void insertar()
        {
            conexion.Open();
            String sql = "INSERT INTO usuarios (nombres,apellidos,usuario,contraseña,correo)"
                + "VALUES ('" + txtNombres.Text + "', '" + txtApellidos.Text + "', '" + txtUsuario.Text + "', '" + txtContraseña.Text + "', '" + txtCorreo.Text + "')";
            SqlCommand comando = new SqlCommand(sql, conexion);

            comando.ExecuteNonQuery();
            MessageBox.Show("!Tu cuenta fue creada exitosamente!");
            conexion.Close();
            
        }

       

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            insertar();
        }
    }
}
