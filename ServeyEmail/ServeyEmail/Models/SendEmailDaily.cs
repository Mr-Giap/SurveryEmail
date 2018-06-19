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
            string dayofweek = DateTime.Now.DayOfWeek.ToString();
            if (dayofweek != "Sunday" || dayofweek != "Saturday")
            {
                UserBLL users = new UserBLL();
                var us = users.GetallUsers(); //lấy tất cả user

                foreach (var item in us)
                {
                    item.Checkmail = false; // trang thái về chưa gửi
                    users.Updatecheckmail(item, 0);  // update trang thái người dùng thành chưa gửi 
                    string ma = "" + item.IdUser;
                    string date = "" + DateTime.Now.Date;
                    string codema = Encrypt.sha1(ma); //mã hóa id
                    string codedate = Encrypt.sha1(date); // mã hóa date
                                                          //thêm content cho message
                    string content = "<p> Xin chào " + item.FullName + "</p><p> Bạn thấy ngày hôm này như thế nào? </p><p> Vui lòng chọn 1 loại cảm xúc </p>";
                    var st = new StatusBLL().Getall();
                    foreach (var i in st)
                    {
                        content += "<a href = \"http://pcmarket.somee.com/ReciveEmail/" + codema + "/" + i.IdStatus + "/" + codedate + "\">" + i.Name + "</a><br />";
                    }
                    //thêm message
                    MailMessage mes = setupmessage(content, "Hello", item.Email);
                    var client = setupclient();
                    sendmail(client, mes); // gọi hàm send
                }
            }
        }
        public void sendmail(SmtpClient client, MailMessage message)
        {
            client.Send(message); //send mail
        }
        public MailMessage setupmessage(string content, string subject, string toEmailAddress)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString(); //lấy địa chỉ mail ở web.config
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString(); //lên tên hiển thị ở webconfig

            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject; // tiêu đề mail
            message.IsBodyHtml = true; // cho phép sử dụng html
            message.Body = content; // thêm nội dung
            return message;
        }
        public SmtpClient setupclient()
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString(); //lấy địa chỉ mail ở web.config
            var fromEmailPassword = ""; // mật khẩu của maill
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString(); //cài đặt host
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString(); //cài đặt port
            bool enabledSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString()); //có bảo mật không

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword); // cài đặt client
            client.Host = smtpHost; //cài đặt host
            client.EnableSsl = enabledSsl; // cài đặt bảo bật
            client.Port = !string.IsNullOrEmpty(smtpHost) ? Convert.ToInt32(smtpPort) : 0; // cài đặt port. nếu port null thì sẽ để là 0
            return client;
        }
    }
}