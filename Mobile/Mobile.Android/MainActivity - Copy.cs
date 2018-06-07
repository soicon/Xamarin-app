using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Microsoft.Identity.Client;
using Naxam.Controls.Platform.Droid;
using Naxam.I18n;
using Naxam.I18n.Droid;
using Naxam.I18n.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mobile.Droid
{
    [Activity(Label = "Mobile", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            SetupBottomTabs();
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.Forms.DependencyService.Register<IDependencyGetter, DepenencyGetter>();
            LoadApplication(new App());
            Window.SetStatusBarColor(new Color(206, 30, 33));
            App.AuthenticationClient.PlatformParameters = new PlatformParameters(this);
            //Android.Support.V7.Widget.Toolbar toolbar
            //    = this.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);

        }
        void SetupBottomTabs()
        {
            var stateList = new Android.Content.Res.ColorStateList(
                new int[][] {
                    new int[] { Android.Resource.Attribute.StateChecked
                },
                new int[] { Android.Resource.Attribute.StateEnabled
                }
                },
                new int[] {
                    Color.Red, //Selected
                    Color.Gray //Normal
                });
            BottomTabbedRenderer.VisibleTitle = true;
            //BottomTabbedRenderer.BackgroundColor = new Color(0x9C, 0x27, 0xB0);
            BottomTabbedRenderer.BackgroundColor = new Color(255, 255, 255);
            BottomTabbedRenderer.FontSize = 13f;
            BottomTabbedRenderer.IconSize = 24;
            BottomTabbedRenderer.ItemTextColor = stateList;
            BottomTabbedRenderer.ItemIconTintList = stateList;
            BottomTabbedRenderer.Typeface = Typeface.CreateFromAsset(this.Assets, "HelveticaNeue.ttf");
            BottomTabbedRenderer.ItemBackgroundResource = Resource.Drawable.abc_list_selector_background_transition_holo_light;
            BottomTabbedRenderer.ItemSpacing = 4;
            BottomTabbedRenderer.ItemPadding = new Xamarin.Forms.Thickness(6);
            BottomTabbedRenderer.BottomBarHeight = 56;
            BottomTabbedRenderer.ItemAlign = ItemAlignFlags.Center;
            BottomTabbedRenderer.MenuItemIconSetter = (menuItem, iconSource, selected) =>
            {
                var resId = Resources.GetIdentifier(iconSource.File, "drawable", PackageName);
                switch (iconSource.File)
                {
                    case "ic_audiotrack_black_24dp":
                        menuItem.SetIcon(Resource.Drawable.u81);
                        break;
                    case "ic_backup_black_24dp":
                        menuItem.SetIcon(Resource.Drawable.u75);
                        break;
                    case "ic_camera_black_24dp":
                        menuItem.SetIcon(Resource.Drawable.u143);
                        break;
                    case "ic_favorite_black_24dp":
                        menuItem.SetIcon(Resource.Drawable.More);
                        break;
                    case "ic_audiotrack_black_25dp":
                        menuItem.SetIcon(Resource.Drawable.report);
                        break;
                    case "ic_camera_black_26dp":
                        menuItem.SetIcon(Resource.Drawable.Contact);
                        break;
                    default:
                        menuItem.SetIcon(resId);
                        break;
                }

            };
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(requestCode, resultCode, data);
        }
        public override void OnBackPressed()
        {
            //try
            //{
            //    var currentpage = (CoolContentPage)Xamarin.Forms.Application.Current.
            //    MainPage.Navigation.NavigationStack.LastOrDefault();
            //    if (currentpage?.CustomBackButtonAction != null)
            //    {
            //        currentpage?.CustomBackButtonAction.Invoke();
            //    }
            //    else
            //    {
            //        base.OnBackPressed();
            //    }
            //}
            //catch
            //{
            base.OnBackPressed();
            //}
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // check if the current item id 
            // is equals to the back button id
            if (item.ItemId == 16908332) // xam forms nav bar back button id
            {
                base.OnBackPressed();
                try
                {
                    var currentpage = (CoolContentPage)Xamarin.Forms.Application.Current.
                     MainPage.Navigation.NavigationStack.LastOrDefault();
                    if (currentpage?.CustomBackButtonAction != null)
                    {
                        currentpage?.CustomBackButtonAction.Invoke();
                        return false;
                    }

                }
                catch
                {
                    var currentpage = (Xamarin.Forms.ContentPage)Xamarin.Forms.Application.Current.
                     MainPage.Navigation.NavigationStack.LastOrDefault();
                    switch (currentpage.GetType().Name)
                    {
                        case "Report":
                            App.bottomTabbedPage.CurrentPage = App.ReportForm;
                            break;
                        case "ContactDetail":
                            App.bottomTabbedPage.CurrentPage = App.ReportForm;
                            break;
                        case "CreateNew":
                        case "CreateNew":
                            App.bottomTabbedPage.CurrentPage = App.ReportForm;
                            break;
                        default:
                            currentpage.Navigation.PopAsync();
                            break;
                    }
                    return base.OnOptionsItemSelected(item);
                }
                return true;
                //return base.OnOptionsItemSelected(item);
            }
            else
            {
                // since its not the back button 
                //click, pass the event to the base
                return base.OnOptionsItemSelected(item);
            }
        }
        public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            var handler = new Handler(Looper.MainLooper);
            handler.PostDelayed(() =>
            {
                if (callback())
                    StartTimer(interval, callback);

                handler.Dispose();
                handler = null;
            }, (long)interval.TotalMilliseconds);
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

