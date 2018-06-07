using FFImageLoading.Forms.Touch;
using Foundation;
using Microsoft.Identity.Client;
using Naxam.I18n;
using Naxam.I18n.Forms;
using Naxam.I18n.iOS;
using System;
using System.Collections.Generic;
using UIKit;
using Mobile.iOS.Views;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms;


namespace Mobile.iOS
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
			try
			{
				HtmlLabelRenderer.Initialize();
				global::Xamarin.Forms.Forms.Init();
				FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
				FormsPlugin.Iconize.iOS.IconControls.Init();

				Xamarin.Forms.DependencyService.Register<IDependencyGetter, DepenencyGetter>();
				//UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
				//if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
				//{
				//    statusBar.BackgroundColor = new Color(206, 30, 33).ToUIColor();
				//}
				var statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
				if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
				{
					statusBar.BackgroundColor = Color.FromHex("#ce1e21").ToUIColor(); ;
					UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.Default;
					statusBar.TintColor = UIColor.White;
				}


				UITabBar.Appearance.SelectedImageTintColor = Color.FromHex("#ce1e21").ToUIColor();
				UITabBarItem.Appearance.SetTitleTextAttributes(
					new UITextAttributes()
					{
						TextColor = Color.FromHex("#ce1e21").ToUIColor()
					},
					UIControlState.Selected);
				//UINavigationBar.Appearance.BarTintColor = UIColor.Blue;
				LoadApplication(new App());

				var result = base.FinishedLaunching(app, options);
				App.AuthenticationClient.PlatformParameters = new PlatformParameters(UIApplication.SharedApplication.KeyWindow.RootViewController);


				return result;
			}catch(Exception ex){
				Console.WriteLine(ex.Source);
				return base.FinishedLaunching(app, options);
			}
        }
        void SetupBottomTabs()
        {
        }
		public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            NSTimer timer = NSTimer.CreateRepeatingTimer(interval, t =>
            {
                if (!callback())
                    t.Invalidate();
            });
            NSRunLoop.Main.AddTimer(timer, NSRunLoopMode.Common);
        }
    }

    public class DepenencyGetter : IDependencyGetter
    {
        readonly Dictionary<Type, object> cache;
        public DepenencyGetter()
        {
            ILocalizer localizer = new Localizer();
            cache = new Dictionary<Type, object> {
                {
                    typeof(ILocalizer),
                    localizer
                },
                {
                    typeof(ILocalizedResourceProvider),
                    new LocalizedResourceProvider(localizer, App.ResManager)
                }
            };
        }

        public T Get<T>()
        {
            return (T)cache[typeof(T)];
        }
    }
}
