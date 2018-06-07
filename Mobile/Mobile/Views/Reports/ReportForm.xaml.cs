using Mobile.Models.ModelBO;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportForm : ContentPage
    {
        public List<ReportFormBO> Animals;
        public ReportForm()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            try
            {
                App.localizer.SetLocale(App.defaultCulture);
                Animals = new List<ReportFormBO>();
                ReportFormBO reportFormBO = new ReportFormBO();
                reportFormBO.Title = App.localizeResProvider.GetText("BeforeDisater");
                reportFormBO.Type = 1;
                reportFormBO.Icon = "rapid.png";
                Animals.Add(reportFormBO);
                reportFormBO = new ReportFormBO();
                reportFormBO.Type = 2;
                reportFormBO.Icon = "report1.png";
                reportFormBO.Title = App.localizeResProvider.GetText("AfterDisater");
                Animals.Add(reportFormBO);
                ItemsListView.ItemsSource = Animals;
            }
            catch (Exception ex)
            {
            }
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ReportFormBO;
            if (item == null)
                return;
            if (item.Type == 1)
            {
                await Navigation.PushAsync(new Disaster());
            }
            else
            {
                await Navigation.PushAsync(new Report());
            }
            ItemsListView.SelectedItem = null;
        }
    }
}