using MVVMApps.Shared.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMApps.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string,Coffee>> CoffeeGroups { get; set; }

        public AsyncCommand RefreshCommand { get; }

        public CoffeeEquipmentViewModel()
        {
            Title = "List Of Coffee";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";

            Coffee.Add(new Coffee { Roaster = "Dark Roasted", Name = "Italian Roast", Image = image });
            Coffee.Add(new Coffee { Roaster = "Medium Roasted", Name = "Columbia Roast", Image = image });
            Coffee.Add(new Coffee { Roaster = "Medium Roasted", Name = "Toraja Peaberry", Image = image });
            Coffee.Add(new Coffee { Roaster = "Dark Roasted", Name = "Tiwus", Image = image });
            Coffee.Add(new Coffee { Roaster = "Medium Roasted", Name = "Pike Market Roast", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Medium Roasted",Coffee.Where(c=>c.Roaster== "Medium Roasted")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Dark Roasted", Coffee.Where(c=>c.Roaster== "Dark Roasted")));

            RefreshCommand = new AsyncCommand(Refresh);
        }

        private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
