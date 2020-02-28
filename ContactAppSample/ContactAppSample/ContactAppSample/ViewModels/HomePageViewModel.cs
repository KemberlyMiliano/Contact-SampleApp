using ContactAppSample.Models;
using ContactAppSample.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ContactAppSample.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand GoToNewContactPageCommand { get; set; }
        public ICommand OnDeleteCommand { get; set; }
        public ICommand OnMoreCommand { get; set; }

        public const string Cancel = "Cancel";
        public const string Call = "Call";
        public const string Edit = "Edit";
        public const string NullConstant = null;

        private Contact contactSelected;
        public Contact ContactSelected
        {
            get { return this.contactSelected; }
            set
            {
                this.contactSelected = value;
            }
        }
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public HomePageViewModel()
        {
            GoToNewContactPageCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NewContactPage(Contacts, ContactSelected));
            });

            OnDeleteCommand = new Command<Contact>((param) =>
            {
                Contacts.Remove(param);
            });

            OnMoreCommand = new Command<Contact>(async (param) =>
            {
                string action = await App.Current.MainPage.DisplayActionSheet(NullConstant, Cancel, NullConstant, Call, Edit);
                switch (action)
                {
                    case Cancel:
                        break;

                    case Call:
                        PlacePhoneCall(param.Number);
                        break;

                    case Edit:
                        if (contactSelected != null)
                            await App.Current.MainPage.Navigation.PushAsync(new EditContactPage(Contacts, ContactSelected));
                        break;
                }
            });

        }

        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }

            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        async void ProcessException(Exception ex)
        {
            if (ex != null)
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
