using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quartz;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using BusinessLogicLayer.BLL;
using BusinessLogicLayer;
using ValueObjects;

namespace ServeyEmail.Models
{
    public class SendEmailDaily : IJob
    {
        public void Execute(IJobExecutionContext context)

        {
            UserBLL users = new UserBLL();
            var us = users.GetallUsers();
            foreach (var item in us)
            {
                //string content = System.IO.File.ReadAllText(Sever.MapPath("~/Template/sendmail.html"));
                string ma = ""+item.IdUser;
                string date = ""+DateTime.Now.Date;
                string codema = MAHOA.sha1(ma);
                string codedate = MAHOA.sha1(date);

                string content = "<p> Xin chào "+item.FullName+"</p><p> Bạn thấy ngày hôm này như thế nào? </p><p> Vui lòng chọn 1 loại cảm xúc </p><a href = \"http://localhost:53676/ReciveEmail/" + codema + "/1/"+codedate+"\"> Sad </a><br /><a href =\"http://localhost:53676/ReciveEmail/" + codema + "/2/" + codedate + "\"> Fun </a><br /><a href = \"http://localhost:53676/ReciveEmail/" + codema + "/3/" + codedate + "\"> Angry </a>";
                //content = content.Replace("{{Email}}", item.Email);
                //content = content.Replace("{{Fullname}}", item.FullName);
                //content = content.Replace("{{code}}",encode);

                MailMessage mes = setupmessage(content, "Hello", "nguyenthaigiap95@gmail.com");
                var client = setupclient();
                sendmail(client, mes);
            }

        }
        public void sendmail(SmtpClient client, MailMessage message)
        {
            client.Send(message);
        }
        public MailMessage setupmessage(string content, string subject, string toEmailAddress)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = content;
            return message;
        }
        public SmtpClient setupclient()
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailPassword = "matkhau1995";
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            bool enabledSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(smtpHost) ? Convert.ToInt32(smtpPort) : 0;
            return client;
        }
    }
}