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

        public static string SendMessage1(string mailFrom, string mailFromDisplayName, string mailTo, string[] mailCc, string subject, string body, string[] attachmentFilenames)
        {
            string res = "Operation reussie!!!";
            try
            {
                using (SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]))
                {
                    string resj = ScorCryptage.Decrypt(ConfigurationManager.AppSettings["SmtpPassword"]);
                    client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpUsername"], ScorCryptage.Decrypt(ConfigurationManager.AppSettings["SmtpPassword"]));

                    //client.EnableSsl = true;
                    //client.Credentials = CredentialCache.DefaultNetworkCredentials;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    string to = mailTo;
                    string cc = mailCc != null ? string.Join(",", mailCc) : null;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(mailFrom, mailFromDisplayName);
                    mail.To.Add(to);

                    if (cc != null)
                    {
                        mail.CC.Add(cc);
                    }
                    if (attachmentFilenames != null)
                    {
                        foreach (var attachmentFilename in attachmentFilenames)
                        {
                            //Attachment attachment = new Attachment(attachmentFilename.Replace(@"\\", @"\"), MediaTypeNames.Application.Octet);
                            //ContentDisposition disposition = attachment.ContentDisposition;
                            //disposition.CreationDate = File.GetCreationTime(attachmentFilename);
                            //disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
                            //disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
                            //disposition.FileName = Path.GetFileName(attachmentFilename);
                            //disposition.Size = new FileInfo(attachmentFilename).Length;
                            //disposition.DispositionType = DispositionTypeNames.Attachment;
                            //mail.Attachments.Add(attachment);
                        }
                    }
                    mail.Subject = subject;
                    mail.Body = body.Replace(Environment.NewLine, "<BR>");
                    mail.IsBodyHtml = true;
                    client.Timeout = 999999;
                    client.Send(mail);
                }
                return res;

            }
            catch (Exception ex)
            {
                return res = ex.Message;
                //exception handling
            }
        }


        public static string SendMessage(string mailFrom, string mailFromDisplayName, string mailTo, string[] mailCc, string subject, string body, string[] attachmentFilenames)
        {
            string res = "Operation reussie!!!";
            try
            {
                using (SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]))
                {
                    client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpUsername"], ScorCryptage.Decrypt(ConfigurationManager.AppSettings["SmtpPassword"]));
                    string cc="";
                    string to = mailTo;
                    if (mailCc.Length == 1)
                    {
                        if (mailCc[0] == null) cc = null;
                        else cc = string.Join(",", mailCc);
                    }else
                    {
                        cc = string.Join(",", mailCc);
                    }

                     //cc = mailCc != null ? string.Join(",", mailCc) : null;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(mailFrom, mailFromDisplayName);
                    mail.To.Add(to);

                    if (cc != null)
                    {
                        mail.CC.Add(cc);
                    }
                    if (attachmentFilenames != null)
                    {
                        foreach (var attachmentFilename in attachmentFilenames)
                        {
                            //Attachment attachment = new Attachment(attachmentFilename.Replace(@"\\", @"\"), MediaTypeNames.Application.Octet);
                            //ContentDisposition disposition = attachment.ContentDisposition;
                            //disposition.CreationDate = File.GetCreationTime(attachmentFilename);
                            //disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
                            //disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
                            //disposition.FileName = Path.GetFileName(attachmentFilename);
                            //disposition.Size = new FileInfo(attachmentFilename).Length;
                            //disposition.DispositionType = DispositionTypeNames.Attachment;
                            //mail.Attachments.Add(attachment);
                        }
                    }
                    mail.Subject = subject;
                    mail.Body = body.Replace(Environment.NewLine, "<BR>");
                    mail.IsBodyHtml = true;
                    client.Timeout = 999999;
                    client.Send(mail);
                }
                return res;

            }
            catch (Exception ex)
            {
                return res = ex.Message;
                //exception handling
            }
        }
    }
}