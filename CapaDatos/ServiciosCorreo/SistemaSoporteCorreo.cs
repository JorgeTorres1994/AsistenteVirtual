using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ServiciosCorreo
{
    class SistemaSoporteCorreo:ServidorCorreoMaestro
    {
        public SistemaSoporteCorreo()
        {
            remitente = "tonyblakes1000@gmail.com";
            contraseña = "onichichi1";
            host = "smtp.gmail.com";
            puerto = 587;
            ssl = true;
            initializeStmtpClient();
        }
    }
}
