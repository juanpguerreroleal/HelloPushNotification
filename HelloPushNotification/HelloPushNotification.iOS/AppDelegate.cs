using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Foundation;
using UIKit;

namespace HelloPushNotification.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();
            
            OneSignal.Current.StartInit("YOUR_ONESIGNAL_APP_ID").Settings(new Dictionary<string, bool>() {
                { IOSSettings.kOSSettingsKeyAutoPrompt, false },
                { IOSSettings.kOSSettingsKeyInAppLaunchURL, false } }).InFocusDisplaying(OSInFocusDisplayOption.Notification).EndInit();
    
            // The promptForPushNotificationsWithUserResponse function will show the iOS push notification prompt. We recommend removing the following code and instead using an In-App Message to prompt for notification permission (See step 7)
            OneSignal.Current.RegisterForPushNotifications();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
