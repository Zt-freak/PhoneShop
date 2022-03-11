using PhoneShop.Xamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PhoneShop.Xamarin.Views
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