using System;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Diagnostics;

namespace Controllers.Models
{
    public static class MailSender
    {
        public static bool SendMail(FeedbackMessage feedbackMessage)
        {
            SmtpClient smtp = new SmtpClient(ConfigurationSettings.AppSettings["SmtpHost"], int.Parse(ConfigurationSettings.AppSettings["SmtpPort"]))
                                  {
                                      Timeout = 1000000,
                                      EnableSsl = true,
                                      DeliveryMethod = SmtpDeliveryMethod.Network,
                                      Credentials =
                                          new NetworkCredential(ConfigurationSettings.AppSettings["MailUserName"],
                                                                ConfigurationSettings.AppSettings["MailPassword"])
                                  };

            MailMessage message = new MailMessage
                                      {
                                          Priority = MailPriority.High,
                                          From =
                                              new MailAddress(ConfigurationSettings.AppSettings["MailUserName"],
                                                              feedbackMessage.Name),
                                          ReplyTo = new MailAddress(feedbackMessage.Email)
                                      };

            if (!String.IsNullOrEmpty(ConfigurationSettings.AppSettings["BccAddress"]))
            {
                message.Bcc.Add(new MailAddress(ConfigurationSettings.AppSettings["BccAddress"]));
            }
            if (!String.IsNullOrEmpty(ConfigurationSettings.AppSettings["BccAddress2"]))
            {
                message.Bcc.Add(new MailAddress(ConfigurationSettings.AppSettings["BccAddress2"]));
            }
            message.To.Add(new MailAddress(ConfigurationSettings.AppSettings["MailTo"]));
            message.Subject = ConfigurationSettings.AppSettings["MailSubject"];
            message.Body = feedbackMessage.Comment;

            try
            {
                System.Threading.Thread.Sleep(5000);
                smtp.Send(message);
                return true;
            }
            // Extra try
            //catch (SmtpFailedRecipientsException ex)
            //{
            //    for (int i = 0; i < ex.InnerExceptions.Length; i++)
            //    {
            //        SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
            //        if (status == SmtpStatusCode.MailboxBusy ||
            //            status == SmtpStatusCode.MailboxUnavailable)
            //        {
            //            Debug.WriteLine("Sending error. Waiting 5 seconds.");
            //            System.Threading.Thread.Sleep(5000);
            //            smtp.Send(message);
            //        }
            //        else
            //        {
            //            Debug.WriteLine("Failed to send email to " + ex.InnerExceptions[i].FailedRecipient);
            //        }
            //    }
            //    return true;
            //}
            catch (Exception ex)
            {
                Debug.WriteLine("Error while sending: " +
                        ex.ToString());
                return false;
            }
        }
    }
}
