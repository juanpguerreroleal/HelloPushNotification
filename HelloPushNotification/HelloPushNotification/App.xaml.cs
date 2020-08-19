using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HelloPushNotification.Services;
using HelloPushNotification.Views;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using System.Collections.Generic;

namespace HelloPushNotification
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            OneSignal.Current.StartInit("YOUR_ONESIGNAL_APP_ID").Settings(new Dictionary<string, bool>() {
                    { IOSSettings.kOSSettingsKeyAutoPrompt, false },
                    { IOSSettings.kOSSettingsKeyInAppLaunchURL, false } }).InFocusDisplaying(OSInFocusDisplayOption.Notification).EndInit();

            // The promptForPushNotificationsWithUserResponse function will show the iOS push notification prompt. We recommend removing the following code and instead using an In-App Message to prompt for notification permission (See step 7)
            OneSignal.Current.RegisterForPushNotifications();

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
