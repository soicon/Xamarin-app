using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mobile.Common;
using Mobile.Models;
using Mobile.Repository;
using Mobile.Services;
using Mobile.SQLiteModel;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contact : ContentPage
    {
        private List<User> ListUser;
        public List<UserList> ListAllContact { get; set; }
        public Contact()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            Title = "Liên hệ";
        }
        protected override async void OnAppearing()
        {
            try
            {
                Loading.IsVisible = true;
                Loading.IsRunning = true;
                btnUnApproval.BackgroundColor = Color.FromHex("#979392");
                btnFilter.BackgroundColor = Color.FromHex("#d8192f");
                ListAllContact = new List<UserList>();
                List<User> users = new List<User>();
                RestClient restClient = App.restClient;
                var repository = App.Get<UserRepository>();
                if (App.IsConnectivity)
                {
                    #region Neu nhu co mang
                    users = await restClient.Get<List<User>>("users/all/locations/-1");
                    #endregion
                }
                else
                {
                    #region Neu nhu mat mang
                    var ListContact = repository.GetAll();
                    ListContact = ListContact.GroupBy(x => new { x.UserId, x.Name }).Select(y => y.FirstOrDefault()).ToList();
                    users = ListContact.ConvertToListUser();
                    #endregion
                }
                if (users != null)
                {
                    //Danh sach nguoi dung ma ko ton tai tren db local
                    var ListContactOnline = users.Where(x => !App.UserLites.Select(y => y.UserId).Contains(x.UserId)).ToList();
                    if (ListContactOnline.Any())
                    {
                        await CreateContact(ListContactOnline, repository);
                    }
                    ListUser = users;
                    users = users.Where(x => CommonConstant.USER_ACTIVE == x.Status).ToList();
                    users = users.OrderBy(x => x.Name).ToList();
                    var lstUserEmpty = users.Where(x => x.Location == null);
                    var lstAlphabet = users.Where(x => x.Location != null).Select(y => y.Location).ToList();
                    lstAlphabet = lstAlphabet.GroupBy(x => x.LocationId).Select(y => y.FirstOrDefault()).ToList();
                    UserList userList = null;
                    foreach (var item in lstAlphabet)
                    {
                        userList = new UserList();
                        var heading = item;
                        var lstTemp = users.Where(x => x.Location != null && x.Location.LocationId == item.LocationId).ToList();
                        userList.Heading = heading.Name;
                        userList.AddRange(lstTemp);
                        ListAllContact.Add(userList);
                    }
                    if (lstUserEmpty.Any())
                    {
                        userList = new UserList();
                        userList.Heading = "Unknow";
                        userList.AddRange(lstUserEmpty);
                        ListAllContact.Add(userList);
                    }
                    ItemsListView.ItemsSource = ListAllContact;
                }
                else
                {
                    ItemsListView.ItemsSource = ListAllContact;
                }
            }
            catch
            {

            }
            Loading.IsVisible = false;
            Loading.IsRunning = false;
            base.OnAppearing();
        }
        private void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            Loading.IsVisible = true;
            Loading.IsRunning = true;
            ListAllContact = new List<UserList>();
            try
            {
                string value = e.NewTextValue.ConvertToVN();
                List<User> users = ListUser.Where(x => !string.IsNullOrEmpty(x.Name) && x.Name.ToLower().ConvertToVN().Contains(value)).ToList();
                if (users != null)
                {
                    users = users.OrderBy(x => x.Name).ToList();
                    var lstUserEmpty = users.Where(x => x.Location == null);
                    var lstAlphabet = users.Where(x => x.Location != null).Select(y => y.Location).ToList();
                    lstAlphabet = lstAlphabet.GroupBy(x => x.LocationId).Select(y => y.FirstOrDefault()).ToList();
                    UserList userList = null;
                    foreach (var item in lstAlphabet)
                    {
                        userList = new UserList();
                        var heading = item;
                        var lstTemp = users.Where(x => x.Location != null && x.Location.LocationId == item.LocationId).ToList();
                        userList.Heading = heading.Name;
                        userList.AddRange(lstTemp);
                        ListAllContact.Add(userList);
                    }
                    userList = new UserList();
                    userList.Heading = "Unknow";
                    ListAllContact.Add(userList);
                    ItemsListView.ItemsSource = ListAllContact;
                }
                else
                {
                    ItemsListView.ItemsSource = ListAllContact;
                }
            }
            catch (Exception ex)
            {
            }
            Loading.IsVisible = false;
            Loading.IsRunning = false;
            base.OnAppearing();
        }
        async void OnButtonClicked(object sender, SelectedItemChangedEventArgs args)
        {
            try
            {
                btnUnApproval.BackgroundColor = Color.FromHex("#979392");
                btnFilter.BackgroundColor = Color.FromHex("#d8192f");
                ListAllContact = new List<UserList>();
                if (ListUser != null)
                {
                    var ListUser1 = ListUser.Where(x => CommonConstant.USER_ACTIVE == x.Status).OrderBy(x => x.Name).ToList();
                    var lstUserEmpty = ListUser.Where(x => x.Location == null);
                    var lstAlphabet = ListUser.Where(x => x.Location != null).Select(y => y.Location).ToList();
                    lstAlphabet = lstAlphabet.GroupBy(x => x.LocationId).Select(y => y.FirstOrDefault()).ToList();
                    UserList userList = null;
                    foreach (var item in lstAlphabet)
                    {
                        userList = new UserList();
                        var heading = item;
                        var lstTemp = ListUser.Where(x => x.Location != null && x.Location.LocationId == item.LocationId).ToList();
                        userList.Heading = heading.Name;
                        userList.AddRange(lstTemp);
                        ListAllContact.Add(userList);
                    }
                    userList = new UserList();
                    userList.Heading = "Unknow";
                    ListAllContact.Add(userList);
                    ItemsListView.ItemsSource = ListAllContact;
                }
                else
                {
                    ItemsListView.ItemsSource = ListAllContact;
                }
            }
            catch
            {

            }
        }

        async void OnUnAprovalClicked(object sender, SelectedItemChangedEventArgs args)
        {
            try
            {
                btnFilter.BackgroundColor = Color.FromHex("#979392");
                btnUnApproval.BackgroundColor = Color.FromHex("#d8192f");
                ListAllContact = new List<UserList>();
                List<User> users = ListUser.Where(x => x.Status == CommonConstant.USER_DEACTIVE).ToList();
                if (users != null)
                {
                    users = users.OrderBy(x => x.Name).ToList();
                    var lstUserEmpty = users.Where(x => x.Location == null);
                    var lstAlphabet = users.Where(x => x.Location != null).Select(y => y.Location).ToList();
                    lstAlphabet = lstAlphabet.GroupBy(x => x.LocationId).Select(y => y.FirstOrDefault()).ToList();
                    UserList userList = null;
                    foreach (var item in lstAlphabet)
                    {
                        userList = new UserList();
                        var heading = item;
                        var lstTemp = users.Where(x => x.Location != null && x.Location.LocationId == item.LocationId).ToList();
                        userList.Heading = heading.Name;
                        userList.AddRange(lstTemp);
                        ListAllContact.Add(userList);
                    }
                    userList = new UserList();
                    userList.Heading = "Unknow";
                    ListAllContact.Add(userList);
                    ItemsListView.ItemsSource = ListAllContact;
                }
                else
                {
                    ItemsListView.ItemsSource = ListAllContact;
                }
            }
            catch
            {

            }
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as User;
            if (item == null)
                return;
            if (App.IsConnectivity)
            {
                await Navigation.PushAsync(new UserProfile(item));
            }
            else
            {
                await Navigation.PushAsync(new Views.ContactOfflineDetail(item));
            }
            ItemsListView.SelectedItem = null;
        }
        private async Task CreateContact(List<User> ListContactOnline, UserRepository userRepository)
        {
            foreach (var item in ListContactOnline)
            {
                #region Convert Models.User to UserLite
                UserLite userLite = new UserLite();
                userLite.BloodType = item.BloodType;
                userLite.CellPhone = item.CellPhone;
                userLite.CreatedTime = item.CreatedTime;
                userLite.DayOfBirth = item.DayOfBirth;
                userLite.DesktopPhone = item.DesktopPhone;
                userLite.Gender = item.Gender;
                userLite.GPSCreateTime = item.GPSCreateTime;
                userLite.Latitude = item.Latitude;
                userLite.LocationId = item.Location.LocationId;
                userLite.LocationName = item.Location.Name;
                userLite.Longitude = item.Longitude;
                userLite.Name = item.Name;
                userLite.ObjectId = item.ObjectId;
                userLite.Password = item.Password;
                userLite.Position = item.Position;
                userLite.Role = item.Role;
                userLite.SecretCode = item.SecretCode;
                userLite.Status = item.Status;
                userLite.UserId = item.UserId;
                #endregion
                userRepository.Create(userLite);
            }
        }
    }

}