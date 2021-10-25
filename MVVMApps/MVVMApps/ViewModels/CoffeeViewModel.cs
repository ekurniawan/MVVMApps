using MVVMApps.Services;
using MVVMApps.Shared.Models;
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

        private CoffeeService coffeeService;

        public CoffeeViewModel()
        {
            Title = "List Of Coffee";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
            SelectCommand = new AsyncCommand<object>(Selected);

            coffeeService = new CoffeeService();
        }

        private Task Remove(Coffee arg)
        {
            throw new NotImplementedException();
        }

        private Task Selected(object arg)
        {
            throw new NotImplementedException();
        }

        private Task Add()
        {
            throw new NotImplementedException();
        }

        private async Task Refresh()
        {
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Keterangan",
                    "Tidak ada koneksi internet","OK");
            }
            IsBusy = true;
            Coffee.Clear();
            var result = await coffeeService.GetCoffee();
            Coffee.AddRange(result);
            IsBusy = false;
        }
    }
}
