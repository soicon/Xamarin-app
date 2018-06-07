using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Text;
using Mobile.Common;
using Mobile.Models;
using Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Linq;
using TEditor.Abstractions;
using TEditor;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAlert : ContentPage
    {
        private Alert alert;
        private List<Event> ListEvents { get; set; }
        private string Content { get; set; }
        public CreateAlert()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            Title = App.localizeResProvider.GetText("String212");
            btnEditContent.Text = App.localizeResProvider.GetText("String230");
            btnEditContent.Clicked += ContentTapped;
            Loading.IsVisible = false;
            Loading.IsRunning = false;
        }
        protected override async void OnAppearing()
        {
            ListEvents = new List<Event>();
            RestClient restClient = App.restClient;
            ListEvents = await restClient.Get<List<Event>>("events");

            picEvent.ItemsSource = ListEvents.OrderBy(y => y.Name).Select(x => x.Name).ToList();
            int index = 0;
            if (alert != null && alert.Event != null && ListEvents.Any())
            {
                index = ListEvents.IndexOf(alert.Event);
            }
            if (ListEvents.Any())
            {
                picEvent.SelectedIndex = index;
            }
        }
        public CreateAlert(Alert alert)
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            this.alert = alert;
            Content = alert.Content;
            txtContent.Source = new HtmlWebViewSource() { Html = Content };
            txtTitle.Text = alert.Title;
            Title = App.localizeResProvider.GetText("String213");
            btnEditContent.Text = App.localizeResProvider.GetText("String231");
            Content = alert.Content;
            btnEditContent.Clicked += ContentTapped;
            Loading.IsVisible = false;
            Loading.IsRunning = false;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.localizer.SetLocale(App.defaultCulture);
                Loading.IsRunning = true;
                Loading.IsVisible = true;
                RestClient restClient = App.restClient;
                Alert alerts = new Alert();
                alerts.User = App.user;

                if (alerts.User == null)
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String186"), "Ok");
                }
                else
                {
                    if (this.alert == null)
                    {
                        alerts.Event = new Event();
                        if (ListEvents.Any())
                        {
                            alerts.Event = ListEvents[picEvent.SelectedIndex];
                        }
                        alerts.Content = Content;
                        alerts.Title = txtTitle.Text;
                        alerts.CreatedTime = DateTime.Now;
                        //Save alerts
                        var result = await restClient.PostAsync("alerts", alerts);
                        if (result.Equals(ApiStatusConstant.SUCCESS))
                        {
                            restClient.AddEvent("ADD_WARNING");
                            await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String202"), "Ok");
                            //App.bottomTabbedPage.SelectedItem = App.bottomTabbedPage.Children[2];
                            var existingPages = Navigation.NavigationStack.ToList();
                            for (int i = 1; i < existingPages.Count; i++)
                            {
                                Navigation.RemovePage(existingPages[i]);
                            }
                        }
                        else
                        {
                            await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String203"), "Ok");
                        }
                    }
                    else
                    {
                        var alert1 = await restClient.Get<Alert>("alerts/" + alert.AlertId);
                        if (alert1 != null)
                        {
                            alert1.User = App.user;
                            alert1.Event = new Event();
                            if (ListEvents.Any())
                            {
                                alert1.Event = ListEvents[picEvent.SelectedIndex];
                            }
                            alert1.Content = Content;
                            alert1.Title = txtTitle.Text;
                            //Save alerts
                            var result = await restClient.PutAsync("alerts", alert1, alert1.AlertId);
                            if (result.Equals(ApiStatusConstant.SUCCESS))
                            {
                                restClient.AddEvent("UPDATE_WARNING");
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String204"), "Ok");
                                //App.bottomTabbedPage.SelectedItem = App.bottomTabbedPage.Children[2];
                                var existingPages = Navigation.NavigationStack.ToList();
                                for (int i = 1; i < existingPages.Count; i++)
                                {
                                    Navigation.RemovePage(existingPages[i]);
                                }
                            }
                            else
                            {
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String205"), "Ok");
                            }
                        }
                        else
                        {
                            await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String205"), "Ok");
                        }
                    }
                }
                Loading.IsVisible = false;
                Loading.IsRunning = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String205"), "Ok");
            }
        }
        public async void ContentTapped(object sender, EventArgs args)
        {
            ShowTEditor(Content);
        }
        private async void ShowTEditor(string html)
        {
            var toolbar = new ToolbarBuilder().AddBasic().AddH1();
            TEditorResponse response = await CrossTEditor.Current.ShowTEditor(html, toolbar);
            if (response.IsSave)
            {
                if (response.HTML != null)
                {
                    Content = response.HTML;
                    txtContent.Source = new HtmlWebViewSource() { Html = response.HTML };
                }
            }
        }
    }
}