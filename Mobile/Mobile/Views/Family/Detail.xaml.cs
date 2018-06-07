using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Common;
using Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Family
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        private Models.Family family { get; set; }
        public Detail()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            Title = App.localizeResProvider.GetText("String192");
        }
        public Detail(Models.Family family)
        {
            InitializeComponent();
            btnDelete.Clicked += DeleteItem_Clicked;
            btnEdit.Clicked += EditItem_Clicked;
            this.family = family;
            txtName.Text = family.Name;
            txtPosition.Text = family.Location != null ? family.Location.Name : "";
            txtRisk.Text = family.Risk;
        }
        private async void EditItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Create(family));
        }
        private async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            App.localizer.SetLocale(App.defaultCulture);
            var answer = await DisplayAlert(App.localizeResProvider.GetText("String177"), App.localizeResProvider.GetText("String193"), App.localizeResProvider.GetText("Yes1"), App.localizeResProvider.GetText("No1"));
            if (answer)
            {
                RestClient restClient = App.restClient;
                var result = await restClient.DeleteAsync("families", family.FamilyId);
                if (result == ApiStatusConstant.SUCCESS)
                {
                    restClient.AddEvent("DELETE_FAMILY");
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String194"), "Ok");
                    Navigation.RemovePage(this);
                }
                else
                {
                    await DisplayAlert(App.localizeResProvider.GetText("Notification"), App.localizeResProvider.GetText("String179"), "Ok");
                }
            }
        }
    }
}