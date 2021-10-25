using MVVMApps.Services;
using MVVMApps.Shared.Models;
using MVVMApps.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MVVMApps.ViewModels
{
    public class CoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; set; }
        public AsyncCommand AddCommand { get; set; }
        public AsyncCommand<Coffee> RemoveCommand { get; set; }
        public AsyncCommand<object> SelectCommand { get; set; }

        private ICoffee coffeeService;

        public CoffeeViewModel()
        {
            Title = "List Of Coffee";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
            SelectCommand = new AsyncCommand<object>(Selected);

            coffeeService = DependencyService.Get<ICoffee>();
        }

        private async Task Remove(Coffee coffee)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Konfirmasi", $"Apakah data coffee {coffee.Name} yakin di delete?", "OK", "Cancel");
            if (result)
            {
                await coffeeService.RemoveCoffee(coffee.Id);
                await Refresh();
            }
        }

        private async Task Selected(object arg)
        {
            var coffee = arg as Coffee;
            if (coffee == null)
                return;
            var route = $"{nameof(DetailCoffeePage)}?CoffeeId={coffee.Id}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Add()
        {
            var route = $"{nameof(AddCoffeePage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Refresh()
        {
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                /*await Application.Current.MainPage.DisplayAlert("Keterangan",
                    "Tidak ada koneksi internet","OK");*/

            }
            
            IsBusy = true;
            await Task.Delay(1000);
            Coffee.Clear();
            var result = await coffeeService.GetCoffee();
            Coffee.AddRange(result);
            
            IsBusy = false;
        }
    }
}
