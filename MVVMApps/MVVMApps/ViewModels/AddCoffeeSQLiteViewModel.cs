using MVVMApps.Services;
using MVVMApps.Shared.Models;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMApps.ViewModels
{
    public class AddCoffeeSQLiteViewModel : ViewModelBase
    {
        public AsyncCommand SaveCommand { get; set; }
        public AddCoffeeSQLiteViewModel()
        {
            Title = "Add Coffee SQL";
            SaveCommand = new AsyncCommand(Save);
        }

        private async Task Save()
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(roaster))
            {
                return;
            }

            var newCoffee = new Coffee
            {
                Name = name,
                Roaster = roaster
            };
            await CoffeeSQLiteService.AddCoffee(newCoffee);
            await Shell.Current.GoToAsync("..");
        }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }


        private string roaster;
        public string Roaster
        {
            get => roaster;
            set => SetProperty(ref roaster, value);
        }


    }
}
