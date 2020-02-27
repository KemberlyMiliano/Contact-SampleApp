using ContactAppSample.Models;
using ContactAppSample.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactAppSample.ViewModels
{
    public class NewContactPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Contact NewContact { get; set; } = new Contact();
        public ICommand OnAddButtonCommand { get; set; }

        public ObservableCollection<Contact> _contacts { get; set; } = new ObservableCollection<Contact>();

        public NewContactPageViewModel(ObservableCollection<Contact> Contacts)
        {
            _contacts = Contacts;

            OnAddButtonCommand = new Command(async () =>
            {
                _contacts.Add(NewContact);
                await App.Current.MainPage.Navigation.PopToRootAsync();
            });

        }
    }
}
