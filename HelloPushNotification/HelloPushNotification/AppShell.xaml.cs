using System;
using System.Collections.Generic;
using HelloPushNotification.ViewModels;
using HelloPushNotification.Views;
using Xamarin.Forms;

namespace HelloPushNotification
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
