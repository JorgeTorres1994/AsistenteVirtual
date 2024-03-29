using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace CapaDatos.ServiciosCorreo
{
    public class ServidorCorreoMaestro
    {
        private SmtpClient smtpClient;
        protected String remitente { get; set; }
        protected String contraseña { get; set; }
        protected String host { get; set; }
        protected int puerto { get; set; }
        protected bool ssl { get; set; }

        protected void initializeStmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(remitente, contraseña);//Especificar las credenciales
            smtpClient.Host = host;
            smtpClient.Port = puerto;
            smtpClient.EnableSsl = ssl;
        }

        public void sendMail(String asunto, String cuerpo, List<String> destinatario)
        {
            var mensajeCorreo = new MailMessage();
            try
            {
                mensajeCorreo.From = new MailAddress(remitente);
                foreach (String correo in destinatario)
                {
                    mensajeCorreo.To.Add(correo);
                }
                mensajeCorreo.Subject = asunto;
                mensajeCorreo.Body = cuerpo;
                mensajeCorreo.Priority = MailPriority.Normal;
                smtpClient.Send(mensajeCorreo);
            }
            catch(Exception ex){
            }
            finally
            {
                mensajeCorreo.Dispose();
                smtpClient.Dispose();
            }
        }
    }
}
