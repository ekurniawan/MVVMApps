using MVVMApps.Shared.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMApps.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }

        public AsyncCommand RefreshCommand { get; }

        public CoffeeEquipmentViewModel()
        {
            Title = "List Of Coffee";
            Coffee = new ObservableRangeCollection<Coffee>();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";

            Coffee.Add(new Coffee { Roaster = "Dark Roasted", Name = "Italian Roast", Image = image });
            Coffee.Add(new Coffee { Roaster = "Medium Roasted", Name = "Columbia Roast", Image = image });
            Coffee.Add(new Coffee { Roaster = "Light Roasted", Name = "Toraja Peaberry", Image = image });
            Coffee.Add(new Coffee { Roaster = "Dark Roasted", Name = "Tiwus", Image = image });
            Coffee.Add(new Coffee { Roaster = "Medium Roasted", Name = "Pike Market Roast", Image = image });

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
