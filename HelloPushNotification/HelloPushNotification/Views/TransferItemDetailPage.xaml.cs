using HelloPushNotification.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloPushNotification.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferItemDetailPage : ContentPage
    {
        public TransferItemDetailViewModel _viewModel;
        public TransferItemDetailPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TransferItemDetailViewModel();
        }
    }
}