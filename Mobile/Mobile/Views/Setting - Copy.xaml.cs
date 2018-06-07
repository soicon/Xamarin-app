using Mobile.Views.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Setting : ContentPage
    {
        public Setting()
        {
            InitializeComponent();
            Title = App.localizeResProvider.GetText("Settings");
            txtUserName.Text = App.user.Name;
            App.localizer.SetLocale(App.defaultCulture);
            if (App.localizer.GetCurrentCultureInfo().Name.Equals("en"))
            {
                txtLanguage.Text = App.localizeResProvider.GetText("English");
            }
            else
            {
                txtLanguage.Text = App.localizeResProvider.GetText("Vietnamese");
            }
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            var icons = Plugin.Iconize.Iconize.Modules.FirstOrDefault()?.Keys.Take(5) ?? new string[0];
            App.bottomTabbedPage.Children.Add(new Language() { Icon = icons.Skip(3).FirstOrDefault() ?? "ic_favorite_black_24dp", Title = App.localizeResProvider.GetText("Settings") });
        }
        public async void LogoutTapped(object sender, EventArgs args)
        {
            App.AuthenticationClient.UserTokenCache.Clear(Constants.ApplicationID);
            App.user = null;
            App.token = null;
            App.tokenAuth = null;
            App.userId = "";
            await DisplayAlert("Thông báo", "Đăng xuất thành công", "Ok");
            var icons = Plugin.Iconize.Iconize.Modules.FirstOrDefault()?.Keys.Take(5) ?? new string[0];
            App.bottomTabbedPage.Children.RemoveAt(App.bottomTabbedPage.Children.Count - 1);
            App.bottomTabbedPage.Children.RemoveAt(App.bottomTabbedPage.Children.Count - 2);
            App.bottomTabbedPage.Children.RemoveAt(App.bottomTabbedPage.Children.Count - 3);
            App.bottomTabbedPage.Children.Add(new Views.Login() { Icon = icons.Skip(3).FirstOrDefault() ?? "ic_favorite_black_24dp", Title = App.localizeResProvider.GetText("Settings") });
        }
        public async void ProfileTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Profile());
        }
        public async void LanguageTapped(object sender, EventArgs args)
        {
            if (App.localizer.GetCurrentCultureInfo().Name.Equals("en-US"))
            {
                var defaultCulture = App.localizer.GetCurrentCultureInfo();
                App.localizer.SetLocale(defaultCulture);
                txtLanguage.Text = App.localizeResProvider.GetText("Vietnamese");
                App.ChangeLanguage();
                App.defaultCulture = defaultCulture;
            }
            else
            {
                var enCulture = new CultureInfo("en-US");
                App.localizer.SetLocale(enCulture);
                txtLanguage.Text = App.localizeResProvider.GetText("English");
                App.ChangeLanguage();
                App.defaultCulture = enCulture;
            }
        }

    }
}