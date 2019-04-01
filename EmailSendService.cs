﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Collections.ObjectModel;

namespace MailSender
{
    class EmailSendService
    {
        public static ObservableCollection<string> listStrMails { get; set; } = new ObservableCollection<string>();
        public static ObservableCollection<string> listSender { get; set; } = new ObservableCollection<string>();
        public static Dictionary<string, int> nameServerNumberPort { get; set; } = new Dictionary<string, int>();
        
        public static void Send(string strSender, string strPassword, string strServer, string msg)
        {
            foreach (string mail in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage(strSender, mail))
                {
                    // Формируем письмо
                    mm.Subject = "Рассылка C#"; // Заголовок письма
                    mm.Body = msg; // Тело письма
                    mm.IsBodyHtml = false; // Не используем html в теле письма
                    // Авторизуемся на smtp-сервере и отправляем письмо
                    // Оператор using гарантирует вызов метода Dispose, даже если при вызове
                    // методов в объекте происходит исключение.
                    int numberPort;
                    nameServerNumberPort.TryGetValue(strServer, out numberPort);
                    using (SmtpClient sc = new SmtpClient(strServer, numberPort))
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
                } 
            }
            MessageBox.Show("Работа завершена.");
        }
    }
}
