using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HealthTwo : ContentPage
    {
        public HealthTwo()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            btnBack.Clicked += Back_Clicked;
            btnNext.Clicked += Next_Clicked;
            Title = App.localizeResProvider.GetText("String106");
            GetData();
        }
        async void Back_Clicked(object sender, EventArgs e)
        {
            SetData();
            //Navigation.RemovePage(this);
            await Navigation.PushAsync(new Health());
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            SetData();
            //Navigation.RemovePage(this);
            await Navigation.PushAsync(new Report());
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync((new Health()));
            return base.OnBackButtonPressed();
        }
        private void SetData()
        {
            App.ListReport[1].ListQuestion[2].ListAnswer[0].Note = txtNum1a.Checked ? "1" : "0";
            App.ListReport[1].ListQuestion[2].ListAnswer[1].Note = txtNum1b.Checked ? "1" : "0";
            App.ListReport[1].ListQuestion[2].ListAnswer[2].Note = txtNumNote.Text;

            App.ListReport[1].ListQuestion[3].ListAnswer[0].Note = txt2a.Text;
            App.ListReport[1].ListQuestion[3].ListAnswer[1].Note = txt2b.Text;
            App.ListReport[1].ListQuestion[3].ListAnswer[2].Note = txt2c.Text;
        }
        private void GetData()
        {
            txtNum1a.Checked = App.ListReport[1].ListQuestion[2].ListAnswer[0].Note.Equals("1");
            txtNum1b.Checked = App.ListReport[1].ListQuestion[2].ListAnswer[1].Note.Equals("1");
            txtNumNote.Text = App.ListReport[1].ListQuestion[2].ListAnswer[2].Note;
            txt2a.Text = App.ListReport[1].ListQuestion[3].ListAnswer[0].Note;
            txt2b.Text = App.ListReport[1].ListQuestion[3].ListAnswer[1].Note;
            txt2c.Text = App.ListReport[1].ListQuestion[3].ListAnswer[2].Note;
        }

        async void txtNum1aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum1b.Checked = !checkbox.Checked;
        }
        async void txtNum1bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum1a.Checked = !checkbox.Checked;
        }
    }
}