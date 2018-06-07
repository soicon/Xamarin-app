using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Common;
using Mobile.Models;
using Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;
using Mobile.Repository;
using Mobile.SQLiteModel;

namespace Mobile.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reporter : ContentPage
    {
        private List<Location> ListProvince { get; set; }
        private List<Location> ListDistrict { get; set; }
        private List<Location> ListWard { get; set; }
        private List<Event> ListEvent { get; set; }
        private Location Province { get; set; }
        private Location District { get; set; }
        private Location Ward { get; set; }
        public Reporter()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            btnBack.Clicked += Back_Clicked;
            btnNext.Clicked += Next_Clicked;
            
            Title = App.localizeResProvider.GetText("AfterDisater");
        }
        async void Back_Clicked(object sender, EventArgs e)
        {
            SetData();
            await Navigation.PushAsync(new Report());
            //Navigation.RemovePage(this);
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync((new Report()));
            return base.OnBackButtonPressed();
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            App.localizer.SetLocale(App.defaultCulture);
            try
            {
                if (App.user == null || string.IsNullOrEmpty(App.user.UserId))
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String159"), "Ok");
                }
                else
                {
                    var answer = await DisplayAlert(App.localizeResProvider.GetText("String160"), App.localizeResProvider.GetText("String161"), App.localizeResProvider.GetText("Yes1"), App.localizeResProvider.GetText("No1"));
                    if (answer)
                    {
                        SetData();
                        if (App.IsConnectivity)
                        {
                            #region neu nhu co mang
                            App.ReportTextReplace = App.ReportText.ReplaceData(App.ListReport);
                            RestClient restClient = App.restClient;
                            Models.Report report = new Models.Report();
                            report.Data = App.ReportTextReplace;
                            report.CreatedTime = DateTime.Now;
                            report.ReportType = 1;
                            report.Event = ListEvent[picEvent.SelectedIndex];
                            report.Status = 0;
                            report.User = App.user;
                            report.Location = App.user.Location;
                            var result = await restClient.PostAsync("reports", report);
                            if (result.ToUpper().Equals(ApiStatusConstant.SUCCESS))
                            {
                                App.ListReport = ReportQuestion.initReport();
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String157"), "Ok");
                            }
                            else
                            {
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String158"), "Ok");
                            }
                            #endregion
                            var existingPages = Navigation.NavigationStack.ToList();
                            for (int i = 1; i < existingPages.Count; i++)
                            {
                                Navigation.RemovePage(existingPages[i]);
                            }
                        }
                        else
                        {
                            #region Neu nhu mat mang
                            if (App._connection == null)
                            {
                                App._connection = new SQLite.SQLiteConnection(Connection.GetConnection());
                            }
                            try
                            {
                                //Bao cao sau tham hoa offline
                                var repository = App.Get<ReportRepository>();
                                ReportLite reportLite = new ReportLite();
                                reportLite.Data = JsonConvert.SerializeObject(App.ListReport);
                                reportLite.CreatedTime = DateTime.Now;
                                reportLite.ReportType = 1;
                                reportLite.EventId = ListEvent[picEvent.SelectedIndex].EventId;
                                reportLite.Status = 0;
                                reportLite.LocationId = App.user.Location != null ? App.user.Location.LocationId : 0;
                                reportLite.UserId = App.user.UserId;
                                repository.Create(reportLite);
                                App.ListReport = ReportQuestion.initReport();
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String157"), "Ok");

                            }
                            catch
                            {
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String158"), "Ok");
                            }
                            #endregion
                            var existingPages = Navigation.NavigationStack.ToList();
                            for (int i = 1; i < existingPages.Count; i++)
                            {
                                Navigation.RemovePage(existingPages[i]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void SetData()
        {
            try
            {
                App.Reporter.FullName = txtFullname.Text;
                App.Reporter.Position = txtPosition.Text;
                //Location location = ListProvince[picProvince.SelectedIndex];
                Location location = Province;
                App.Reporter.Province = location != null ? location.LocationId : 0;
                //location = ListDistrict[picDistrict.SelectedIndex];
                location = District;
                App.Reporter.District = location != null ? location.LocationId : 0;
                //location = ListWard[picDistrict.SelectedIndex];
                location = Ward;
                App.Reporter.Commune = location != null ? location.LocationId : 0;
            }
            catch (Exception ex)
            {

            }
        }
        private void GetData()
        {
            txtFullname.Text = App.Reporter.FullName;
            txtPosition.Text = App.Reporter.Position;
        }
        protected override async void OnAppearing()
        {
            //Loading.IsRunning = true;
            try
            {
                RestClient restClient = App.restClient;
                ListProvince = new List<Location>();
                ListWard = new List<Location>();
                ListProvince = await restClient.Get<List<Location>>("locations/type/1");
                if (App.user != null)
                {
                    txtFullname.Text = App.user.Name;
                    txtPosition.Text = App.user.Position;
                }
                if (App.user.Location != null)
                {
                    int index = 0;
                    Location location = App.user.Location;
                    switch (App.user.Location.Type)
                    {
                        case 1:
                            //Province
                            txtProvince.Text = location.Name;
                            txtDistrict.Text = "";
                            Province = location;
                            break;
                        case 2:
                            //District
                            txtDistrict.Text = App.user.Location.Name;
                            District = location;
                            location = await restClient.Get<Location>("locations/" + App.user.Location.ParentCode);
                            Province = location;
                            if (location != null)
                            {
                                txtProvince.Text = location.Name;
                            }
                            break;
                        case 3:
                            //Ward
                            txtProvince.Text = "";
                            txtDistrict.Text = "";
                            txtWard.Text = location.Name;
                            Ward = location;
                            location = await restClient.Get<Location>("locations/" + App.user.Location.ParentCode);
                            if (location != null)
                            {
                                District = location;
                                txtDistrict.Text = location.Name;
                                var location1 = await restClient.Get<Location>("locations/" + location.ParentCode);
                                if (location1 != null)
                                {
                                    Province = location1;
                                    txtProvince.Text = location1.Name;
                                }
                            }
                            break;
                        default:
                            txtProvince.Text = "";
                            txtDistrict.Text = "";
                            break;
                    }
                }
                else
                {
                    ListWard = new List<Location>();
                    ListDistrict = new List<Location>();
                }
                ListEvent = new List<Event>();
                if (App.IsConnectivity)
                {
                    ListEvent = await restClient.Get<List<Event>>("events");
                }
                else
                {
                    var repository = App.Get<EventRepository>();
                    ListEvent = repository.GetAll().ConvertToListEvent();
                }
                picEvent.ItemsSource = ListEvent.Select(x => x.Name).ToList();
                if (ListEvent.Any())
                {
                    picEvent.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {

            }
            base.OnAppearing();
        }
    }
}