// Чернышов Виктор. Урок 1

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

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public static string password { get; set; }
        //EmailSendService mailService;
        public WpfMailSender()
        {
            InitializeComponent();
            //mailService = new EmailSendService();
            EmailSendService.listStrMails.Add("chernyshov_vv @elektro-shield.ru");
            EmailSendService.nameServer.Add("mail.elektro-shield.ru");
            EmailSendService.listSender.Add("service_s@elektro-shield.ru");
            ListAddress.ItemsSource = EmailSendService.listStrMails;
            ListServer.ItemsSource = EmailSendService.nameServer;
            senderBox.ItemsSource = EmailSendService.listSender;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            EmailSendService.Send(senderBox.Text, passwordBox.Password, ListServer.Text);
        }
    }
}
