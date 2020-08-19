using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HelloPushNotification.Services;
using HelloPushNotification.Views;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using System.Collections.Generic;
using HelloPushNotification.ViewModels;
using System.Linq;

namespace HelloPushNotification
{
    public partial class App : Application
    {
        private static string TransferId { get; set; }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            OneSignal.Current.StartInit("YOUR_ONESIGNAL_APP_ID").Settings(new Dictionary<string, bool>() {
                    { IOSSettings.kOSSettingsKeyAutoPrompt, false },
                    { IOSSettings.kOSSettingsKeyInAppLaunchURL, false } }).HandleNotificationOpened(HandleNotificationOpened).InFocusDisplaying(OSInFocusDisplayOption.Notification).EndInit();

            // The promptForPushNotificationsWithUserResponse function will show the iOS push notification prompt. We recommend removing the following code and instead using an In-App Message to prompt for notification permission (See step 7)
            OneSignal.Current.RegisterForPushNotifications();

        }

        protected async override void OnStart()
        {
            if (AnyTransferId())
            {
                await Shell.Current.GoToAsync($"{nameof(TransferItemDetailPage)}?{nameof(TransferItemViewModel.Id)}={TransferId}");
                TransferId = "";
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            
        }
        private static async void HandleNotificationOpened(OSNotificationOpenedResult result)
        {
            OSNotificationPayload payload = result.notification.payload;
            Dictionary<string, object> additionalData = payload.additionalData;
            string message = payload.body;
            string actionID = result.action.actionID;

            if (additionalData != null)
            {
                if (additionalData.ContainsKey("TransferId"))
                {
                    TransferId = additionalData.FirstOrDefault(x => x.Key == "TransferId").Value.ToString();
                    await Shell.Current.GoToAsync($"{nameof(TransferItemDetailPage)}?{nameof(TransferItemViewModel.Id)}={TransferId}");
                }
            }
            if (actionID != null)
            {
                // actionSelected equals the id on the button the user pressed.
                // actionSelected will equal "__DEFAULT__" when the notification itself was tapped when buttons were present.
            }
        }
        public bool AnyTransferId()
        {
            return !string.IsNullOrEmpty(TransferId);
        }
        public static string GetTransferId()
        {
            return TransferId;
        }
    }
}
