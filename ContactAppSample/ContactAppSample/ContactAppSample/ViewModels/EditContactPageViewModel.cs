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
    public class EditContactPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OnEditButtonCommand { get; set; }
        public Contact EditableContact { get; set; }

        public EditContactPageViewModel(ObservableCollection<Contact> Contacts, Contact ContactSelected)
        {
            EditableContact = ContactSelected;

            OnEditButtonCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }


    }
}
