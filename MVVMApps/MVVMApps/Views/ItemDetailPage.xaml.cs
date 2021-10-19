using MVVMApps.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MVVMApps.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}