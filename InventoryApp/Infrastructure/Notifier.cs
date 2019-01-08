using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Http;

namespace InventoryApp.Infrastructure
{
  /// <summary>
  /// Notifier class sends notification as mail
  /// </summary>
  public class Notifier
  {
  
    string host = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"];
    string fromAddress = System.Configuration.ConfigurationManager.AppSettings["SmtpEmail"];
    string fromPass = System.Configuration.ConfigurationManager.AppSettings["SmtpPass"];
    int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]);
    bool mailSend = false;
    SmtpClient smtpClient;
    /// <summary>
    /// 
    /// </summary>
    public Notifier()
    {
      smtpClient = new SmtpClient();
    }
    /// <summary>
    /// Send Notification
    /// </summary>
    /// <param name="sendTo">Receivers email Id</param>
    /// <param name="subject">Subject of Notification</param>
    /// <param name="messageBody">Email Content</param>
    /// <returns>true or false</returns>
    public bool SendEmail(string sendTo, string subject, string messageBody)
    {
      MailAddress from = new MailAddress(fromAddress, "Anjali Sahu", System.Text.Encoding.UTF8);
      MailAddress to = new MailAddress(sendTo);
      MailMessage mailMessage = new MailMessage(from, to);
      mailMessage.Body = messageBody;
      mailMessage.Subject = subject;
      smtpClient.Host = host;
      //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
      smtpClient.EnableSsl = true;
      smtpClient.Credentials = new System.Net.NetworkCredential()
      {
        UserName = fromAddress,
        Password = fromPass
      };
      smtpClient.Port = port;
      //smtpClient.UseDefaultCredentials = false;
      smtpClient.Send(mailMessage);
      smtpClient.SendCompleted += SmtpClient_SendCompleted;

      return mailSend;
    }

    private void SmtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
      var state = (string)e.UserState;
      if (e.Cancelled)
      {
        mailSend = false;
        Console.WriteLine(string.Format("{0} Send Cancelled",state));
      }
      else if (e.Error!=null)
      {
        mailSend = false;
        Console.WriteLine(string.Format("{0} Send Cancelled Error", state,e.Error.ToString()));
      }
      else 
      {
        mailSend = true;
      }
    }
  }
}
