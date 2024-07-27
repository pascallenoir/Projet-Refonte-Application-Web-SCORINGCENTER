using ScoringCenter.Scoring;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web;

namespace ScoringCenter.Models
{
    public static class SendMail
    {

        public static void EnvoyerMail(MailMessage message)
        {
            string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            string username = ConfigurationManager.AppSettings["SmtpUsername"];
            string password = ScorCryptage.Decrypt(ConfigurationManager.AppSettings["SmtpPassword"]);

            SmtpClient client = new SmtpClient(smtpServer, smtpPort)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(username, password)
            };

            message.From = new MailAddress(username, "Scoring Center");
            client.Send(message);
        }

    }
}