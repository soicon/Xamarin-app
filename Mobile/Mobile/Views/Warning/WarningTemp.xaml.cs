using Mobile.Common;
using Mobile.CommonModel;
using Mobile.Models;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Warning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WarningTemp : ContentPage
    {
        private ObservableCollection<AlertWrap> Animals;
        private int CurrentPage { get; set; }
        private string SearchText { get; set; }
        private int TotalPage { get; set; }
        public WarningTemp()
        {
            InitializeComponent();
            Animals = new ObservableCollection<AlertWrap>();
            ItemsListView.ItemsSource = Animals;
            CurrentPage = 1;
            btnNext.Clicked += NextClicked;
            btnPrevious.Clicked += PreviousClicked;
            btnPrevious.IsEnabled = false;
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Alert;
            if (item == null)
                return;
            await Navigation.PushAsync(new WarningTempDetail(item));
            ItemsListView.SelectedItem = null;
        }
        protected override async void OnAppearing()
        {
            try
            {

                Animals = new ObservableCollection<AlertWrap>();
                Loading.IsVisible = true;
                Loading.IsRunning = true;
                RestClient restClient = App.restClient;
                var alerts = await restClient.Get<List<Alert>>("alerts");
                if (alerts != null)
                {
                    var ListAlert = alerts.ToList();
                    ListAlert = ListAlert.OrderByDescending(x => x.CreatedTime).ToList();
                    foreach (var item in ListAlert)
                    {
                        AlertWrap alertWrap = new AlertWrap();
                        if (item.Content.RemoveHtml().Trim().Length > 200)
                        {
                            item.Content = item.Content.RemoveHtml().Trim().Substring(0, 200);
                        }
                        else
                        {
                            item.Content = item.Content.RemoveHtml();
                        }
                        alertWrap.AlertId = item.AlertId;
                        alertWrap.Content = item.Content;
                        alertWrap.CreatedTime = item.CreatedTime;
                        alertWrap.Event = item.Event;
                        if ((item.CreatedTime.Date - DateTime.Now.Date).TotalDays == -1)
                        {
                            alertWrap.Time = "Hôm qua";
                        }
                        else if (item.CreatedTime.Date == DateTime.Now.Date)
                        {
                            alertWrap.Time = item.CreatedTime.ToString("HH:ss");
                        }
                        else
                        {
                            alertWrap.Time = item.CreatedTime.ToString("dd/MM/yyyy");
                        }
                        alertWrap.Title = item.Title;
                        alertWrap.User = item.User;
                        Animals.Add(alertWrap);
                    }
                    double page = (double)Animals.Count / CommonConstant.PageSize;
                    TotalPage = (int)Math.Ceiling(page); if (CurrentPage <= TotalPage)
                    {
                        btnNext.IsEnabled = false;
                    }
                    ItemsListView.ItemsSource = Animals.Skip(0).Take(CommonConstant.PageSize).ToList();
                }
                else
                {
                    ItemsListView.ItemsSource = new List<AlertWrap>();
                }
            }
            catch (Exception ex)
            {
                ItemsListView.ItemsSource = new List<AlertWrap>();
            }
            Loading.IsRunning = false;
            Loading.IsVisible = false;
            base.OnAppearing();
        }
        private void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string value = e.NewTextValue;
            SearchText = value.ConvertToVN().ToLower();
            var ListTemp = Animals.Where(x => x.Title.ConvertToVN().ToLower().Contains(SearchText)).ToList();
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
            var ListTemp = Animals.Where(x => x.Title.ConvertToVN().ToLower().Contains(SearchText)).ToList();
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
            var ListTemp = Animals.Where(x => x.Title.ConvertToVN().ToLower().Contains(SearchText)).ToList();
            ListTemp = ListTemp.Skip(offset).Take(CommonConstant.PageSize).ToList();
            ItemsListView.ItemsSource = ListTemp;
        }
    }
}