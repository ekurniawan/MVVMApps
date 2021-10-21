using MVVMApps.Services;
using MVVMApps.Shared.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApps.ViewModels
{
    public class CoffeeSQLiteViewModel : ViewModelBase
    {
        public  ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get;}
        public AsyncCommand<Coffee> RemoveCommand { get; }
        public AsyncCommand<object> SelectCommand { get; set; }

        public CoffeeSQLiteViewModel()
        {
            Title = "Coffee SQLite";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
            SelectCommand = new AsyncCommand<object>(Selected);
        }

        private Task Selected(object arg)
        {
            throw new NotImplementedException();
        }

        private Task Remove(Coffee arg)
        {
            throw new NotImplementedException();
        }

        private Task Add()
        {
            throw new NotImplementedException();
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
