using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using CapaDominio;
using AsistenteVirtual;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
        int wparam, int lparam);

        //SqlConnection conexion = new SqlConnection("server=RODRIGOFK;database=AsistenteVirtual;integrated security=true");

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            /*conexion.Open();
            String sql = "SELECT*FROM usuarios WHERE usuario='" + txtUsuario.Text + "' AND contraseña='" + txtContraseña.Text + "'";
            SqlCommand comando = new SqlCommand(sql, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                MessageBox.Show("Bienvenido al sistema!!!");
                Principal formularioPrincipal = new Principal();
                this.Hide();
                formularioPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
            conexion.Close();*/
            if (txtUsuario.Text != "USUARIO")
            {
                if (txtContraseña.Text != "CONTRASEÑA")
                {
                    UsuarioModelo usuario = new UsuarioModelo();
                    var validarLogin = usuario.LoginUsuario(txtUsuario.Text, txtContraseña.Text);
                    if (validarLogin == true)
                    {
                        //MessageBox.Show("BIENVENIDO AL SISTEMA "+ txtUsuario.Text + "!!!");
                        this.Hide();
                        Bienvenida form = new Bienvenida();
                        form.ShowDialog();
                        form.Hide();
                        Principal formPrincipal = new Principal();
                        formPrincipal.Show();

                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos");
                        
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa la contraseña");
                }

            }
            else
            {
                MessageBox.Show("Ingresa el usuario");
            }
            
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text=="CONTRASEÑA")
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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar formRegistro = new Registrar();
            this.Hide();
            formRegistro.Show();
        }

        private void linkPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recuperarContraseña = new RecuperarContraseña();
            recuperarContraseña.ShowDialog();
        }
    }
}
