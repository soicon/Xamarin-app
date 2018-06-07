using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Common;
using Mobile.Models;
using Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Family
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Create : ContentPage
    {
        private Models.Family family { get; set; }
        public List<Location> locations { get; set; }
        public Create()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            family = new Models.Family();
            Title = App.localizeResProvider.GetText("String184");
        }
        public Create(Models.Family family)
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            txtName.Text = family.Name;
            txtRisk.Text = family.Risk;
            this.family = family;
            Title = App.localizeResProvider.GetText("String185");
        }
        protected override async void OnAppearing()
        {
            try
            {
                locations = new List<Location>();
                RestClient restClient = App.restClient;
                List<Location> ListLocation = await restClient.Get<List<Location>>("locations");
                picLocation.ItemsSource = ListLocation.Select(x => x.Name).ToList();
                int index = ListLocation.IndexOf(family.Location);
                picLocation.SelectedIndex = index >= 0 ? index : 0;
                locations = ListLocation;
            }
            catch (Exception ex)
            {

            }
            base.OnAppearing();
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            Loading.IsRunning = true;
            try
            {
                App.localizer.SetLocale(App.defaultCulture);
                RestClient restClient = App.restClient;
                Models.Family family = new Models.Family();
                family.User = App.user;
                if (family.User == null)
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), "String186", "Ok");
                }
                else
                {
                    if (this.family.FamilyId == 0)
                    {
                        family.Location = locations[picLocation.SelectedIndex];
                        family.Name = txtName.Text;
                        family.Risk = txtRisk.Text;
                        family.CreatedTime = DateTime.Now;
                        var result = await restClient.PostAsync("families", family);
                        restClient.AddEvent("ADD_FAMILY");
                        if (result.Equals(ApiStatusConstant.SUCCESS))
                        {
                            await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String187"), "Ok");
                            Navigation.RemovePage(this);
                        }
                        else
                        {
                            await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String188"), "Ok");
                        }
                    }
                    else
                    {
                        var familyUpdate = await restClient.Get<Models.Family>("families/" + this.family.FamilyId);
                        if (familyUpdate != null)
                        {
                            familyUpdate.Name = txtName.Text;
                            familyUpdate.Risk = txtRisk.Text;
                            familyUpdate.User = App.user;
                            familyUpdate.Location = locations[picLocation.SelectedIndex];
                            var result = await restClient.PutAsync("families", familyUpdate, this.family.FamilyId);
                            restClient.AddEvent("EDIT_FAMILY");
                            if (result.Equals(ApiStatusConstant.SUCCESS))
                            {
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String189"), "Ok");
                                Navigation.RemovePage(this);
                            }
                            else
                            {
                                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String190"), "Ok");
                            }
                        }
                        else
                        {
                            await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String191"), "Ok");
                        }
                    }
                }
            }
            catch
            {
                await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String175"), "Ok");
            }
            Loading.IsRunning = false;
        }
    }
}