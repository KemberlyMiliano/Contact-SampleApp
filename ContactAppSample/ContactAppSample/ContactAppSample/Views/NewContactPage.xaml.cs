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
    public partial class NewContactPage : ContentPage
    {
        public NewContactPage(ObservableCollection<Contact> Contacts, Contact ContactSelected)
        {
            InitializeComponent();
            BindingContext = new AddEditContactPageViewModel(Contacts, ContactSelected);
        }
    }
}