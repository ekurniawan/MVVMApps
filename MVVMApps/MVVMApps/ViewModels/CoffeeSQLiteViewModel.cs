using MVVMApps.Services;
using MVVMApps.Shared.Models;
using MVVMApps.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMApps.ViewModels
{
    public class CoffeeSQLiteViewModel : ViewModelBase
    {
        public  ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get;}
        public AsyncCommand<Coffee> RemoveCommand { get; }
        public AsyncCommand<object> SelectCommand { get; set; }
        public AsyncCommand SyncCommand { get; set; }

        public CoffeeSQLiteViewModel()
        {
            Title = "Coffee SQLite";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
            SelectCommand = new AsyncCommand<object>(Selected);
            SyncCommand = new AsyncCommand(Sync);
        }

        private async Task Sync()
        {
            await CoffeeSQLiteService.AddSyncData();
            await Application.Current.MainPage.DisplayAlert("Keterangan", "Sync Data Berhasil", "OK");
        }

        private async Task Selected(object arg)
        {
            var coffee = arg as Coffee;
            if (coffee == null)
                return;
            var route = $"{nameof(DetailCoffeePageSQLite)}?CoffeeId={coffee.Id}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Remove(Coffee coffee)
        {
            await CoffeeSQLiteService.RemoveCoffee(coffee.Id);
            await App.Current.MainPage.DisplayAlert("Keterangan", $"Coffee {coffee.Name} berhasil didelete", "OK");
            await Refresh();
        }

        private async Task Add()
        {
            //var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Coffee Name");
            //var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Coffee Roaster");
            /*try
            {
                var newCoffee = new Coffee
                {
                    Name = name,
                    Roaster = roaster
                };
                await CoffeeSQLiteService.AddCoffee(newCoffee);
                await App.Current.MainPage.DisplayAlert("Keterangan", 
                    "Data Berhasil Ditambah", "OK");
                await Refresh();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Keterangan",
                    $"Error: {ex.Message}", "OK");
            }*/

            var route = $"{nameof(AddCofeePageSQLite)}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Refresh()
        {
            IsBusy = true;
            Coffee.Clear();
            var results = await CoffeeSQLiteService.GetCoffee();
            Coffee.AddRange(results);
            IsBusy = false;
        }
    }
}
