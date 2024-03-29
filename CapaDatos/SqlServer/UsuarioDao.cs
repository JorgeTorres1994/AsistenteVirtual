using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaProteccion.Cache;

namespace CapaDatos
{
    public class UsuarioDao: conexion
    {
        public void EditarPerfil(int id, String Nombres, String Apellidos, String Usuario, String Contraseña, String Correo)
        {
            using(var connection = ObtenerConexion())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "UPDATE usuarios SET nombres=@nombres, apellidos=@apellidos, usuario=@usuario, contraseña=@contraseña, correo=@correo WHERE id=@id";
                    comando.Parameters.AddWithValue("@nombres", Nombres);
                    comando.Parameters.AddWithValue("@apellidos", Apellidos);
                    comando.Parameters.AddWithValue("@usuario", Usuario);
                    comando.Parameters.AddWithValue("@contraseña", Contraseña);
                    comando.Parameters.AddWithValue("@correo", Correo);
                    comando.Parameters.AddWithValue("@id", id);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();//ejecutar comando
                }
            }
        }

        public bool login(String user, String pass)
        {
            using (var connection = ObtenerConexion())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "SELECT*FROM usuarios WHERE usuario=@user AND contraseña=@pass";
                    comando.Parameters.AddWithValue("@user", user);
                    comando.Parameters.AddWithValue("@pass", pass);
                    comando.CommandType = CommandType.Text;
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //int idUsuario;
                            UsuarioLoginCaché.idUsuario = reader.GetInt32(0);
                            //idUsuario = UsuarioLoginCaché.idUsuario;
                            UsuarioLoginCaché.nombres = reader.GetString(1);
                            UsuarioLoginCaché.apellidos = reader.GetString(2);
                            UsuarioLoginCaché.usuario = reader.GetString(3);
                            UsuarioLoginCaché.contraseña = reader.GetString(4);
                            UsuarioLoginCaché.correo = reader.GetString(5);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public String recuperarContraseña(String usuarioSolicitado)
        {
            using (var connection = ObtenerConexion())
            {
                connection.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.CommandText = "SELECT * FROM usuarios WHERE usuario=@usuario OR correo=@correo";
                    comando.Parameters.AddWithValue("@usuario", usuarioSolicitado);
                    comando.Parameters.AddWithValue("@correo", usuarioSolicitado);
                    comando.CommandType = CommandType.Text;
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        String nombreUsuario = reader.GetString(2) + ", " + reader.GetString(4);
                        String correoUsuario = reader.GetString(6);
                        String contraseñaCuenta = reader.GetString(5);

                        var mailService = new ServiciosCorreo.SistemaSoporteCorreo();
                        mailService.sendMail(
                            asunto: "Solicitud de recuperacion de contraseña",
                            cuerpo: "Hola, " + nombreUsuario + "\nHas solicitado recuperar tu contraseña.\n"+
                            "tu contraseña actual es: "+ contraseñaCuenta +
                            "\nSin embargo, le pedimos que cambie su contraseña inmediatamente una vez que ingrese al sistema.",
                            destinatario: new List<string> { correoUsuario }
                            ) ;
                        return "Hola, " + nombreUsuario + "\nHas solicitado recuperar tu contraseña.\n" +
                            "Porfavor revisa tu correo: " + correoUsuario +
                            "\nSin embargo, le pedimos que cambie su contraseña inmediatamente una vez que ingrese al sistema.";
                    }
                    else
                    {
                        return "Lo sentimos, usted no tiene una cuenta con el email o correo";
                    }
                }
            }
        }
    }
}
