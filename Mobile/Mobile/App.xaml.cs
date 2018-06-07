using Microsoft.Identity.Client;
using Mobile.Common;
using Mobile.Models;
using Mobile.Models.ModelBO;
using Mobile.Models.ReportBO;
using Mobile.Repository;
using Mobile.Services;
using Mobile.SQLiteModel;
using Mobile.Views;
using Naxam.Controls.Forms;
using Naxam.I18n;
using Naxam.I18n.Forms;
using Plugin.Connectivity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile
{
    public partial class App : Application
    {
        const string ResourceId = "Mobile.Resources.LocalTexts";
        public static Token token { get; set; }
        public static Models.User user { get; set; }
        public static TokenAuth tokenAuth { get; set; }
        public static PublicClientApplication AuthenticationClient { get; private set; }
        public static string ReportText { get; set; }
        public static string ReportTextReplace { get; set; }
        public static List<ReportBO> ListReport { get; set; }
        public static Reporter Reporter { get; set; }
        public static List<Part> ListReportData { get; set; }
        public static ILocalizer localizer { get; set; }
        public static ILocalizedResourceProvider localizeResProvider { get; set; }
        public static BottomTabbedPage bottomTabbedPage { get; set; }
        public static CultureInfo defaultCulture { get; set; }
        public static bool IsConnectivity { get; set; }
        public static SQLiteConnection _connection;
        public static List<UserLite> UserLites { get; set; }
        public static List<Models.User> ListContact { get; set; }
        public static RestClient restClient;
        public static Dictionary<string, object> ListBusiness = new Dictionary<string, object>();
        public App()
        {
            InitializeComponent();
            restClient = new RestClient();
            _connection = new SQLiteConnection(Connection.GetConnection());
            #region i18n
            var getter = DependencyService.Get<IDependencyGetter>();
            localizer = getter.Get<ILocalizer>();
            localizeResProvider = getter.Get<ILocalizedResourceProvider>();
            defaultCulture = localizer.GetCurrentCultureInfo();
            localizer.SetLocale(defaultCulture);
            #endregion
            var icons = Plugin.Iconize.Iconize.Modules.FirstOrDefault()?.Keys.Take(5) ?? new string[0];
            AuthenticationClient = new PublicClientApplication(Constants.ApplicationID);
            //Load json file
            ListReport = ReportQuestion.initReport();
            ReportText = LoadResourceJson.GetJsonFile();
            ListReportData = LoadResourceJson.GetBeforeDisater();
            Reporter = new Reporter();
            ReportTextReplace = "";
            bottomTabbedPage = new BottomTabbedPage();
            SetData();
            MainPage = new NavigationPage(bottomTabbedPage)
            {
                BarBackgroundColor = Color.FromHex("#ce1e21"),
                BarTextColor = Color.White,
            };
            //IsNavBack = true;
            IsConnectivity = CrossConnectivity.Current.IsConnected;
            if (_connection == null)
            {

            }
            if (IsConnectivity)
            {
                //SetContact();
                ListContact = new List<Models.User>();
            }
            AsyncEvent();
            var repository = Get<UserRepository>();
            UserLites = repository.GetAll();
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }
        protected override void OnStart()
        {
            // Handle when your app starts
            if (CrossConnectivity.Current.IsConnected && user != null)
            {
                AsyncReport();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public static ResourceManager ResManager
        {
            get
            {
                return new ResourceManager(ResourceId, typeof(App).GetTypeInfo().Assembly);
            }
        }
        public static void ChangeLanguage()
        {
            App.bottomTabbedPage.Children.Clear();
            App.localizer.SetLocale(defaultCulture);
            var icons = Plugin.Iconize.Iconize.Modules.FirstOrDefault()?.Keys.Take(5) ?? new string[0];
            if (App.user == null)
            {
                if (IsConnectivity)
                {
                    #region Nguoi dung chua login
                    App.bottomTabbedPage.Children.Add(new Views.News.News() { Icon = icons.FirstOrDefault() ?? "news2.png", Title = App.localizeResProvider.GetText("NewsPage") });
                    App.bottomTabbedPage.Children.Add(new Views.Warning.WarningTemp() { Icon = icons.Skip(1).FirstOrDefault() ?? "alert2.png", Title = App.localizeResProvider.GetText("AlertPage") });
                    App.bottomTabbedPage.Children.Add(new Views.Register() { Icon = icons.Skip(2).FirstOrDefault() ?? "register2.png", Title = App.localizeResProvider.GetText("RegisterPage") });
                    //bottomTabbedPage.Children.Add(new Views.Setting() { Icon = icons.Skip(3).FirstOrDefault() ?? "ic_favorite_black_24dp", Title = localizeResProvider.GetText("Settings") });
                    App.bottomTabbedPage.Children.Add(new Views.Login() { Icon = icons.Skip(3).FirstOrDefault() ?? "setting2.png", Title = App.localizeResProvider.GetText("Settings") });
                    #endregion
                }
                else
                {
                    ShowAlert();
                }
            }
            else
            {
                #region Nguoi dung da login
                if (IsConnectivity)
                {
					App.bottomTabbedPage.Children.Add(new Views.News.News() { Icon = icons.FirstOrDefault() ?? "news2.png", Title = App.localizeResProvider.GetText("NewsPage") });
                }
				App.bottomTabbedPage.Children.Add(new Views.Contact() { Icon = icons.Skip(2).FirstOrDefault() ?? "Contact.png", Title = App.localizeResProvider.GetText("ContactPage") });
                if (IsConnectivity)
                {
					App.bottomTabbedPage.Children.Add(new Views.Warning.Warning() { Icon = icons.Skip(1).FirstOrDefault() ?? "alert2.png", Title = App.localizeResProvider.GetText("AlertPage") });
                }
				App.bottomTabbedPage.Children.Add(new Views.Reports.ReportForm() { Icon = icons.Skip(4).FirstOrDefault() ?? "report.png", Title = App.localizeResProvider.GetText("ReportPage") });
				App.bottomTabbedPage.Children.Add(new Setting() { Icon = icons.Skip(3).FirstOrDefault() ?? "news2.png", Title = App.localizeResProvider.GetText("Settings") });


                #endregion
            }
        }
        /// <summary>
        /// Dong bo bao cao offline
        /// </summary>
        public static async Task AsyncReport()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(Connection.GetConnection());
                }
                var repository = new ReportRepository(_connection);
                var ListReport = repository.GetAll();
                if (ListReport.Any())
                {
                    foreach (var item in ListReport)
                    {
                        Models.Report Report = new Models.Report();
                        Report.Data = item.Data;
                        Report.CreatedTime = item.CreatedTime;
                        Report.ReportType = item.ReportType;
                        Report.Event = await restClient.Get<Event>("events/" + item.EventId);
                        Report.Status = item.Status;
                        Report.Location = await restClient.Get<Location>("locations/" + item.LocationId);
                        Report.User = await restClient.Get<Models.User>("users/" + item.UserId);
                        await restClient.PostAsync("reports", Report);
                        repository.Delete(item);
                    }
                }
            }
            catch
            {

            }
        }
        private async void SetData()
        {
            var tokenRepository = App.Get<TokenRepository>();
            var Token = tokenRepository.GetLastLogin();
            if (Token != null)
            {
                App.user = new Models.User();
                //App.userId = Token.UserId;
                Models.User users = await restClient.Get<Models.User>("users/" + Token.UserId + "/location");
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
            }
            ChangeLanguage();
        }
        private static async void ShowAlert()
        {
            await App.Current.MainPage.DisplayAlert(App.localizeResProvider.GetText("Notification"), "Thiết bị cần kết nối mạng để xử dụng", "Ok");
        }
        private async Task AsyncEvent()
        {
            try
            {
                var ListEvent = await restClient.Get<List<Event>>("events");
                var repository = new EventRepository(_connection);
                var ListEventLite = repository.GetAll();
                var ListTemp = ListEvent.Where(x => !ListEventLite.Select(y => y.EventId).Contains(x.EventId)).ToList().ConvertToListEventLite();
                if (ListTemp.Any())
                {
                    foreach (var item in ListTemp)
                    {
                        repository.Create(item);
                    }
                }
            }
            catch
            {

            }
        }
        void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            App.localizer.SetLocale(App.defaultCulture);
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (!e.IsConnected)
                {
                    App.IsConnectivity = false;
                    App.ChangeLanguage();
                    await App.Current.MainPage.DisplayAlert(App.localizeResProvider.GetText("String218"), App.localizeResProvider.GetText("String219"), "OK");
                }
                else
                {
                    App.IsConnectivity = true;
                    await App.AsyncReport();
                    App.ChangeLanguage();
                    await App.Current.MainPage.DisplayAlert(App.localizeResProvider.GetText("String218"), App.localizeResProvider.GetText("String229"), "OK");
                }
            });
        }
        public static B Get<B>()
        {
            if (ListBusiness == null)
            {
                ListBusiness = new Dictionary<string, object>();
            }
            var type = typeof(B);
            if (ListBusiness.ContainsKey(type.Name))
            {
                return (B)ListBusiness[type.Name];
            }
            try
            {
                B instance = (B)Activator.CreateInstance(type, App._connection);
                ListBusiness.Add(type.Name, instance);
                return instance;
            }
            catch (Exception)
            {

                return default(B);
            }
        }
    }
}
