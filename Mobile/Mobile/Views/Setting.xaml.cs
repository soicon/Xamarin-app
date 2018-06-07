using Mobile.Repository;
using System;
using System.Globalization;
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
            if (App.user != null)
            {
                txtUserName.Text = App.user.Name;
            }
            App.localizer.SetLocale(App.defaultCulture);
            //if (App.localizer.GetCurrentCultureInfo().Name.Equals("en-US"))
            //{
            //    txtLanguage.Text = App.localizeResProvider.GetText("English");
            //}
            //else
            //{
            //    txtLanguage.Text = App.localizeResProvider.GetText("Vietnamese");
            //}
            CurrentVersion.Text = Constants.CurrentVersion;
        }
        public async void LogoutTapped(object sender, EventArgs args)
        {
            App.localizer.SetLocale(App.defaultCulture);
            var answer = await DisplayAlert(App.localizeResProvider.GetText("String170"), App.localizeResProvider.GetText("String171"), App.localizeResProvider.GetText("Yes1"), App.localizeResProvider.GetText("No1"));
            if (answer)
            {
                var repository = App.Get<TokenRepository>();
                var Token = repository.Get(App.user.UserId);
                if (Token != null)
                {
                    repository.Delete(Token);
                }
                App.localizer.SetLocale(App.defaultCulture);
                App.AuthenticationClient.UserTokenCache.Clear(Constants.ApplicationID);
                App.user = null;
                App.token = null;
                App.tokenAuth = null;
                //App.userId = "";
                App.ChangeLanguage();
                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("LogoutSuccess"), "Ok");
            }
        }
        public async void ProfileTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Register(App.user));
        }
        public async void LanguageTapped(object sender, EventArgs args)
        {
            if (App.defaultCulture.Name.Equals("en-US"))
            {
                var defaultCulture = new CultureInfo("vi-VN");
                App.localizer.SetLocale(defaultCulture);
                App.defaultCulture = defaultCulture;
                App.ChangeLanguage();
            }
            else
            {
                var enCulture = new CultureInfo("en-US");
                App.localizer.SetLocale(enCulture);
                App.defaultCulture = enCulture;
                App.ChangeLanguage();
            }
        }

    }
}