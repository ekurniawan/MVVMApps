using MVVMApps.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApps.ViewModels
{
    public class DetailCoffeeViewModel : ViewModelBase
    {
        public string CoffeeId { get; set; }
        public AsyncCommand RefreshCommand { get; set; }
        public AsyncCommand DoneCommand { get; set; }

        private CoffeeService coffeeService;
        public DetailCoffeeViewModel()
        {
            Title = "Detail Coffee";
            RefreshCommand = new AsyncCommand(Refresh);
            DoneCommand = new AsyncCommand(Done);

            coffeeService = new CoffeeService();
        }

        private Task Done()
        {
            throw new NotImplementedException();
        }

        private async Task Refresh()
        {
            int.TryParse(CoffeeId, out var result);
            var coffee = await coffeeService.GetCofeeById(result);

            
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }


    }
}
