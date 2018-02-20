using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DenemeSinavSonuclari
{
    public class Hata
    {
        //asekron yazılacak !!!!!!!!!!!!!
        public static void Bildir(Exception e)
        {
            string icerik = string.Format("{0}<br>,{1}<br>,{2}<br>,{3}", e.Message, e.Source, e.StackTrace, e.InnerException);
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("gonderen@mail.com");
            //
            ePosta.To.Add("alici@mail.com");
     
            //
            ePosta.Subject = "Hata Bildirimi";
            //
            ePosta.Body = icerik;
            ePosta.IsBodyHtml = true;
            //
            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new NetworkCredential("hesap@mail.com", "sifre");
            smtp.Port = 587;
            smtp.Host = "smtp.yandex.com.tr";
            smtp.EnableSsl = true;
            object userState = ePosta;
            
            try
            {
                //smtp.Send(ePosta);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
            

        }
    }
}