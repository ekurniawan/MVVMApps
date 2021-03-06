using MVVMApps.ViewModels;
using MVVMApps.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MVVMApps
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddCofeePageSQLite), typeof(AddCofeePageSQLite));
            Routing.RegisterRoute(nameof(DetailCoffeePageSQLite), typeof(DetailCoffeePageSQLite));

            Routing.RegisterRoute(nameof(DetailCoffeePage), typeof(DetailCoffeePage));
            Routing.RegisterRoute(nameof(AddCoffeePage), typeof(AddCoffeePage));
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        /*private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }*/
    }
}
