using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using LuckyBeer;

namespace LuckyBeer.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            SetTabBarStyle();

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private static void SetTabBarStyle()
        {
            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

            UIColor uIColor = UIColor.Black;

            UITabBar.Appearance.TintColor = uIColor;
            UINavigationBar.Appearance.BarTintColor = uIColor;
            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes
            {
                ForegroundColor = UIColor.White
            };
            UIBarButtonItem.Appearance.TintColor = UIColor.White;
        }
    }
}
