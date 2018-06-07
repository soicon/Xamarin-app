using System;
using Mobile.Common;
using Mobile.Models;
using Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WarningDetail : ContentPage
    {
        private Alert alert { get; set; }
        public WarningDetail()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            Title = App.localizeResProvider.GetText("String214");
        }
        public WarningDetail(Alert alerts)
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            lblTitle.Text = alerts.Title;
            lblCreatedTime.Text = alerts.CreatedTime.ToString("HH:mm:ss") + " ngày " + alerts.CreatedTime.ToString("dd/MM/yyyy");
            this.Title = App.localizeResProvider.GetText("String214");
            this.BindingContext = alerts;
            this.alert = alerts;
            btnDelete.Clicked += DeleteItem_Clicked;
            btnEdit.Clicked += EditItem_Clicked;
        }
        protected override async void OnAppearing()
        {
            try
            {
                RestClient restClient = App.restClient;
                Alert alert1 = await restClient.Get<Alert>("alerts/" + alert.AlertId);
                if (alert1 != null)
                {
                    alert.Content = alert1.Content;
                }
                articleweb.Source = new HtmlWebViewSource
                {
                    Html = alert.Content
                };

            }
            catch (Exception ex)
            {
            }
            base.OnAppearing();
        }
        private async void EditItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAlert(alert));
        }
        private async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            App.localizer.SetLocale(App.defaultCulture);
            var answer = await DisplayAlert(App.localizeResProvider.GetText("String177"), App.localizeResProvider.GetText("String206"), App.localizeResProvider.GetText("Yes1"), App.localizeResProvider.GetText("No1"));
            if (answer)
            {
                RestClient restClient = App.restClient;
                var result = await restClient.DeleteAsync("alerts", alert.AlertId);
                if (result == ApiStatusConstant.SUCCESS)
                {
                    restClient.AddEvent("DELETE_WARNING");
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String207"), "Ok");
                    Navigation.RemovePage(this);
                }
                else
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String179"), "Ok");
                }
            }
        }
    }
}