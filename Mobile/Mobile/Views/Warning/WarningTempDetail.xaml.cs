using System;
using Mobile.Common;
using Mobile.Models;
using Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Warning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WarningTempDetail : ContentPage
    {
        private Alert alert { get; set; }
        public WarningTempDetail(Alert alerts)
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            lblTitle.Text = alerts.Title;
            lblCreatedTime.Text = alerts.CreatedTime.ToString("HH:mm:ss") + " ngày " + alerts.CreatedTime.ToString("dd/MM/yyyy");
            this.Title = App.localizeResProvider.GetText("String214");
            this.BindingContext = alerts;
            this.alert = alerts;
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
    }
}