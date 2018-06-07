using Mobile.Common;
using Mobile.Models.ModelBO;
using Mobile.Services;
using System;
using System.Linq;
using System.Net.Http;
using TEditor;
using TEditor.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNew : ContentPage
    {
        private NewBO news { get; set; }
        private string Content { get; set; }
        public CreateNew()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            Loading.IsVisible = false;
            Title = App.localizeResProvider.GetText("String209");
            lblFormStatus.Text = App.localizeResProvider.GetText("String209");
            btnEditContent.Text = App.localizeResProvider.GetText("String230");
            btnEditContent.Clicked += ContentTapped;
        }
        public CreateNew(NewBO news)
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            Title = App.localizeResProvider.GetText("String208");
            lblFormStatus.Text = App.localizeResProvider.GetText("String208");
            btnEditContent.Text = App.localizeResProvider.GetText("String231");
            txtTitle.Text = news.Title;
            Content = news.OriginalContent;
            txtContent.Source = new HtmlWebViewSource() { Html = Content };
            this.news = news;
            btnEditContent.Clicked += ContentTapped;
            Loading.IsVisible = false;
            Loading.IsRunning = false;
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
        async void Save_Clicked(object sender, EventArgs e)
        {
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            try
            {
                App.localizer.SetLocale(App.defaultCulture);
                RestClient restClient = App.restClient;
                Models.News news = new Models.News();
                news.User = App.user;
                if (news.User == null)
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String186"), "Ok");
                }
                else
                {
                    if (this.news != null)
                    {
                        this.news.User = App.user;
                        this.news.Content = Content;
                        this.news.Title = txtTitle.Text;
                        var result = await restClient.PutAsync("news", this.news.ToModel(), this.news.NewsId);
                        if (result == ApiStatusConstant.SUCCESS)
                        {
                            await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String195"), "Ok");
                        }

                    }
                    else
                    {
                        news.Status = 0;
                        news.Content = Content;
                        news.Title = txtTitle.Text;
                        news.CreatedTime = DateTime.Now;
                        var result = await restClient.PostAsync("news", news);
                        if (result == ApiStatusConstant.SUCCESS)
                            await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String196"), "Ok");
                    }
                    var existingPages = Navigation.NavigationStack.ToList();
                    for (int i = 1; i < existingPages.Count; i++)
                    {
                        Navigation.RemovePage(existingPages[i]);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            Loading.IsVisible = false;
            Loading.IsRunning = false;
        }
    }
}