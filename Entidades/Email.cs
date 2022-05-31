using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Entidades
{
   
    public class Email
    {
        string EmailSmtpServer = "smtp.gmail.com";
        string EnableSSL = "1";
        string EmailPort = "587";
        string mail = "meeting.app.cba@gmail.com";//mail que envia
        string password = "meeting2022cba";

        public void SendEmailRegistro(string _emailUsuario, string NombreSolicitante, string user, string pass, 
            ref string mensajeErrror)
        {
            try
            {
                string pFromEmail = mail;
                string pFromPassword = password;
                string pEmailSmtpServer = EmailSmtpServer;
                string pEnableSSL = EnableSSL;
                string pPort = EmailPort;
                #pragma warning disable CS0219 // La variable 'b' está asignada pero su valor nunca se usa
                bool b = false;
                #pragma warning restore CS0219 // La variable 'b' está asignada pero su valor nunca se usa

                string asuntoMail = "Registrado con éxito";
                
                string templateMail;

                const string pBodyHtml =
                @"<html>
                        <head></head>
                        <body>
                            <p><i>Hola {0}, </i><p>
                            <p><i>Su cuenta fue dada de alta, con los siguientes datos:</i><p>
                            <p><i><b>Usuario:</b> {1}</i><p>
                            <p><i><b>Contraseña:</b> {2}</i><p>
                            <p><i>Muchas gracias por confiar en Meeting App</i></p>
                            <p><i>Saludos!!!</i></p>
                        </body>
                  </html>";

                templateMail = string.Format(pBodyHtml, NombreSolicitante, user, pass);

                MailMessage mm = new MailMessage(pFromEmail, _emailUsuario)
                {
                    Subject = asuntoMail,
                    IsBodyHtml = true,
                    Body = templateMail
                };

                bool _ssl = false;
                if (pEnableSSL == "1")
                    _ssl = true;

                SmtpClient smtp = new SmtpClient
                {
                    Host = pEmailSmtpServer,
                    Port = int.Parse(pPort),
                    EnableSsl = _ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(pFromEmail, pFromPassword)
                };

                //TODO: PAT, solucion1 de esta forma funciona
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };

                smtp.Send(mm);
            }

            catch (SmtpException e)
            {
                mensajeErrror = e.Message.ToString();
            }
            catch (Exception e)
            {
                mensajeErrror = e.Message.ToString();
            }
        }

    }
}
