using Mobile.Common;
using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactOfflineDetail : ContentPage
    {
        public ContactOfflineDetail(User user)
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            //List<User> users = new List<User>();
            //users.Add(userList);
            Title = user.Name;
            if (!string.IsNullOrEmpty(App.user.Role) && App.user.Role != "globaladmin")
            {
                this.ToolbarItems.RemoveAt(0);
                this.ToolbarItems.RemoveAt(1);
            }
            else if (user.Status == CommonConstant.USER_ACTIVE)
            {
                this.ToolbarItems.RemoveAt(0);
            }
            else if (user.Status == CommonConstant.USER_DEACTIVE)
            {
                this.ToolbarItems.RemoveAt(1);
            }
            txtFullname.Text = user.Name;
            txtBlood.Text = user.BloodType;
            txtBirthdate.Text = user.DayOfBirth.HasValue ? user.DayOfBirth.Value.ToString("dd/MM/yyyy") : "";
            txtCellPhone.Text = user.CellPhone;
            switch (user.Gender)
            {
                case "M":
                    txtGender.Text = App.localizeResProvider.GetText("String88");
                    break;
                case "F":
                    txtGender.Text = App.localizeResProvider.GetText("String89");
                    break;
                case "U":
                    txtGender.Text = App.localizeResProvider.GetText("String90");
                    break;
            }
            switch (user.Role)
            {
                case "globaladmin":
                    txtRole.Text = App.localizeResProvider.GetText("String95");
                    break;
                case "admin":
                    txtRole.Text = App.localizeResProvider.GetText("String96");
                    break;
                case "localadmin":
                    txtRole.Text = App.localizeResProvider.GetText("String97");
                    break;
                case "user":
                    txtRole.Text = App.localizeResProvider.GetText("String98");
                    break;
            }
            txtPosition.Text = user.Position;
            txtProvince.Text = user.Location != null ? user.Location.Name : "";
            txtTelephone.Text = user.DesktopPhone;
            txtUserId.Text = user.UserId;
        }
    }
}