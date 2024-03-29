using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaDominio
{
    public class UsuarioModelo
    {
        UsuarioDao usuarioDao = new UsuarioDao();

        /*Atributos del usuario*/
        private int idUsuario;
        private String nombres;
        private String apellidos;
        private String usuario;
        private String contraseña;
        private String correo;

        public String recuperarContraseña(String usuarioSolicitado)
        {
            return usuarioDao.recuperarContraseña(usuarioSolicitado);
        }

        public UsuarioModelo(int idUsuario, String nombres, String apellidos, String usuario, String contraseña, String correo)
        {
            this.idUsuario = idUsuario;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.correo = correo;
        }

        public UsuarioModelo()
        {

        }

        public String editarPerfilUsuario()
        {
            try
            {
                usuarioDao.EditarPerfil(idUsuario, nombres, apellidos, usuario, contraseña, correo);
                LoginUsuario(usuario, contraseña);//para actualizar los datos del usuario;
                return "Tu perfil se actúalizó correctamente";
            }
            catch(Exception ex)
            {
                return "El nombre de usuario ya está en uso" + ex;
            }
        }

        public bool LoginUsuario(String user, String pass)
        {
            return usuarioDao.login(user, pass);
        }
    }
}
