using Mobile.Common;
using Mobile.Models;
using Mobile.Models.Validate;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class RegisterPageViewModel : INotifyPropertyChanged
    {
        public Register User { get; set; }
        public User Profile { get; set; }
        public bool ErrorMessageVisiliby { get; set; }
        public ICommand OnValidationCommand { get; set; }
        public int Count { get; set; }
        public List<Role> ListGenderSelect { get; set; }
        public List<Role> ListRole { get; set; }
        public List<Location> ListProvince { get; set; }
        private DateTime? _datetime;
        public bool IsEnable { get; set; }
        public DateTime? Datetime
        {
            get => _datetime;

            set
            {
                _datetime = value;
                OnPropertyChanged();
            }
        }
        public RegisterPageViewModel()
        {
            User = new Register();
            IsEnable = true;
            InitData();
            Count = 0;
            OnValidationCommand = new Command((obj) =>
            {
                Count = 0;
                App.localizer.SetLocale(App.defaultCulture);

                User.DesktopPhone.NotValidMessageError = App.localizeResProvider.GetText("String220");
                User.DesktopPhone.IsNotValid = string.IsNullOrEmpty(User.DesktopPhone.Name);
                if (User.DesktopPhone.IsNotValid)
                {
                    Count++;
                }
                else if (!Regex.Match(User.CellPhone.Name, @"^[0-9][0-9]{8,}$").Success)
                {
                    User.CellPhone.NotValidMessageError = App.localizeResProvider.GetText("String227");
                    User.CellPhone.IsNotValid = true;
                    Count++;
                }
                User.UserId.NotValidMessageError = App.localizeResProvider.GetText("String221");
                User.UserId.IsNotValid = string.IsNullOrEmpty(User.UserId.Name);
                if (User.UserId.IsNotValid)
                {
                    Count++;
                }
                if (!string.IsNullOrEmpty(User.UserId.Name))
                {
                    User.UserId.NotValidMessageError = App.localizeResProvider.GetText("String225");
                    User.UserId.IsNotValid = !CommonValidate.IsValidEmail(User.UserId.Name);
                    if (User.UserId.IsNotValid)
                    {
                        Count++;
                    }
                    if (!User.UserId.IsNotValid)
                    {
                        if (App.ListContact.Any())
                        {
                            int count = App.ListContact.Where(x => x.UserId.ToLower().Equals(User.UserId.Name)).Count();
                            if (count > 0 && !string.IsNullOrEmpty(User.IsCreated.Name))
                            {
                                User.UserId.NotValidMessageError = App.localizeResProvider.GetText("String226");
                                User.UserId.IsNotValid = !CommonValidate.IsValidEmail(User.UserId.Name);
                                if (User.UserId.IsNotValid)
                                {
                                    Count++;
                                }
                            }
                        }
                    }
                }
                User.Position.NotValidMessageError = App.localizeResProvider.GetText("String223");
                User.Position.IsNotValid = string.IsNullOrEmpty(User.Position.Name);
                if (User.Position.IsNotValid)
                {
                    Count++;
                }

                User.BloodType.NotValidMessageError = App.localizeResProvider.GetText("String222");
                User.BloodType.IsNotValid = string.IsNullOrEmpty(User.BloodType.Name);
                if (User.BloodType.IsNotValid)
                {
                    Count++;
                }

                User.CellPhone.NotValidMessageError = App.localizeResProvider.GetText("String224");
                User.CellPhone.IsNotValid = string.IsNullOrEmpty(User.CellPhone.Name);
                if (User.CellPhone.IsNotValid)
                {
                    Count++;
                }
                else if (!Regex.Match(User.CellPhone.Name, @"^[0-9][0-9]{8,}$").Success)
                {
                    User.CellPhone.NotValidMessageError = App.localizeResProvider.GetText("String227");
                    User.CellPhone.IsNotValid = true;
                    Count++;
                }
                if (Count == 0)
                {
                    SaveUser();
                }
            });
        }
        public RegisterPageViewModel(Register register, User user)
        {
            IsEnable = false;
            InitData();
            Profile = user;
            User = register;
            Count = 0;
            Datetime = user.DayOfBirth;
            Role role = ListRole.Where(x => x.Value.Equals(user.Role)).FirstOrDefault();
            Role gender = ListGenderSelect.Where(x => x.Value.Equals(user.Gender)).FirstOrDefault();
            SelectedRole = role;
            SelectedGender = gender;
            SelectedProvince = user.Location;
            OnValidationCommand = new Command((obj) =>
           {
               Count = 0;
               if (User.DesktopPhone == null)
               {
                   User.DesktopPhone = new Field();
               }
               if (User.UserId == null)
               {
                   User.UserId = new Field();
               }
               if (User.Password == null)
               {
                   User.Password = new Field();
               }
               User.DesktopPhone.NotValidMessageError = App.localizeResProvider.GetText("String220");
               User.DesktopPhone.IsNotValid = string.IsNullOrEmpty(User.DesktopPhone.Name);
               if (User.DesktopPhone.IsNotValid)
               {
                   Count++;
               }
               else if (!Regex.Match(User.CellPhone.Name, @"^[0-9][0-9]{8,}$").Success)
               {
                   User.CellPhone.NotValidMessageError = App.localizeResProvider.GetText("String227");
                   User.CellPhone.IsNotValid = true;
                   Count++;
               }
               User.UserId.NotValidMessageError = App.localizeResProvider.GetText("String221");
               User.UserId.IsNotValid = string.IsNullOrEmpty(User.UserId.Name);
               if (User.UserId.IsNotValid)
               {
                   Count++;
               }
               if (!string.IsNullOrEmpty(User.UserId.Name))
               {
                   User.UserId.NotValidMessageError = App.localizeResProvider.GetText("String225");
                   User.UserId.IsNotValid = !CommonValidate.IsValidEmail(User.UserId.Name);
                   if (User.UserId.IsNotValid)
                   {
                       Count++;
                   }
                   if (!User.UserId.IsNotValid)
                   {
                       if (App.ListContact.Any())
                       {
                           int count = App.ListContact.Where(x => x.UserId.ToLower().Equals(User.UserId.Name)).Count();
                           if (count > 0 && !string.IsNullOrEmpty(User.IsCreated.Name))
                           {
                               User.UserId.NotValidMessageError = App.localizeResProvider.GetText("String226");
                               User.UserId.IsNotValid = !CommonValidate.IsValidEmail(User.UserId.Name);
                               if (User.UserId.IsNotValid)
                               {
                                   Count++;
                               }
                           }
                       }
                   }
               }
               User.Position.NotValidMessageError = App.localizeResProvider.GetText("String223");
               User.Position.IsNotValid = string.IsNullOrEmpty(User.Position.Name);
               if (User.Position.IsNotValid)
               {
                   Count++;
               }

               User.BloodType.NotValidMessageError = App.localizeResProvider.GetText("String222");
               User.BloodType.IsNotValid = string.IsNullOrEmpty(User.BloodType.Name);
               if (User.BloodType.IsNotValid)
               {
                   Count++;
               }

               User.CellPhone.NotValidMessageError = App.localizeResProvider.GetText("String224");
               User.CellPhone.IsNotValid = string.IsNullOrEmpty(User.CellPhone.Name);
               if (User.CellPhone.IsNotValid)
               {
                   Count++;
               }
               else if (!Regex.Match(User.CellPhone.Name, @"^[0-9][0-9]{8,}$").Success)
               {
                   User.CellPhone.NotValidMessageError = App.localizeResProvider.GetText("String227");
                   User.CellPhone.IsNotValid = true;
                   Count++;
               }
               if (Count == 0)
               {
                   SaveUser();
               }
           });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private async void SaveUser()
        {
            App.localizer.SetLocale(App.defaultCulture);
            try
            {
                App.localizer.SetLocale(App.defaultCulture);
                RestClient restClient = App.restClient;
                if (Profile == null || Profile.UserId == null)
                {
                    User user = new User();
                    user.Name = User.Name.Name;
                    user.Gender = _selectedGender != null ? _selectedGender.Value : "";
                    user.Role = _selectedRole != null ? _selectedRole.Value : "";
                    user.DayOfBirth = Datetime;
                    user.BloodType = User.BloodType.Name;
                    user.CellPhone = User.CellPhone.Name;
                    user.DesktopPhone = User.DesktopPhone.Name;
                    user.UserId = User.UserId.Name;
                    user.Status = CommonConstant.USER_DEACTIVE;
                    user.CreatedTime = DateTime.Now;
                    user.GPSCreateTime = DateTime.Now;
                    user.Position = User.Position.Name;
                    user.Location = _selectedProvince;
                    string result = null;
                    result = await restClient.PostAsync("users", user);
                    restClient.AddEvent("ADD_USERS");
                    if (result.Equals(ApiStatusConstant.SUCCESS))
                    {
                        await App.Current.MainPage.DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String172"), "Ok");
                        App.bottomTabbedPage.CurrentPage = App.bottomTabbedPage.Children[2];
                        User = new Register();
                        Datetime = null;
                        SelectedRole = new Role();
                        SelectedGender = new Role();
                        SelectedProvince = new Location();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String174"), "Ok");
                    }
                }
                else
                {
                    Profile.Name = User.Name.Name;
                    Profile.Gender = _selectedGender != null ? _selectedGender.Value : "";
                    Profile.Role = _selectedRole != null ? _selectedRole.Value : "";
                    Profile.DayOfBirth = Datetime;
                    Profile.BloodType = User.BloodType.Name;
                    Profile.CellPhone = User.CellPhone.Name;
                    Profile.DesktopPhone = User.DesktopPhone.Name;
                    Profile.Position = User.Position.Name;
                    Profile.Location = _selectedProvince;
                    string result = null;
                    result = await restClient.PutAsync("users", Profile, Profile.UserId);
                    restClient.AddEvent("UPDATE_USERS");
                    if (result.Equals(ApiStatusConstant.SUCCESS))
                    {
                        if (App.user.UserId == Profile.UserId)
                        {
                            App.user = Profile;
                        }
                        await App.Current.MainPage.DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String173"), "Ok");
                        App.bottomTabbedPage.CurrentPage = App.bottomTabbedPage.Children[2];
                        User = new Register();
                        Datetime = null;
                        SelectedRole = new Role();
                        SelectedGender = new Role();
                        SelectedProvince = new Location();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String179"), "Ok");
                    }
                }
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String175"), "Ok");
            }
        }
        private async void InitData()
        {
            RestClient restClient = App.restClient;
            ListProvince = new List<Location>();
            ListProvince = await restClient.Get<List<Location>>("locations");
            ListRole = new List<Role>();
            ListRole.Add(new Role() { Name = App.localizeResProvider.GetText("String95"), Value = "globaladmin" });
            ListRole.Add(new Role() { Name = App.localizeResProvider.GetText("String96"), Value = "admin" });
            ListRole.Add(new Role() { Name = App.localizeResProvider.GetText("String97"), Value = "localadmin" });
            ListRole.Add(new Role() { Name = App.localizeResProvider.GetText("String98"), Value = "user" });
            ListGenderSelect = new List<Role>();
            ListGenderSelect.Add(new Role() { Name = App.localizeResProvider.GetText("String88"), Value = "M" });
            ListGenderSelect.Add(new Role() { Name = App.localizeResProvider.GetText("String89"), Value = "F" });
            ListGenderSelect.Add(new Role() { Name = App.localizeResProvider.GetText("String90"), Value = "U" });
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private Role _selectedRole { get; set; }
        public Role SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                if (_selectedRole != value)
                {
                    _selectedRole = value;
                }
            }
        }
        private Role _selectedGender { get; set; }
        public Role SelectedGender
        {
            get { return _selectedGender; }
            set
            {
                if (_selectedGender != value)
                {
                    _selectedGender = value;
                }
            }
        }
        private Location _selectedProvince { get; set; }
        public Location SelectedProvince
        {
            get { return _selectedProvince; }
            set
            {
                if (_selectedProvince != value)
                {
                    _selectedProvince = value;
                }
            }
        }
    }
}
