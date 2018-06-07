using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Common;
using Mobile.Models;
using Mobile.Models.Validate;
using Mobile.Services;
using Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public DateTime? MyDate { get; set; }
        private User profile { get; set; }
        public Register()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            profile = new User();
            Title = App.localizeResProvider.GetText("String216");
            this.BindingContext = new RegisterPageViewModel();
        }

        public Register(User user)
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            Title = App.localizeResProvider.GetText("String217");
            this.BindingContext = new RegisterPageViewModel(user.ConvertToUser(), user);
        }
    }
}