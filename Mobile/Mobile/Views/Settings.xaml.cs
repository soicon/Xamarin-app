using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Models;
using Mobile.Services;
using Mobile.Views.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            Profile.IsEnabled = false;
            //btnEnglish.Clicked += English_Clicked;
            //btnVietnamese.Clicked += Vietnam_Clicked;
        }
        public async void ProfileTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Profile());
        }
        public async void FamilyTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Families());
        }
        public async void LoginTapped(object sender, EventArgs args)
        {
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            if (App.user == null || string.IsNullOrEmpty(App.user.UserId))
            {
                var result = await App.AuthenticationClient.AcquireTokenAsync(
                    Constants.Scopes,
                    string.Empty,
                    UiOptions.SelectAccount,
                    string.Empty,
                    null,
                    Constants.Authority,
                    Constants.SignUpSignInPolicy);
                if (result != null)
                {
                    Login.Source = "Logout_128.png";
                    Profile.IsEnabled = true;
                    var jwt = new JwtSecurityToken(result.IdToken);
                    string email = jwt.Claims.First(c => c.Type == "emails").Value;
                    RestClient restClient = new RestClient();
                    string json = await restClient.GetAndReturnObject("users", email, null);
                    App.userId = email;
                    Models.User users = JsonConvert.DeserializeObject<Models.User>(json);
                    if (users == null)
                    {
                        users = new Models.User();
                    }
                    App.user = users;
                    TokenAuth tokenAuth = new TokenAuth();
                    tokenAuth.userId = users != null ? users.UserId : null;
                    tokenAuth.secretCode = App.user.SecretCode;
                    App.tokenAuth = tokenAuth;
                    App.token = await RestClient.PostAndReturnToken<Token>("tokens", tokenAuth);
                    await DisplayAlert("Thông báo", "Đăng nhập thành công", "Ok");
                }
            }
            else
            {
                Profile.IsEnabled = false;
                App.AuthenticationClient.UserTokenCache.Clear(Constants.ApplicationID);
                App.user = null;
                App.token = null;
                App.tokenAuth = null;
                App.userId = "";
                await DisplayAlert("Thông báo", "Đăng xuất thành công", "Ok");
            }
            Loading.IsVisible = false;
            Loading.IsRunning = false;
        }
        public async void LanguageTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Language());
        }
        //async void Vietnam_Clicked(object sender, EventArgs e)
        //{
        //    var result = await App.AuthenticationClient.AcquireTokenAsync(
        //            Constants.Scopes,
        //            string.Empty,
        //            UiOptions.SelectAccount,
        //            string.Empty,
        //            null,
        //            Constants.Authority,
        //            Constants.SignUpSignInPolicy);
        //    if (result != null)
        //    {
        //        var jwt = new JwtSecurityToken(result.IdToken);
        //        string email = jwt.Claims.First(c => c.Type == "emails").Value;
        //        RestClient restClient = new RestClient();
        //        string json = await restClient.GetAndReturnObject("users", email, null);
        //        App.userId = email;
        //        Models.User users = JsonConvert.DeserializeObject<Models.User>(json);
        //        if (users == null)
        //        {
        //            users = new Models.User();
        //        }
        //        App.user = users;
        //        TokenAuth tokenAuth = new TokenAuth();
        //        tokenAuth.userId = users != null ? users.UserId : null;
        //        tokenAuth.secretCode = App.user.SecretCode;
        //        App.tokenAuth = tokenAuth;
        //        App.token = await RestClient.PostAndReturnToken<Token>("tokens", tokenAuth);
        //        //App.mainPage2.Children.Add(new FavoritesPage());
        //        //App.mainPage2.Children[7].Icon = "ic_favorites.png";
        //    }
        //}
        //async void English_Clicked(object sender, EventArgs e)
        //{
        //    //App.mainPage2.Children.Add(new FavoritesPage());
        //    //App.mainPage2.Children[7].Icon = "ic_favorites.png";
        //    App.isChange = true;
        //}
    }
}