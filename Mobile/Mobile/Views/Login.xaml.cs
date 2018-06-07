using Microsoft.Identity.Client;
using Mobile.Models;
using Mobile.Repository;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobile.Common;
using Mobile.SQLiteModel;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            btnLogin.Clicked += Login_Clicked;
            btnEnglish.Clicked += English_Clicked;
            btnVietnamese.Clicked += Vietnam_Clicked;
        }
        async void Login_Clicked(object sender, EventArgs e)
        {
            App.localizer.SetLocale(App.defaultCulture);
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            if (App.user == null || string.IsNullOrEmpty(App.user.UserId))
            {
                if (App.IsConnectivity)
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
                        try
                        {
                            var jwt = new JwtSecurityToken(result.IdToken);
                            string email = jwt.Claims.First(c => c.Type == "emails").Value;
                            RestClient restClient = App.restClient;
                            string json = await restClient.GetAndReturnObject("users", email, null);
                            //App.userId = email;
                            Models.User users = await restClient.Get<Models.User>("users/" + email + "/location");
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
                            App.ListContact = await restClient.Get<List<Models.User>>("users");
                            #region Sao luu du lieu cuc bo
                            var repository = App.Get<UserRepository>();
                            //Luu nguoi dung cuc bo
                            TokenRepository tokenRepository = App.Get<TokenRepository>();
                            TokenLite tokenLite = new TokenLite();
                            tokenLite.UserId = VikingCommonHelper.VikingEncodeData.Encrypt(email, true, CommonConstant.DefaultSecureKey);
                            tokenRepository.Create(tokenLite);
                            var UserLites = repository.GetAll();
                            var ListTemp = App.ListContact.Where(x => !UserLites.Select(y => y.UserId).Contains(x.UserId)).ToList();
                            if (ListTemp != null && ListTemp.Any())
                            {
                                UserLites = ListTemp.ConvertToListUserLite();
                                foreach (var item in UserLites)
                                {
                                    repository.Create(item);
                                }
                            }
                            #endregion
                            App.ChangeLanguage();
                        }
                        catch (Exception ex)
                        {

                        }
                        await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("LoginSuccess"), "Ok");
                    }
                }
            }
            else
            {
                App.AuthenticationClient.UserTokenCache.Clear(Constants.ApplicationID);
                App.user = null;
                App.token = null;
                App.tokenAuth = null;
                //App.userId = "";
                App.ChangeLanguage();
                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("LogoutSuccess"), "Ok");
            }
            Loading.IsVisible = false;
            Loading.IsRunning = false;
        }
        async void Vietnam_Clicked(object sender, EventArgs e)
        {
            var defaultCulture = new CultureInfo("vi-VN");
            App.localizer.SetLocale(defaultCulture);
            btnVietnamese.Text = App.localizeResProvider.GetText("Vietnamese");
            btnEnglish.Text = App.localizeResProvider.GetText("English");
            App.defaultCulture = defaultCulture;
            App.ChangeLanguage();
        }
        async void English_Clicked(object sender, EventArgs e)
        {
            var enCulture = new CultureInfo("en-US");
            App.localizer.SetLocale(enCulture);
            App.defaultCulture = enCulture;
            btnVietnamese.Text = App.localizeResProvider.GetText("Vietnamese");
            btnEnglish.Text = App.localizeResProvider.GetText("English");
            App.ChangeLanguage();

        }
    }
}