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
using FontAwesome.Sharp;
using System.Data.SqlClient;
using CapaProteccion.Cache;
using CapaDominio;
using AsistenteVirtual;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        //PERSONALIZACION DEL BOTON Y BORDE IZQUIERDO
        
        //Campos
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        
        //Constructor
        public Principal()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,67);
            panelMenu.Controls.Add(leftBorderBtn);
            //Formulario
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        SqlConnection conexion = new SqlConnection("server=DESKTOP-NS0Q4D2;database=AsistenteVirtual;integrated security=true");

        //Estructuras
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 124, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 255);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Métodos
        private void ActivarBoton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DesactivarBoton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child Form
                iconoInicio.IconChar = currentBtn.IconChar;
                iconoInicio.IconColor = color;
            }
        }

        private void DesactivarBoton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            idUsuario.Visible = false;
            ActivarBoton(sender, RGBColors.color1);
            leftBorderBtn.Visible = false;
        }

        private void btnSintomas_Click(object sender, EventArgs e)
        {
            idUsuario.Visible = false;
            ActivarBoton(sender, RGBColors.color2);
            leftBorderBtn.Visible = false;

            PanelSintomas.Visible = true;
            lblTituloSintomas.Visible = true;
            lblPreguntaSintomas.Visible = true;
            checkBoxDepresion.Visible = true;
            checkBoxAnsiedad.Visible = true;
            checkBoxDecaimiento.Visible = true;
            btnGuardarSintomas.Visible = true;
            btnEditarSintomas.Visible = true;

            /**************************************/
            PanelActividades.Visible = false;
            lblTituloActividades.Visible = false;
            lblSubtituloActividades.Visible = false;
            lblSubtituloActividades2.Visible = false;
            lblOcio.Visible = false;
            lblTrabajo.Visible = false;
            lblNecesidades.Visible = false;
            lblDescanso.Visible = false;
            pictureOcio.Visible = false;
            pictureTrabajo.Visible = false;
            pictureNecesidades.Visible = false;
            pictureDescanso.Visible = false;

            checkBoxOcio1.Visible = false;
            checkBoxOcio2.Visible = false;
            checkBoxOcio3.Visible = false;
            checkBoxOcio4.Visible = false;

            checkBoxTrabajo1.Visible = false;
            checkBoxTrabajo2.Visible = false;
            checkBoxTrabajo3.Visible = false;
            checkBoxTrabajo4.Visible = false;

            checkBoxNecesidades1.Visible = false;
            checkBoxNecesidades2.Visible = false;
            checkBoxNecesidades3.Visible = false;
            checkBoxNecesidades4.Visible = false;

            checkBoxDescanso1.Visible = false;
            checkBoxDescanso2.Visible = false;
            checkBoxDescanso3.Visible = false;
            checkBoxDescanso4.Visible = false;

            btnGuardarActividades.Visible = false;
            /*******************************/
            PanelResultados.Visible = false;
            lblTituloResultados.Visible = false;
            lblMensajeResultados.Visible = false;
            lblMensajeResultados2.Visible = false;
            lblOcioResultado.Visible = false;
            lblTrabajoResultado.Visible = false;
            lblNecesidadesResultado.Visible = false;
            lblDescansoResultado.Visible = false;
            PictureOcioResultado.Visible = false;
            PictureTrabajoResultado.Visible = false;
            PictureNecesidadesResultado.Visible = false;
            PictureDescansoResultado.Visible = false;
            resultadoOcio1.Visible = false;
            resultadoTrabajo1.Visible = false;
            resultadoNecesidad1.Visible = false;
            resultadoDescanso1.Visible = false;

            /*Sintomas sintomas = new Sintomas();
            this.Hide();
            sintomas.Show();*/
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            /*idUsuario.Visible = false;
            ActivarBoton(sender, RGBColors.color3);
            leftBorderBtn.Visible = false;

            PanelActividades.Visible = true;
            lblTituloActividades.Visible = true;
            lblSubtituloActividades.Visible = true;
            lblSubtituloActividades2.Visible = true;
            lblOcio.Visible = true;
            lblTrabajo.Visible = true;
            lblNecesidades.Visible = true;
            lblDescanso.Visible = true;
            pictureOcio.Visible = true;
            pictureTrabajo.Visible = true;
            pictureNecesidades.Visible = true;
            pictureDescanso.Visible = true;

            checkBoxOcio1.Visible = true;
            checkBoxOcio2.Visible = true;
            checkBoxOcio3.Visible = true;
            checkBoxOcio4.Visible = true;

            checkBoxTrabajo1.Visible = true;
            checkBoxTrabajo2.Visible = true;
            checkBoxTrabajo3.Visible = true;
            checkBoxTrabajo4.Visible = true;

            checkBoxNecesidades1.Visible = true;
            checkBoxNecesidades2.Visible = true;
            checkBoxNecesidades3.Visible = true;
            checkBoxNecesidades4.Visible = true;

            checkBoxDescanso1.Visible = true;
            checkBoxDescanso2.Visible = true;
            checkBoxDescanso3.Visible = true;
            checkBoxDescanso4.Visible = true;

            btnGuardarActividades.Visible = true;*/

            /**********************************/
            /*PanelResultados.Visible = false;
            lblTituloResultados.Visible = false;
            lblMensajeResultados.Visible = false;
            lblMensajeResultados2.Visible = false;
            lblOcioResultado.Visible = false;
            lblTrabajoResultado.Visible = false;
            lblNecesidadesResultado.Visible = false;
            lblDescansoResultado.Visible = false;
            PictureOcioResultado.Visible = false;
            PictureTrabajoResultado.Visible = false;
            PictureNecesidadesResultado.Visible = false;
            PictureDescansoResultado.Visible = false;
            resultadoOcio1.Visible = false;
            resultadoTrabajo1.Visible = false;
            resultadoNecesidad1.Visible = false;
            resultadoDescanso1.Visible = false;*/

            /*Actividades actividad = new Actividades();
            this.Hide();
            actividad.Show();*/
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            idUsuario.Visible = false;
            ActivarBoton(sender, RGBColors.color4);
            leftBorderBtn.Visible = false;

            PanelResultados.Visible = true;
            lblTituloResultados.Visible = true;
            lblMensajeResultados.Visible = true;
            lblMensajeResultados2.Visible = true;
            lblOcioResultado.Visible = true;
            lblTrabajoResultado.Visible = true;
            lblNecesidadesResultado.Visible = true;
            lblDescansoResultado.Visible = true;
            PictureOcioResultado.Visible = true;
            PictureTrabajoResultado.Visible = true;
            PictureNecesidadesResultado.Visible = true;
            PictureDescansoResultado.Visible = true;
            resultadoOcio1.Visible = true;
            resultadoTrabajo1.Visible = true;
            resultadoNecesidad1.Visible = true;
            resultadoDescanso1.Visible = true;

            /**************************************/

            
        }

        private void btnMisDatos_Click(object sender, EventArgs e)
        {
            idUsuario.Visible = false;
            ActivarBoton(sender, RGBColors.color5);
            leftBorderBtn.Visible = false;

            leftBorderBtn.Visible = false;
            
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            idUsuario.Visible = false;
            ActivarBoton(sender, RGBColors.color6);
            leftBorderBtn.Visible = false;

            PanelUsuarios.Visible = true;
            
            PanelSintomas.Visible = false;
            lblTituloSintomas.Visible = false;
            lblPreguntaSintomas.Visible = false;
            checkBoxDepresion.Visible = false;
            checkBoxAnsiedad.Visible = false;
            checkBoxDecaimiento.Visible = false;
            btnGuardarSintomas.Visible = false;
            btnEditarSintomas.Visible = false;

            //dataListadoUsuarios.Visible = true;
            btnGuardar.Visible = true;


            lblNombres.Visible = true;
            lblApellidos.Visible = true;
            lblUsuario.Visible = true;
            lblContraseña.Visible = true;
            lblCorreo.Visible = true;

            /****************************/
            PanelResultados.Visible = false;
            lblTituloResultados.Visible = false;
            lblMensajeResultados.Visible = false;
            lblMensajeResultados2.Visible = false;
            lblOcioResultado.Visible = false;
            lblTrabajoResultado.Visible = false;
            lblNecesidadesResultado.Visible = false;
            lblDescansoResultado.Visible = false;
            PictureOcioResultado.Visible = false;
            PictureTrabajoResultado.Visible = false;
            PictureNecesidadesResultado.Visible = false;
            PictureDescansoResultado.Visible = false;
            resultadoOcio1.Visible = false;
            resultadoTrabajo1.Visible = false;
            resultadoNecesidad1.Visible = false;
            resultadoDescanso1.Visible = false;

            String consulta = "SELECT*FROM usuarios";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            //dataListadoUsuarios.DataSource = dt;
        }

        //Drag Form (mover formulario)
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
        int wparam, int lparam);

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                lblTitulo.Dock = DockStyle.Fill;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void CargarDatosUsuario()
        {
            lblNombreUsuario.Text = UsuarioLoginCaché.nombres + " " + UsuarioLoginCaché.apellidos;
            lblCorreoUsuario.Text = UsuarioLoginCaché.correo;
        }

        private void CargarDatosPerfil()
        {
            //Vista
            nombrePerfil.Text = UsuarioLoginCaché.nombres;
            ApellidoPerfil.Text = UsuarioLoginCaché.apellidos;
            UsuarioPerfil.Text = UsuarioLoginCaché.usuario;
            ContraseñaPerfil.Text = UsuarioLoginCaché.contraseña;
            CorreoPerfil.Text = UsuarioLoginCaché.correo;

            //Panel Editable
            txtNombres.Text = UsuarioLoginCaché.nombres;
            txtApellidos.Text = UsuarioLoginCaché.apellidos;
            txtUsuario.Text = UsuarioLoginCaché.usuario;
            txtContraseña.Text = UsuarioLoginCaché.contraseña;
            txtCorreo.Text = UsuarioLoginCaché.correo;
        }

        private void initializePassEditControls()
        {
            linkEditarPerfil.Text = "Editar";
            //txtContraseña.Enabled = false;
            panelEditarPerfil.Visible = false;
        }

        public void resetear()
        {
            CargarDatosPerfil();
            initializePassEditControls();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            idUsuario.Visible = false;
            CargarDatosPerfil();
            CargarDatosUsuario();
            initializePassEditControls();

            idUsuario.Text = Convert.ToString(UsuarioLoginCaché.idUsuario);
            PanelUsuarios.Visible = false;
            PanelSintomas.Visible = false;
            lblTituloSintomas.Visible = false;
            lblPreguntaSintomas.Visible = false;
            checkBoxDepresion.Visible = false;
            checkBoxAnsiedad.Visible = false;
            checkBoxDecaimiento.Visible = false;
            btnGuardarSintomas.Visible = false;
            btnEditarSintomas.Visible = false;

            //dataListadoUsuarios.Visible = false;
            btnGuardar.Visible = false;
            
            
            lblNombres.Visible = false;
            lblApellidos.Visible = false;
            lblUsuario.Visible = false;
            lblContraseña.Visible = false;
            lblCorreo.Visible = false;
        }

        private void panelMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Principal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /*private void dataListadoUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombres.Text = dataListadoUsuarios.SelectedCells[0].Value.ToString();
            txtApellidos.Text = dataListadoUsuarios.SelectedCells[1].Value.ToString();
            txtUsuario.Text = dataListadoUsuarios.SelectedCells[2].Value.ToString();
            txtContraseña.Text = dataListadoUsuarios.SelectedCells[3].Value.ToString();
            txtCorreo.Text = dataListadoUsuarios.SelectedCells[4].Value.ToString();
        }*/

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estás seguro de salir de la aplicación?",  "warning", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes )
            {
                this.Close();
                Login formLogin = new Login();
                formLogin.Show();
                //this.Hide();
            }
        }

        private void linkEditarPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelEditarPerfil.Visible = true;
            CargarDatosPerfil();
        }

        private void btnCancelarPerfil_Click(object sender, EventArgs e)
        {
            panelEditarPerfil.Visible = false;
            resetear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Length >= 5)
            {
                if (txtContraseña.Text != UsuarioLoginCaché.contraseña)
                {
                    //var usuarioModelo = new UsuarioModelo();
                    var usuarioModelo = new UsuarioModelo(
                        idUsuario: UsuarioLoginCaché.idUsuario,
                        nombres: txtNombres.Text,
                        apellidos: txtApellidos.Text,
                        usuario: txtUsuario.Text,
                        contraseña: txtContraseña.Text,
                        correo: txtCorreo.Text);
                    var resultado = usuarioModelo.editarPerfilUsuario();
                    MessageBox.Show(resultado);
                    resetear();
                    panelEditarPerfil.Visible = false;
                }
                else
                {
                    MessageBox.Show("Debes ingresar una contraseña diferente");
                }
            }
            else
            {
                MessageBox.Show("La contraseña debe tener minimo 5 caracteres");
            }
        }

        public void insertarSintoma()
        {
            
            String sintoma = checkBoxDepresion.Checked ? "Depresion": "-";
            String sintoma2 = checkBoxAnsiedad.Checked ? "Ansiedad": "-";
            String sintoma3 = checkBoxDecaimiento.Checked ? "Decaimiento": "-";
            idUsuario.Text = Convert.ToString (UsuarioLoginCaché.idUsuario);
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
            catch(Exception ex)
            {
                MessageBox.Show("Error al registrar los datos" + ex);
            }

        }

        public void insertarActividad()
        {
            String actividad;
            String tipoActividad=null;

            if (checkBoxOcio1.Checked == true) { 
                actividad = "Salir con amigos";
                lblOcio.Text = "Ocio";
                tipoActividad = lblOcio.Text;
                checkBoxOcio1.Checked = false;
            }
            else
            {
                actividad = "";
                if (checkBoxOcio2.Checked == true)
                {
                    actividad = "Jugar Videojuegos";
                    lblOcio.Text = "Ocio";
                    tipoActividad = lblOcio.Text;
                    checkBoxOcio2.Checked = false;
                }
                else
                {
                    actividad = "";
                    if (checkBoxOcio3.Checked == true)
                    {
                        actividad = "Ver series/peliculas";
                        lblOcio.Text = "Ocio";
                        tipoActividad = lblOcio.Text;
                        checkBoxOcio3.Checked = false;
                    }
                    else
                    {
                        actividad = "";
                        if (checkBoxOcio4.Checked == true)
                        {
                            actividad = "Hacer deporte";
                            lblOcio.Text = "Ocio";
                            tipoActividad = lblOcio.Text;
                            checkBoxOcio4.Checked = false;
                        }
                        else
                        {
                            actividad = "";
                            if (checkBoxTrabajo1.Checked == true)
                            {
                                actividad = "Hacer tareas";
                                lblTrabajo.Text = "Trabajo";
                                tipoActividad = lblTrabajo.Text;
                                checkBoxTrabajo1.Checked = false;
                            }
                            else
                            {
                                actividad = "";
                                if (checkBoxTrabajo2.Checked == true)
                                {
                                    actividad = "Lavar la ropa";
                                    lblTrabajo.Text = "Trabajo";
                                    tipoActividad = lblTrabajo.Text;
                                    checkBoxTrabajo2.Checked = false;
                                }
                                else
                                {
                                    actividad = "";
                                    if (checkBoxTrabajo3.Checked == true)
                                    {
                                        actividad = "Ir a trabajar";
                                        lblTrabajo.Text = "Trabajo";
                                        tipoActividad = lblTrabajo.Text;
                                        checkBoxTrabajo3.Checked = false;
                                    }
                                    else
                                    {
                                        actividad = "";
                                        if (checkBoxTrabajo4.Checked == true)
                                        {
                                            actividad = "Limpiar mi cuarto";
                                            lblTrabajo.Text = "Trabajo";
                                            tipoActividad = lblTrabajo.Text;
                                            checkBoxTrabajo4.Checked = false;
                                        }
                                        else
                                        {
                                            actividad = "";
                                            if (checkBoxNecesidades1.Checked == true)
                                            {
                                                actividad = "Comer";
                                                lblNecesidades.Text = "Necesidades";
                                                tipoActividad = lblNecesidades.Text;
                                                checkBoxNecesidades1.Checked = false;
                                            }
                                            else
                                            {
                                                actividad = "";
                                                if (checkBoxNecesidades2.Checked == true)
                                                {
                                                    actividad = "Caminar";
                                                    lblNecesidades.Text = "Necesidades";
                                                    tipoActividad = lblNecesidades.Text;
                                                    checkBoxNecesidades2.Checked = false;
                                                }
                                                else
                                                {
                                                    actividad = "";
                                                    if (checkBoxNecesidades3.Checked == true)
                                                    {
                                                        actividad = "Dormir";
                                                        lblNecesidades.Text = "Necesidades";
                                                        tipoActividad = lblNecesidades.Text;
                                                        checkBoxNecesidades3.Checked = false;
                                                    }
                                                    else
                                                    {
                                                        actividad = "";
                                                        if (checkBoxNecesidades4.Checked == true)
                                                        {
                                                            actividad = "Viajar";
                                                            lblNecesidades.Text = "Necesidades";
                                                            tipoActividad = lblNecesidades.Text;
                                                            checkBoxNecesidades4.Checked = false;
                                                        }
                                                        else
                                                        {
                                                            actividad = "";
                                                            if (checkBoxDescanso1.Checked == true)
                                                            {
                                                                actividad = "Leer un libro";
                                                                lblDescanso.Text = "Descanso";
                                                                tipoActividad = lblDescanso.Text;
                                                                checkBoxDescanso1.Checked = false;
                                                            }
                                                            else
                                                            {
                                                                actividad = "";
                                                                if (checkBoxDescanso2.Checked == true)
                                                                {
                                                                    actividad = "Escuchar musica";
                                                                    lblDescanso.Text = "Descanso";
                                                                    tipoActividad = lblDescanso.Text;
                                                                    checkBoxDescanso2.Checked = false;
                                                                }
                                                                else
                                                                {
                                                                    actividad = "";
                                                                    if (checkBoxDescanso3.Checked == true)
                                                                    {
                                                                        actividad = "Hablar con mi familia";
                                                                        lblDescanso.Text = "Descanso";
                                                                        tipoActividad = lblDescanso.Text;
                                                                        checkBoxDescanso3.Checked = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        actividad = "";
                                                                        if (checkBoxDescanso4.Checked == true)
                                                                        {
                                                                            actividad = "Salir con amigos";
                                                                            lblDescanso.Text = "Descanso";
                                                                            tipoActividad = lblDescanso.Text;
                                                                            checkBoxDescanso4.Checked = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            actividad = "";
                                                                        }
                                                                    }      
                                                                }                                                              
                                                            }                    
                                                        }                                                        
                                                    }                                                  
                                                }                                              
                                            }                                        
                                        }                                       
                                    }                                 
                                }                              
                            }
                        }
                    }                    
                }
            }  

            idUsuario.Text = Convert.ToString(UsuarioLoginCaché.idUsuario);
            String usuarioId = idUsuario.Text;
            
            try
            {
                conexion.Open();
                String sql = "INSERT INTO actividades (nombreActividad,tipoActividad,idUsuario) VALUES (@actividad,@tipoActividad,@idUsuario) ";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@actividad", actividad);
                comando.Parameters.AddWithValue("@tipoActividad", tipoActividad);
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

        private void btnGuardarActividades_Click(object sender, EventArgs e)
        {
            insertarActividad();
        }

        private void btnGuardarSintomas_Click(object sender, EventArgs e)
        {
            insertarSintoma();
        }

        public void editarSintomas()
        {
            String sintoma = checkBoxDepresion.Checked ? "Depresion" : "-";
            String sintoma2 = checkBoxAnsiedad.Checked ? "Ansiedad" : "-";
            String sintoma3 = checkBoxDecaimiento.Checked ? "Decaimiento" : "-";

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

        private void btnEditarSintomas_Click(object sender, EventArgs e)
        {
            editarSintomas();
        }
    }
}