using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MailSender
{
    class EmailSendService
    {
        public static List<string> listStrMails { get; set; } = new List<string>();
        public static List<string> listSender { get; set; } = new List<string>();
        public static List<string> nameServer { get; set; } = new List<string>();
        /*public EmailSendService()
        {
            listStrMails = new List<string>{ "email@yandex.ru" }; // Список email'ов //кому мы отправляем письмо
            //string strPassword = WpfMailSender.password ; // для WinForms - string strPassword = passwordBox.Text;
            nameServerNumberPort.Add("mail.elektro-shield.ru", 25);
        }*/

        public static void Send(string strSender, string strPassword, string strServer)
        {
            foreach (string mail in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage(strSender, mail))
                {
                    // Формируем письмо
                    mm.Subject = "Привет из C#"; // Заголовок письма
                    mm.Body = "Hello, world!"; // Тело письма
                    mm.IsBodyHtml = false; // Не используем html в теле письма
                    // Авторизуемся на smtp-сервере и отправляем письмо
                    // Оператор using гарантирует вызов метода Dispose, даже если при вызове
                    // методов в объекте происходит исключение.
                    using (SmtpClient sc = new SmtpClient(strServer, 25))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(strSender, strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                } //using (MailMessage mm = new MailMessage("sender@yandex.ru", mail))
            }
            MessageBox.Show("Работа завершена.");
        }
    }
}
