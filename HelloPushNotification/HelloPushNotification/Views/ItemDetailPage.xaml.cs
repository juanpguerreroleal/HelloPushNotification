using System.ComponentModel;
using Xamarin.Forms;
using HelloPushNotification.ViewModels;

namespace HelloPushNotification.Views
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