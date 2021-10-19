using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMApps.ViewModels
{
    public class CoffeeEquipmentViewModel : BindableObject
    {
        public ICommand IncreaseCount { get; }
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
        }

        int count = 0;
        private string countDisplay = "Click Me";
        public string CountDisplay
        {
            get { return countDisplay; }
            set
            {
                if (value == countDisplay)
                    return;
                countDisplay = value;
                OnPropertyChanged();
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set {
                if (value == FirstName)
                    return;
                firstName = value;
                OnPropertyChanged();
            }
        }

        private void OnIncrease()
        {
            count++;
            CountDisplay = $"Anda mengklik {count} kali";
        }
    }
}
