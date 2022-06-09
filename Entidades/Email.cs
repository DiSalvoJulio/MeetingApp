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
        string EmailSmtpServer = "smtp.office365.com"; //"smtp.gmail.com";
        string EnableSSL = "1";
        string EmailPort = "587"; //"587"; 
        string mail = "meeting.app.cba@outlook.com";//mail que envia "meeting.app.cba@gmail.com"
        string password = "meeting2022cba"; //meeting2022cba

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


        public void SendEmailRecuperarContrasenia(string _emailUsuario, string NombreSolicitante, int idUsuario,
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

                string link = "https://localhost:44398/ActualizarPassword.aspx?id=" + idUsuario;

                string asuntoMail = "Recupero con exito";

                //string templateMail;

                string pBodyHtml = "<html>";
                pBodyHtml += "<head></head>";
                pBodyHtml += "<body>";
                pBodyHtml += "<p><i>Hola " + NombreSolicitante + ", </i><p>";
                pBodyHtml += "<p><i>Procedio a recuperar la contraseña</i><p>";
                pBodyHtml += "<a href=\""+ link +"\">Hacer click en este Link</a>";
                pBodyHtml += "<p><i>Muchas gracias por confiar en Meeting App</i></p>";
                pBodyHtml += "<p><i>Saludos!!!</i></p>";
                pBodyHtml += "</body>";
                pBodyHtml += "</html>";
                

                //templateMail = string.Format(pBodyHtml, NombreSolicitante, link);

                MailMessage mm = new MailMessage(pFromEmail, _emailUsuario)
                {
                    Subject = asuntoMail,
                    IsBodyHtml = true,
                    Body = pBodyHtml
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

        //ENVIO EMAIL CUANDO SACAS EL TURNO
        public void SendEmailNuevoTurno(string _emailUsuario, string paciente, string fecha, string hora, string especialidad, string profesional, ref string mensajeErrror)
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

                //string link = "https://localhost:44398/ActualizarPassword.aspx?id=" + idUsuario;

                string asuntoMail = "Nuevo Turno";

                //string templateMail;

                string pBodyHtml = "<html>";
                pBodyHtml += "<head></head>";
                pBodyHtml += "<body>";
                pBodyHtml += "<p><i>Hola " + paciente + ", </i><p>";
                pBodyHtml += "<p><i>Usted tiene un nuevo turno</i><p>";
                pBodyHtml += "<p><i>" + fecha + "</i><p>";
                pBodyHtml += "<p><i>" + hora + "</i><p>";
                pBodyHtml += "<p><i>" + especialidad + "</i><p>";
                pBodyHtml += "<p><i>" + profesional + "</i><p>";
                //pBodyHtml += "<a href=\"" + link + "\">Hacer click en este Link</a>";
                pBodyHtml += "<p><i>Muchas gracias por confiar en Meeting App</i></p>";
                pBodyHtml += "<p><i>Saludos!!!</i></p>";
                pBodyHtml += "</body>";
                pBodyHtml += "</html>";


                //templateMail = string.Format(pBodyHtml, NombreSolicitante, link);

                MailMessage mm = new MailMessage(pFromEmail, _emailUsuario)
                {
                    Subject = asuntoMail,
                    IsBodyHtml = true,
                    Body = pBodyHtml
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


        //public bool EnviarEmailDatosTurnos(string email)
        //{
        //    bool enviado = false;   //enviar mail

        //    System.Net.Mail.MailMessage mgs = new System.Net.Mail.MailMessage();

        //    mgs.To.Add(email); // email destino 
        //    mgs.Subject = "Meeting App Informa";
        //    mgs.SubjectEncoding = System.Text.Encoding.UTF8;
        //    mgs.Body = "Usted tiene un Nuevo Turno. Muchas gracias";
        //    mgs.BodyEncoding = System.Text.Encoding.UTF8;
        //    mgs.IsBodyHtml = true;

        //    mgs.From = new System.Net.Mail.MailAddress("meeting.app.cba@gmail.com");

        //    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

        //    cliente.Credentials = new System.Net.NetworkCredential("meeting.app.cba@gmail.com", "meeting2022cba");

        //    // puerto y host

        //    cliente.Port = 587; //puerto mismo para hostmail y gmail
        //    cliente.EnableSsl = true;

        //    //cliente.Host = "smtp.office365.com"; // HOTMAIL
        //    cliente.Host = "smtp.gmail.com";//GMAIL
        //    try
        //    {
        //        cliente.Send(mgs);
        //        enviado = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        enviado = false;
        //    }
        //    return enviado;
        //}





    }
}
