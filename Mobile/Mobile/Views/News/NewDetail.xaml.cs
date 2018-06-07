using Mobile.Common;
using Mobile.Models.ModelBO;
using Mobile.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDetail : ContentPage
    {
        private NewBO news { get; set; }
        public NewDetail(NewBO news)
        {
            InitializeComponent();
            if (App.user == null)
            {
                ToolbarItems.Clear();
            }
            Title = news.Title;
            this.news = news;
            BindingContext = news;
            txtTitle.Text = news.Title;
            //txtContent.Text = news.Content;
            btnDelete.Clicked += DeleteItem_Clicked;
            btnEdit.Clicked += EditItem_Clicked;
            articleweb.Source = new HtmlWebViewSource
            {
                Html = news.OriginalContent
            };
        }
        private async void EditItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync((new CreateNew(news)));
        }
        private async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            App.localizer.SetLocale(App.defaultCulture);
            var answer = await DisplayAlert(App.localizeResProvider.GetText("String177"), App.localizeResProvider.GetText("String198"), App.localizeResProvider.GetText("Yes1"), App.localizeResProvider.GetText("No1"));
            if (answer)
            {

                RestClient restClient = App.restClient;
                var result = await restClient.DeleteAsync("news", news.NewsId);
                if (result == ApiStatusConstant.SUCCESS)
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String197"), "Ok");
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