using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Common;
using Mobile.Models;
using Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Users
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public List<Location> ListProvince { get; set; }
        public List<Location> ListWard { get; set; }
        private List<string> ListGender { get; set; }
        private List<string> ListRole { get; set; }
        public DateTime? MyDate { get; set; }
        private User profile { get; set; }
        public Profile()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            profile = App.user;
            txtFullname.Text = profile.Name;
            txtPosition.Text = profile.Position;
            txtBlood.Text = profile.BloodType;
            txtPhone.Text = profile.CellPhone;
            txtTelephone.Text = profile.DesktopPhone;
            txtEmail.Text = profile.UserId;
            btnSave.Clicked += Save_Clicked;
            MyDate = profile.DayOfBirth;
            Title = App.localizeResProvider.GetText("String199");
        }
        protected override async void OnAppearing()
        {
            Loading.IsRunning = true;
            try
            {
                RestClient restClient = App.restClient;
                ListProvince = new List<Location>();
                ListWard = new List<Location>();
                List<Location> ListLocation = await restClient.Get<List<Location>>("locations");
                picProvince.ItemsSource = ListLocation.Select(x => x.Name).ToList();
                int index = ListLocation.IndexOf(profile.Location);
                picProvince.SelectedIndex = index >= 0 ? index : 0;
                ListProvince = ListLocation;
                picWard.ItemsSource = ListLocation.Select(x => x.Name).ToList();
                picWard.SelectedIndex = index >= 0 ? index : 0;
                ListWard = ListLocation;
                ListGender = new List<string>();
                ListGender.Add("M");
                ListGender.Add("F");
                ListGender.Add("U");
                picGender.SelectedIndex = ListGender.IndexOf(profile.Gender);
                ListRole = new List<string>();
                ListRole.Add("A");
                ListRole.Add("B");
                ListRole.Add("C");
                picRole.SelectedIndex = ListRole.IndexOf(profile.Role);
            }
            catch (Exception ex)
            {

            }
            Loading.IsRunning = false;
            base.OnAppearing();
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            Loading.IsRunning = true;
            try
            {
                App.localizer.SetLocale(App.defaultCulture);
                RestClient restClient = App.restClient;
                User user = new User();
                user.Name = txtFullname.Text;
                user.Gender = ListGender[picGender.SelectedIndex];
                user.Role = ListRole[picRole.SelectedIndex];
                user.DayOfBirth = txtBirthdate.Date;
                user.BloodType = txtBlood.Text;
                user.CellPhone = txtPhone.Text;
                user.DesktopPhone = txtTelephone.Text;
                user.UserId = txtEmail.Text;
                //user.Status = CommonConstant.USER_DEACTIVE;
                user.CreatedTime = DateTime.Now;
                user.GPSCreateTime = DateTime.Now;
                user.Position = txtPosition.Text;
                user.Location = ListProvince[picProvince.SelectedIndex];
                var result = await restClient.PutAsync("users", user, user.UserId);
                restClient.AddEvent("UPDATE_PROFILE");
                if (result.Equals(ApiStatusConstant.SUCCESS))
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String200"), "Ok");
                    var existingPages = Navigation.NavigationStack.ToList();
                    for (int i = 1; i < existingPages.Count; i++)
                    {
                        Navigation.RemovePage(existingPages[i]);
                    }
                }
                else
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String201"), "Ok");
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