
using Naxam.I18n;
using Naxam.I18n.Forms;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Language : ContentPage
    {
        public Language()
        {
            InitializeComponent();
            btnEnglish.Clicked += English_Clicked;
            btnVietnamese.Clicked += Vietnam_Clicked;
            Title = "Cài đặt ngôn ngữ";
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
        async void Vietnam_Clicked(object sender, EventArgs e)
        {
            var getter = DependencyService.Get<IDependencyGetter>();
            var localizer = getter.Get<ILocalizer>();
            var localizeResProvider = getter.Get<ILocalizedResourceProvider>();
            var defaultCulture = localizer.GetCurrentCultureInfo();
            localizer.SetLocale(defaultCulture);
            btnVietnamese.Text = localizeResProvider.GetText("Vietnamese");
            btnEnglish.Text = localizeResProvider.GetText("English");
        }
        async void English_Clicked(object sender, EventArgs e)
        {
            var getter = DependencyService.Get<IDependencyGetter>();
            var localizer = getter.Get<ILocalizer>();
            var localizeResProvider = getter.Get<ILocalizedResourceProvider>();
            var enCulture = new CultureInfo("en-US");
            localizer.SetLocale(enCulture);
            btnVietnamese.Text = localizeResProvider.GetText("Vietnamese");
            btnEnglish.Text = localizeResProvider.GetText("English");
        }
    }
}