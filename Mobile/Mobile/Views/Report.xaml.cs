using Mobile.CommonModel;
using Mobile.Views.Reports;
using Plugin.Connectivity;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Report : ContentPage
    {
        #region
        public Action CustomBackButtonAction { get; set; }

        public static readonly BindableProperty EnableBackButtonOverrideProperty =
               BindableProperty.Create(
               nameof(EnableBackButtonOverride),
               typeof(bool),
               typeof(CoolContentPage),
               false);

        /// <summary>
        /// Gets or Sets Custom Back button overriding state
        /// </summary>
        public bool EnableBackButtonOverride
        {
            get
            {
                return (bool)GetValue(EnableBackButtonOverrideProperty);
            }
            set
            {
                SetValue(EnableBackButtonOverrideProperty, value);
            }
        }
        #endregion
        public ObservableCollection<ReportModel> Items { get; set; }
        public Report()
        {
            InitializeComponent();
            this.CustomBackButtonAction = async () =>
            {
                var existingPages = Navigation.NavigationStack.ToList();
                if (existingPages.Count > 1)
                {
                    for (int i = 1; i < existingPages.Count; i++)
                    {
                        Navigation.RemovePage(existingPages[i]);
                    }
                }
                await Navigation.PopAsync(true);
                //if (CrossConnectivity.Current.IsConnected)
                //{
                //    App.bottomTabbedPage.CurrentPage = App.News;
                //}
                //else
                //{
                //    App.bottomTabbedPage.CurrentPage = App.News;
                //}
            };
            App.localizer.SetLocale(App.defaultCulture);
            Title = App.localizeResProvider.GetText("AfterDisater");
        }
        protected override bool OnBackButtonPressed()
        {
            if (App.IsConnectivity)
            {
                App.bottomTabbedPage.CurrentPage = App.bottomTabbedPage.Children[3];
            }
            else
            {
                App.bottomTabbedPage.CurrentPage = App.bottomTabbedPage.Children[1];
            }
            return base.OnBackButtonPressed();
        }
        protected override async void OnAppearing()
        {
            App.localizer.SetLocale(App.defaultCulture);
            Items = new ObservableCollection<ReportModel>();
            var reporter = new ReportModel() { Icon = "Shape1_1.png", Title = App.localizeResProvider.GetText("String104") };
            var infor = new ReportModel() { Icon = "Forma1_1.png", Title = App.localizeResProvider.GetText("String105") };
            var health = new ReportModel() { Icon = "Shape1_0.png", Title = App.localizeResProvider.GetText("String106") };
            var water = new ReportModel() { Icon = "Forma1.png", Title = App.localizeResProvider.GetText("String107") };
            var food = new ReportModel() { Icon = "Forma1_0.png", Title = App.localizeResProvider.GetText("String108") };
            var home = new ReportModel() { Icon = "Shape1.png", Title = App.localizeResProvider.GetText("String109") };
            Items.Add(reporter);
            Items.Add(infor);
            Items.Add(health);
            Items.Add(water);
            Items.Add(food);
            Items.Add(home);
            ItemsListView.ItemsSource = Items;
            base.OnAppearing();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ReportModel;
            if (item == null)
                return;
            int index = Items.IndexOf(item);
            switch (index)
            {
                case 0:
                    await base.Navigation.PushAsync(new Reporter());
                    break;
                case 1:
                    await base.Navigation.PushAsync(new Information());
                    break;
                case 2:
                    await base.Navigation.PushAsync(new Health());
                    break;
                case 3:
                    await base.Navigation.PushAsync(new Water());
                    break;
                case 4:
                    await base.Navigation.PushAsync(new Food());
                    break;
                case 5:
                    await base.Navigation.PushAsync(new Views.Reports.Home());
                    break;
            }
            ItemsListView.SelectedItem = null;
        }
    }
}