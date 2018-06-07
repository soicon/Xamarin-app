using Mobile.Common;
using Mobile.Models.ModelBO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.News
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsTemp : ContentPage
    {
        public List<NewBO> ListAllNews { get; set; }
        public NewsTemp()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                Loading.IsVisible = true;
                Loading.IsRunning = true;
                List<NewBO> ListNews = new List<NewBO>();
                ListAllNews = new List<NewBO>();
                if (App.IsConnectivity)
                {
                    List<Models.News> news = new List<Models.News>();
                    HttpClient client = new HttpClient();
                    var response = await client.GetAsync(CommonConstant.apiUrl + "news");
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        news = JsonConvert.DeserializeObject<List<Mobile.Models.News>>(jsonString);
                        news = news.Where(x => 1 == x.Status).ToList();
                    }
                    foreach (var item in news)
                    {
                        NewBO newBO = new NewBO();
                        newBO.CreatedTime = item.CreatedTime;
                        newBO.Medias = item.Medias;
                        newBO.NewsId = item.NewsId;
                        newBO.OriginalContent = item.Content;
                        if (item.Content.RemoveHtml().Length > 200)
                        {
                            newBO.Content = item.Content.RemoveHtml().Substring(0, 200) + "...";
                        }
                        else
                        {
                            newBO.Content = item.Content.RemoveHtml();
                        }
                        if ((item.CreatedTime.Date - DateTime.Now.Date).TotalDays == -1)
                        {
                            newBO.Time = "Hôm qua";
                        }
                        else if (item.CreatedTime.Date == DateTime.Now.Date)
                        {
                            newBO.Time = item.CreatedTime.ToString("HH:ss");
                        }
                        else
                        {
                            newBO.Time = item.CreatedTime.ToString("dd/MM/yyyy");
                        }
                        newBO.Status = item.Status;
                        newBO.Title = item.Title;
                        newBO.User = item.User;
                        ListNews.Add(newBO);
                    }
                    ListAllNews = ListNews;
                }
                ItemsListView.ItemsSource = ListNews;
                Loading.IsRunning = false;
                Loading.IsVisible = false;
            }
            catch
            {

            }
            base.OnAppearing();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as NewBO;
            if (item == null)
                return;
            await Navigation.PushAsync(new NewDetailTemp(item));
            ItemsListView.SelectedItem = null;
        }
        private void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            string value = e.NewTextValue;
            var ListTemp = ListAllNews.Where(x => x.Title.ConvertToVN().ToLower().Contains(value.ConvertToVN().ToLower())).ToList();
            ItemsListView.ItemsSource = ListTemp;
            Loading.IsRunning = false;
            Loading.IsVisible = false;
            base.OnAppearing();
        }
    }
}