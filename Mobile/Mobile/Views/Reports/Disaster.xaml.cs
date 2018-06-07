using Mobile.Common;
using Mobile.Models;
using Mobile.Repository;
using Mobile.Services;
using Mobile.SQLiteModel;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Disaster : ContentPage
    {
        private List<Location> ListProvince { get; set; }
        private List<Location> ListDistrict { get; set; }
        private List<Location> ListWard { get; set; }
        private List<Event> ListEvent { get; set; }
        public Disaster()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            btnNext.Clicked += Next_Clicked;
            Title = App.localizeResProvider.GetText("BeforeDisater");
            txtProvider.Text = App.user != null ? App.user.Name : "";

        }
        protected override async void OnAppearing()
        {
            //Loading.IsRunning = true;
            try
            {
                RestClient restClient = App.restClient;
                Location location = null;
                if (App.user.Location != null)
                {
                    location = App.user.Location;
                    switch (App.user.Location.Type)
                    {
                        case 1:
                            //Province
                            txtProvince.Text = location.Name;
                            txtDistrict.Text = "";
                            break;
                        case 2:
                            //District
                            txtDistrict.Text = App.user.Location.Name;
                            location = await restClient.Get<Location>("locations/" + App.user.Location.ParentCode);
                            if (location != null)
                            {
                                txtProvince.Text = location.Name;
                            }
                            break;
                        case 3:
                            //Ward
                            txtProvince.Text = "";
                            txtDistrict.Text = "";
                            location = await restClient.Get<Location>("locations/" + App.user.Location.ParentCode);
                            if (location != null)
                            {
                                txtDistrict.Text = location.Name;
                                var location1 = await restClient.Get<Location>("locations/" + location.ParentCode);
                                if (location1 != null)
                                {
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
                        List<Part> ListReportData = App.ListReportData;
                        #region Part 1
                        ListReportData[0].Action = "";
                        ListReportData[0].WhoAction = "";
                        ListReportData[0].ListQuestions[0].Total = string.IsNullOrEmpty(txtTotalWard.Text) ? 0 : txtTotalWard.Text.ConvertToFloat();
                        ListReportData[0].ListQuestions[1].Total = string.IsNullOrEmpty(txt2a.Text) ? 0 : txt2a.Text.ConvertToFloat();
                        ListReportData[0].ListQuestions[2].Total = string.IsNullOrEmpty(txt3a.Text) ? 0 : txt3a.Text.ConvertToFloat();
                        ListReportData[0].ListQuestions[3].Total = string.IsNullOrEmpty(txt4a.Text) ? 0 : txt4a.Text.ConvertToFloat();
                        ListReportData[0].ListQuestions[4].Total = string.IsNullOrEmpty(txtTotalWard1.Text) ? 0 : txtTotalWard1.Text.ConvertToFloat();
                        ListReportData[0].ListQuestions[5].Total = string.IsNullOrEmpty(txt6a.Text) ? 0 : txt6a.Text.ConvertToFloat();
                        ListReportData[0].ListQuestions[6].Total = string.IsNullOrEmpty(txt7a.Text) ? 0 : txt7a.Text.ConvertToFloat();
                        ListReportData[0].ListQuestions[7].Total = string.IsNullOrEmpty(txt8a.Text) ? 0 : txt8a.Text.ConvertToFloat();
                        ListReportData[0].ListQuestions[8].Total = string.IsNullOrEmpty(txt9a.Text) ? 0 : txt9a.Text.ConvertToFloat();

                        ListReportData[0].ListQuestions[0].Note = txtTotalWard.Text;
                        ListReportData[0].ListQuestions[1].Note = txt2a.Text;
                        ListReportData[0].ListQuestions[2].Note = txt3a.Text;
                        ListReportData[0].ListQuestions[3].Note = txt4a.Text;
                        ListReportData[0].ListQuestions[4].Note = txtTotalWard1.Text;
                        ListReportData[0].ListQuestions[5].Note = txt6a.Text;
                        ListReportData[0].ListQuestions[6].Note = txt7a.Text;
                        ListReportData[0].ListQuestions[7].Note = txt8a.Text;
                        ListReportData[0].ListQuestions[8].Note = txt9a.Text;
                        #endregion
                        #region Part 2
                        ListReportData[1].Action = txtAction.Text;
                        ListReportData[1].WhoAction = txtWhoAction.Text;
                        ListReportData[1].ListQuestions[0].Total = string.IsNullOrEmpty(txt1b.Text) ? 0 : txt1b.Text.ConvertToFloat();
                        ListReportData[1].ListQuestions[1].Total = string.IsNullOrEmpty(txt2b.Text) ? 0 : txt2b.Text.ConvertToFloat();
                        ListReportData[1].ListQuestions[2].Total = string.IsNullOrEmpty(txt3b.Text) ? 0 : txt3b.Text.ConvertToFloat();
                        ListReportData[1].ListQuestions[3].Total = string.IsNullOrEmpty(txt4b.Text) ? 0 : txt4b.Text.ConvertToFloat();
                        //ListReportData[0].ListQuestions[4].Total = string.IsNullOrEmpty(txt4b.Text) ? 0 : txt4b.Text.ConvertToFloat();

                        ListReportData[1].ListQuestions[0].Note = txt1b.Text;
                        ListReportData[1].ListQuestions[1].Note = txt2b.Text;
                        ListReportData[1].ListQuestions[2].Note = txt3b.Text;
                        ListReportData[1].ListQuestions[3].Note = txt4b.Text;
                        ListReportData[1].ListQuestions[4].Note = txt5b.Text;
                        #endregion
                        #region Part 3
                        ListReportData[2].Action = txtAction.Text;
                        ListReportData[2].WhoAction = txtWhoAction.Text;
                        ListReportData[2].ListQuestions[0].Total = string.IsNullOrEmpty(txt1c.Text) ? 0 : txt1c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[1].Total = string.IsNullOrEmpty(txt2c.Text) ? 0 : txt2c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[2].Total = string.IsNullOrEmpty(txt3c.Text) ? 0 : txt3c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[3].Total = string.IsNullOrEmpty(txt4c.Text) ? 0 : txt4c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[4].Total = string.IsNullOrEmpty(txt5c.Text) ? 0 : txt5c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[5].Total = string.IsNullOrEmpty(txt6c.Text) ? 0 : txt6c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[6].Total = string.IsNullOrEmpty(txt7c.Text) ? 0 : txt7c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[7].Total = string.IsNullOrEmpty(txt8c.Text) ? 0 : txt8c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[8].Total = string.IsNullOrEmpty(txt9c.Text) ? 0 : txt9c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[9].Total = string.IsNullOrEmpty(txt10c.Text) ? 0 : txt10c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[10].Total = string.IsNullOrEmpty(txt11c.Text) ? 0 : txt11c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[11].Total = string.IsNullOrEmpty(txt12c.Text) ? 0 : txt12c.Text.ConvertToFloat();
                        ListReportData[2].ListQuestions[12].Note = txt13c.Text;

                        ListReportData[2].ListQuestions[0].Note = txt1c.Text;
                        ListReportData[2].ListQuestions[1].Note = txt2c.Text;
                        ListReportData[2].ListQuestions[2].Note = txt3c.Text;
                        ListReportData[2].ListQuestions[3].Note = txt4c.Text;
                        ListReportData[2].ListQuestions[4].Note = txt5c.Text;
                        ListReportData[2].ListQuestions[5].Note = txt6c.Text;
                        ListReportData[2].ListQuestions[6].Note = txt7c.Text;
                        ListReportData[2].ListQuestions[7].Note = txt8c.Text;
                        ListReportData[2].ListQuestions[8].Note = txt9c.Text;
                        ListReportData[2].ListQuestions[9].Note = txt10c.Text;
                        ListReportData[2].ListQuestions[10].Note = txt11c.Text;
                        ListReportData[2].ListQuestions[11].Note = txt12c.Text;
                        #endregion
                        if (App.IsConnectivity)
                        {
                            #region Neu nhu co mang
                            RestClient restClient = App.restClient;
                            Models.Report report = new Models.Report();
                            report.Data = JsonConvert.SerializeObject(ListReportData);
                            report.CreatedTime = DateTime.Now;
                            report.ReportType = 0;
                            report.Event = ListEvent[picEvent.SelectedIndex];
                            report.Status = 0;
                            report.Location = App.user.Location;
                            report.User = App.user;
                            var result = await restClient.PostAsync("reports", report);
                            if (result.ToUpper().Equals(ApiStatusConstant.SUCCESS))
                            {
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String157"), "Ok");
                            }
                            else
                            {
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String158"), "Ok");
                            }
                            #endregion
                        }
                        else
                        {
                            try
                            {
                                #region Neu nhu ko co mang
                                if (App._connection == null)
                                {
                                    App._connection = new SQLite.SQLiteConnection(Connection.GetConnection());
                                }
                                var repository = App.Get<ReportRepository>();
                                ReportLite reportLite = new ReportLite();
                                reportLite.Data = JsonConvert.SerializeObject(ListReportData);
                                reportLite.CreatedTime = DateTime.Now;
                                reportLite.ReportType = 0;
                                reportLite.EventId = ListEvent[picEvent.SelectedIndex].EventId;
                                reportLite.Status = 0;
                                reportLite.LocationId = App.user.Location != null ? App.user.Location.LocationId : 0;
                                reportLite.UserId = App.user.UserId;
                                repository.Create(reportLite);
                                #endregion
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String157"), "Ok");
                            }
                            catch
                            {
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String158"), "Ok");
                            }
                        }
                        var existingPages = Navigation.NavigationStack.ToList();
                        for (int i = 1; i < existingPages.Count; i++)
                        {
                            Navigation.RemovePage(existingPages[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert(App.localizeResProvider.GetText("Notification"), "Có lỗi xảy ra!", "Ok");
            }
        }
    }
}