using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Health : ContentPage
    {
        public Health()
        {
            InitializeComponent();
			btnBack.Clicked += Back_Clicked;
            btnNext.Clicked += Next_Clicked;
            GetData();
            App.localizer.SetLocale(App.defaultCulture);
            Title = App.localizeResProvider.GetText("String106");
        }
        async void Back_Clicked(object sender, EventArgs e)
        {
            SetData();

            await Navigation.PushAsync(new Report());
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            SetData();

            await Navigation.PushAsync(new HealthTwo());
        }
        private void SetData()
        {
            App.ListReport[1].ListQuestion[0].ListAnswer[0].Note = txtNum1a.Checked ? "1" : "0";
            App.ListReport[1].ListQuestion[0].ListAnswer[1].Note = txtNum1b.Checked ? "1" : "0";
            App.ListReport[1].ListQuestion[0].ListAnswer[2].Note = txtNum11.Text;
            App.ListReport[1].ListQuestion[0].ListAnswer[3].Note = txtNum12.Text;
            App.ListReport[1].ListQuestion[0].ListAnswer[4].Note = txtNum13.Text;
            App.ListReport[1].ListQuestion[0].ListAnswer[5].Note = txtNum14.Text;

            App.ListReport[1].ListQuestion[1].ListAnswer[0].Note = txt2a.Checked ? "1" : "0";
            App.ListReport[1].ListQuestion[1].ListAnswer[1].Note = txt2b.Checked ? "1" : "0";
            App.ListReport[1].ListQuestion[1].ListAnswer[2].Note = txt21.Text;
            App.ListReport[1].ListQuestion[1].ListAnswer[3].Note = txt22.Text;
            App.ListReport[1].ListQuestion[1].ListAnswer[4].Note = txt23.Text;
        }
        private void GetData()
        {
            txtNum1a.Checked = App.ListReport[1].ListQuestion[0].ListAnswer[0].Note.Equals("1");
            txtNum1b.Checked = App.ListReport[1].ListQuestion[0].ListAnswer[1].Note.Equals("1");
            txtNum11.Text = App.ListReport[1].ListQuestion[0].ListAnswer[2].Note;
            txtNum12.Text = App.ListReport[1].ListQuestion[0].ListAnswer[3].Note;
            txtNum13.Text = App.ListReport[1].ListQuestion[0].ListAnswer[4].Note;
            txtNum14.Text = App.ListReport[1].ListQuestion[0].ListAnswer[5].Note;
            txt21.Text = App.ListReport[1].ListQuestion[1].ListAnswer[2].Note;
            txt22.Text = App.ListReport[1].ListQuestion[1].ListAnswer[3].Note;
            txt23.Text = App.ListReport[1].ListQuestion[1].ListAnswer[4].Note;
            txt2a.Checked = App.ListReport[1].ListQuestion[1].ListAnswer[0].Note.Equals("1");
            txt2b.Checked = App.ListReport[1].ListQuestion[1].ListAnswer[1].Note.Equals("1");
        }
    }
}