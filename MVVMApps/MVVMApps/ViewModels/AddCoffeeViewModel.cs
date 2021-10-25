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
    public class AddCoffeeViewModel : ViewModelBase
    {
        public AsyncCommand SaveCommand { get; set; }

        private ICoffee coffeeService;
        public AddCoffeeViewModel()
        {
            Title = "Insert Coffee";
            SaveCommand = new AsyncCommand(Save);

            coffeeService = DependencyService.Get<ICoffee>();
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
                Roaster = roaster,
                Image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png"
            };

            await coffeeService.AddCoffee(newCoffee);
            await Shell.Current.GoToAsync("..");
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string roaster;
        public string Roaster
        {
            get { return roaster; }
            set { SetProperty(ref roaster, value); }
        }


    }
}
