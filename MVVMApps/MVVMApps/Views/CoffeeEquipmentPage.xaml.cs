using MVVMApps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        public CoffeeEquipmentPage()
        {
            InitializeComponent();
        }

        /*private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var result = ((MenuItem)sender).BindingContext as Coffee;
            if (result == null)
                return;

            await DisplayAlert("Favorite Coffee",result.Name,"OK");
        }*/
    }
}