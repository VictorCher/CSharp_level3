// Чернышов Виктор. Урок 3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmailSendServiceDLL;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            EmailSendService.listStrMails.Add(new Recipient {Name = "Василий", Address= "chernyshov_vv @elektro-shield.ru" });
            EmailSendService.listStrMails.Add(new Recipient { Name = "Алексей", Address = "dalinkevich_aa @elektro-shield.ru" });
            EmailSendService.nameServerNumberPort.Add("mail.elektro-shield.ru",25);
            EmailSendService.listSender.Add("service_s@elektro-shield.ru");
            
        }
        private void AddAddress_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService.listStrMails.Add(new Recipient {Name = "Noname", Address = ListAddress.Text });
        }
        private void DelAddress_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService.listStrMails.Remove(new Recipient {  Address = ListAddress.Text });
        }
        private void AddSender_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService.listSender.Add(senderBox.Text);
        }
        private void DelSender_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService.listSender.Remove(senderBox.Text);
        }
        
        private void sendNow_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            if (richText == "\r\n")
            {
                MessageBox.Show("Письмо не заполнено");
                return;
            }
            EmailSendService.Send(senderBox.Text, passwordBox.Password, ListServer.Text, richText);
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
