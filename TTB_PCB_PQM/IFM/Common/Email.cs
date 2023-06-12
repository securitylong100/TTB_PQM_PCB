using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace IFM.Common
{
    public class Email
    {
        private void EmailPayGetMoney(string name, string toemail, string datetime, string filename)
        {
            string SendMailFrom = "ifm_sales@ifmsolutionsvn.com";
            string SendMailTo = toemail;
            string ccMail = "info@ifmsolutionsvn.com";
            string SendMailSubject = "PayGetMoney " + datetime + "";
            string htmlString = @"Dear  

                 Cảm ơn vì Bạn đã làm việc chăm chỉ!
                 Bạn " + name + @" Vừa thực Hiện Xuất Thu Chi với Nôi Dung Dưới
                 Xin hãy xem file đính kèm.
                 Vì đây là email tự động, xin hãy kiểm tra file đính kèm và liên hệ với phòng nhân sự qua email: long.thanhle@ifmsolutionsvn.com
                    
              Xin cảm ơn.
                    ---HR-IFM---
              IFM SOLUTIONS., Ltd 
              Mobile: +84 869 123 964| E-mail: info@ifmsolutionsvn.com
              Address: 30/11 Hoang Huu Nam, Long Thanh My, Thu Duc City, Ho Chi Minh City.
              Website: http://ifmsolutionsvn.com
                    ---Thank---

                     ";
            string SendMailBody = htmlString;
            try
            {
                SmtpClient SmtpServer = new SmtpClient("mail93156.maychuemail.com", 25);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage email = new MailMessage();
                // START
                email.From = new MailAddress(SendMailFrom);
                email.To.Add(SendMailTo);
                email.CC.Add(ccMail);
                email.Subject = SendMailSubject;
                email.Body = SendMailBody;
                var attachment = new Attachment(@"E:\C#\Salary Monthly\" + filename);
                email.Attachments.Add(attachment);
                //END
                SmtpServer.Timeout = 10000;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "longifm@123");
                SmtpServer.Send(email);

                MessageBox.Show("Sent Email", "Sending Email");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
    }
}
