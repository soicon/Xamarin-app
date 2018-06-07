using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Mobile.Common;
using Mobile.Models.ModelBO;
using Mobile.Services;
using Mobile.Views.Reports;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;

namespace Mobile.Views.News
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class News : ContentPage
    {
        private int CurrentPage { get; set; }
        private int TotalPage { get; set; }
        public List<NewBO> ListAllNews { get; set; }
        private string SearchText { get; set; }
        public News()
        {

            InitializeComponent();
            if (App.user == null)
            {
                ToolbarItems.Clear();
            }
            else
            {
                btnAddItem.Clicked += AddItem_Clicked;
            }
            CurrentPage = 1;
            btnNext.Clicked += NextClicked;
            btnPrevious.Clicked += PreviousClicked;
            btnPrevious.IsEnabled = false;
        }
        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync((new CreateNew()));
        }
        protected override async void OnAppearing()
        {
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            List<Models.News> news = new List<Models.News>();
            List<NewBO> ListNews = new List<NewBO>();
            ListAllNews = new List<NewBO>();
            news = await App.restClient.Get<List<Mobile.Models.News>>(CommonConstant.apiUrl + "news");
            news = news.Where(x => 1 == x.Status).ToList();
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
            double page = (double)ListAllNews.Count / CommonConstant.PageSize;
            TotalPage = (int)Math.Ceiling(page);
            if (CurrentPage <= TotalPage)
            {
                btnNext.IsEnabled = false;
            }
            ItemsListView.ItemsSource = ListNews.Skip(0).Take(CommonConstant.PageSize).ToList();
            Loading.IsRunning = false;
            Loading.IsVisible = false;
            base.OnAppearing();
        }
        async void Refresh_Clicked(object sender, EventArgs e)
        {
            RestClient restClient = App.restClient;
            if (App.token == null)
            {

            }
            var news = await restClient.Get<List<Models.News>>("news");
            if (news != null)
            {
                var ListNews = news.ToList();
                foreach (var item in ListNews)
                {
                    if (item.Content.Length > 200)
                    {
                        item.Content = item.Content.Substring(0, 200) + "...";
                    }
                }
                ItemsListView.ItemsSource = ListNews;
            }
            else
            {
                ItemsListView.ItemsSource = new List<Models.News>();
            }
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as NewBO;
            if (item == null)
                return;
            await Navigation.PushAsync(new NewDetail(item));
            ItemsListView.SelectedItem = null;
        }
        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            App.localizer.SetLocale(App.defaultCulture);
            var result = await DisplayAlert("Delete?", App.localizeResProvider.GetText("String230"), App.localizeResProvider.GetText("Yes1"), App.localizeResProvider.GetText("No1"));
            if (result)
            {
            }
        }
        private void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            string value = e.NewTextValue;
            SearchText = value.ConvertToVN().ToLower();
            var ListTemp = ListAllNews.Where(x => x.Title.ConvertToVN().ToLower().Contains(SearchText)).ToList();
            CurrentPage = 1;
            int offset = (CurrentPage - 1) * CommonConstant.PageSize;
            double page = (double)ListTemp.Count / CommonConstant.PageSize;
            TotalPage = (int)Math.Ceiling(page);
            if (CurrentPage <= TotalPage)
            {
                btnNext.IsEnabled = false;
            }
            else
            {
                btnNext.IsEnabled = true;
            }
            ItemsListView.ItemsSource = ListTemp.Skip(offset).Take(CommonConstant.PageSize).ToList();
            Loading.IsRunning = false;
            Loading.IsVisible = false;
            base.OnAppearing();
        }
        async void PreviousClicked(object sender, EventArgs e)
        {
            CurrentPage--;
            int offset = (CurrentPage - 1) * CommonConstant.PageSize;
            if (string.IsNullOrEmpty(SearchText))
            {
                SearchText = "";
            }
            if (CurrentPage > 1)
            {
                btnPrevious.IsEnabled = true;
            }
            else
            {
                btnPrevious.IsEnabled = false;
            }
            if (CurrentPage < TotalPage)
            {
                btnNext.IsEnabled = true;
            }
            var ListTemp = ListAllNews.Where(x => x.Title.ConvertToVN().ToLower().Contains(SearchText)).ToList();
            ListTemp = ListTemp.Skip(offset).Take(CommonConstant.PageSize).ToList();
            ItemsListView.ItemsSource = ListTemp;
        }
        async void NextClicked(object sender, EventArgs e)
        {
            CurrentPage++;
            int offset = (CurrentPage - 1) * CommonConstant.PageSize;
            if (string.IsNullOrEmpty(SearchText))
            {
                SearchText = "";
            }
            if (CurrentPage > 1)
            {
                btnPrevious.IsEnabled = true;
            }
            if (CurrentPage == TotalPage)
            {
                btnNext.IsEnabled = false;
            }
            var ListTemp = ListAllNews.Where(x => x.Title.ConvertToVN().ToLower().Contains(SearchText)).ToList();
            ListTemp = ListTemp.Skip(offset).Take(CommonConstant.PageSize).ToList();
            ItemsListView.ItemsSource = ListTemp;
        }
    }
}