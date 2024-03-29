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
    public partial class Sintomas : Form
    {
        public Sintomas()
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

        public void insertarSintoma()
        {

            String sintoma = checkBoxDepresion.Checked ? "Depresion" : "-";
            String sintoma2 = checkBoxAnsiedad.Checked ? "Ansiedad" : "-";
            String sintoma3 = checkBoxDecaimiento.Checked ? "Decaimiento" : "-";
            idUsuario.Text = Convert.ToString(UsuarioLoginCaché.idUsuario);
            String usuarioId = idUsuario.Text;
            try
            {
                conexion.Open();
                //idUsuario.Text = Convert.ToString(UsuarioLoginCaché.idUsuario);
                String sql = "INSERT INTO sintomas (primer_sintoma,segundo_sintoma,tercer_sintoma,idUsuario) VALUES (@sintoma1,@sintoma2,@sintoma3,@idUsuario)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@sintoma1", sintoma);
                comando.Parameters.AddWithValue("@sintoma2", sintoma2);
                comando.Parameters.AddWithValue("@sintoma3", sintoma3);
                comando.Parameters.AddWithValue("@idUsuario", usuarioId);

                comando.ExecuteNonQuery();
                MessageBox.Show("!Tus sintomas fueron guardados correctamente!");
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar los datos" + ex);
            }

        }
        
       
        public void editarSintomas()
        {
            String sintoma=null, sintoma2=null, sintoma3=null;
            /*String sintoma = checkBoxDepresion.Checked ? "Depresion" : "-";
            String sintoma2 = checkBoxAnsiedad.Checked ? "Ansiedad" : "-";
            String sintoma3 = checkBoxDecaimiento.Checked ? "Decaimiento" : "-";*/

            if (checkBoxDepresion.Checked == true && checkBoxAnsiedad.Checked == false && checkBoxDecaimiento.Checked == false)
            {
                sintoma = "Depresion";
                
                sintoma2 = "-";
                
                sintoma3 = "-";
            }
            else
            {
                if (checkBoxDepresion.Checked==true && checkBoxAnsiedad.Checked==true && checkBoxDecaimiento.Checked == false)
                {
                    sintoma = "Depresion";
                    sintoma2 = "Ansiedad";
                    sintoma3 = "-";
                }
                else
                {
                    if (checkBoxDepresion.Checked==true && checkBoxAnsiedad.Checked==true && checkBoxDecaimiento.Checked==true)
                    {
                        sintoma = "Depresion";
                        sintoma2 = "Ansiedad";
                        sintoma3 = "Decaimiento";
                    }
                    else
                    {
                        MessageBox.Show("Debes seleccionar al menos un sintoma!");
                    }
                }
            }

            try
            {
                conexion.Open();
                String consulta = "UPDATE sintomas SET primer_sintoma=@sintoma1, segundo_sintoma=@sintoma2, tercer_sintoma=@sintoma3 WHERE id=@idUsuario";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@sintoma1", sintoma);
                comando.Parameters.AddWithValue("@sintoma2", sintoma2);
                comando.Parameters.AddWithValue("@sintoma3", sintoma3);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("Tus sintomas fueron editados correctamente!");
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar los datos" + ex);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            this.Hide();
            principal.Show();
        }

        private void btnGuardarSintomas_Click(object sender, EventArgs e)
        {
            insertarSintoma();
            btnGuardarSintomas.Visible = false;
            btnEditarSintomas.Visible = true;
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            Actividades actividad = new Actividades();
            this.Hide();
            actividad.Show();
        }

        private void btnSintomas_Click(object sender, EventArgs e)
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

        private void Sintomas_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void Sintomas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PanelSintomas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnEditarSintomas_Click(object sender, EventArgs e)
        {
            editarSintomas();
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
