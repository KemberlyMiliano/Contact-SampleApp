using ContactAppSample.Models;
using ContactAppSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactAppSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {
        public EditContactPage(ObservableCollection<Contact> contacts, Contact contactSelected)
        {
            InitializeComponent();
            BindingContext = new EditContactPageViewModel(contacts, contactSelected);
        }
    }
}