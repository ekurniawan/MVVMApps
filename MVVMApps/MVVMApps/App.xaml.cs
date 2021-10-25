
using MVVMApps.Services;
using MVVMApps.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApps
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ICoffee, CoffeeService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
