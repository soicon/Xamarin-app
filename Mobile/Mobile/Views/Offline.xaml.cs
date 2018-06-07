
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Offline : ContentPage
    {
        public Offline()
        {
            InitializeComponent();
            //BindingContext = new LoginPageViewModel(Navigation);
        }
    }
}