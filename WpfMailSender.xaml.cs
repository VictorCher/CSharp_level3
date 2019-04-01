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
        public WpfMailSender()
        {
            InitializeComponent();
            EmailSendService.listStrMails.Add("chernyshov_vv @elektro-shield.ru");
            EmailSendService.nameServerNumberPort.Add("mail.elektro-shield.ru",25);
            EmailSendService.listSender.Add("service_s@elektro-shield.ru");
            //ListAddress.ItemsSource = EmailSendService.listStrMails;
            //ListServer.ItemsSource = EmailSendService.nameServerNumberPort.Keys;
            //senderBox.ItemsSource = EmailSendService.listSender;
            
        }
        private void AddAddress_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService.listStrMails.Add(ListAddress.Text);
        }
        private void DelAddress_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService.listStrMails.Remove(ListAddress.Text);
        }
        private void AddSender_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService.listSender.Add(ListAddress.Text);
        }
        private void DelSender_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService.listSender.Remove(ListAddress.Text);
        }

        private void sendNow_Click(object sender, RoutedEventArgs e)
        {
            EmailSendService.Send(senderBox.Text, passwordBox.Password, ListServer.Text);
        }
    }
}
