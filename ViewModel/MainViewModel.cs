using GalaSoft.MvvmLight;
using EmailSendServiceDLL;
using System.Collections.ObjectModel;


namespace MailSender.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        //string _Title = "Рассыльщик почты";
        public string Title { get; set; } = "Рассыльщик почты";

        public string NameRecipient { get; set; }

        public string AddressRecipient {
            get
            {
                Recipient temp = new Recipient() { Name = "", Address = "Адрес не выбран" };
                foreach (var i in EmailSendService.listStrMails)
                {
                    if (i.Name == NameRecipient)
                    {
                        temp.Address = i.Address;
                    }
                }
                return temp.Address;
            }
            set { AddressRecipient = value; } }
        /*{
            get { return Title; }
            set { _Title = value; }
        }*/
    }
}