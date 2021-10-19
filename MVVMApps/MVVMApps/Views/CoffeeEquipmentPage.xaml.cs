using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        public CoffeeEquipmentPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        int count = 0;
        private string countDisplay= "Click Me"; 
        public string CountDisplay
        {
            get { return countDisplay; }
            set {
                if (value == countDisplay)
                    return;
                countDisplay = value;
                OnPropertyChanged();
            }
        }   

        private void btnCount_Clicked(object sender, EventArgs e)
        {
            count++;
            CountDisplay = $"Anda mengklik {count} kali";
        }
    }
}