using System;
using System.Collections.Generic;
using System.Linq;
using Mobile.Common;
using Mobile.Models;
using Mobile.Repository;
using Mobile.Services;
using Mobile.SQLiteModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetail : ContentPage
    {
        private User user;
        public ContactDetail(User userList)
        {
            InitializeComponent();
            List<User> users = new List<User>();
            users.Add(userList);
            listViewContact.ItemsSource = users;
            Title = userList.Name;
            btnDelete.Clicked += DeleteItem_Clicked;
            btnEdit.Clicked += EditItem_Clicked;
            user = userList;
            btnActive.Clicked += ActiveItem_Clicked;
            btnDeactive.Clicked += DeactiveItem_Clicked;
            if (!string.IsNullOrEmpty(App.user.Role) && App.user.Role != "globaladmin")
            {
                this.ToolbarItems.RemoveAt(0);
                this.ToolbarItems.RemoveAt(1);
            }
            else if (userList.Status == CommonConstant.USER_ACTIVE)
            {
                this.ToolbarItems.RemoveAt(0);
            }
            else if (userList.Status == CommonConstant.USER_DEACTIVE)
            {
                this.ToolbarItems.RemoveAt(1);
            }

        }
        private async void EditItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync((new Register(user)));
        }
        private async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            App.localizer.SetLocale(App.defaultCulture);
            var answer = await DisplayAlert(App.localizeResProvider.GetText("String177"), App.localizeResProvider.GetText("String176"), App.localizeResProvider.GetText("Yes1"), App.localizeResProvider.GetText("No1"));
            if (answer)
            {
                RestClient restClient = App.restClient;
                var result = await restClient.DeleteAsync("users", user.UserId);
                if (result == ApiStatusConstant.SUCCESS)
                {
                    UserLite userLite = App.UserLites.Where(x => x.UserId.Equals(user.UserId)).FirstOrDefault();
                    if (userLite != null)
                    {
                        var repository = App.Get<UserRepository>();
                        repository.Delete(userLite);
                    }
                    App.UserLites = App.UserLites.Where(x => !x.UserId.Equals(user.UserId)).ToList();

                    restClient.AddEvent("DELETE_USER");
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String178"), "Ok");
                    var existingPages = Navigation.NavigationStack.ToList();
                    for (int i = 1; i < existingPages.Count; i++)
                    {
                        Navigation.RemovePage(existingPages[i]);
                    }
                }
                else
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String179"), "Ok");
                }
            }
        }
        private async void ActiveItem_Clicked(object sender, EventArgs e)
        {
            App.localizer.SetLocale(App.defaultCulture);
            var answer = await DisplayAlert("Active user", App.localizeResProvider.GetText("String180"), App.localizeResProvider.GetText("Yes1"), App.localizeResProvider.GetText("No1"));
            if (answer)
            {
                RestClient restClient = App.restClient;
                List<User> ListUser = new List<User>();
                ListUser.Add(user);
                var result = await restClient.PostAsync("users/approve", ListUser);
                if (result == ApiStatusConstant.SUCCESS)
                {
                    restClient.AddEvent("APPROVE_USER");
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String181"), "Ok");
                    var existingPages = Navigation.NavigationStack.ToList();
                    for (int i = 1; i < existingPages.Count; i++)
                    {
                        Navigation.RemovePage(existingPages[i]);
                    }
                }
                else
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String179"), "Ok");
                }
            }
        }
        private async void DeactiveItem_Clicked(object sender, EventArgs e)
        {
            App.localizer.SetLocale(App.defaultCulture);
            var answer = await DisplayAlert("Deactive user", App.localizeResProvider.GetText("String182"), App.localizeResProvider.GetText("Yes1"), App.localizeResProvider.GetText("No1"));
            if (answer)
            {
                RestClient restClient = App.restClient;
                List<User> ListUser = new List<User>();
                ListUser.Add(user);
                var result = await restClient.PostAsync("users/disable", ListUser);
                if (result == ApiStatusConstant.SUCCESS)
                {
                    restClient.AddEvent("DISABLE_USER");
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String183"), "Ok");
                    var existingPages = Navigation.NavigationStack.ToList();
                    for (int i = 1; i < existingPages.Count; i++)
                    {
                        Navigation.RemovePage(existingPages[i]);
                    }
                }
                else
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String179"), "Ok");
                }
            }
        }
    }
}