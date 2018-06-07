using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            btnBack.Clicked += Back_Clicked;
            btnNext.Clicked += Next_Clicked;
            Title = App.localizeResProvider.GetText("String109");
            GetData();
        }
        async void Back_Clicked(object sender, EventArgs e)
        {
            SetData();
            //Navigation.RemovePage(this);
            await Navigation.PushAsync(new Report());
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            SetData();
            //Navigation.RemovePage(this);
            await Navigation.PushAsync(new HomeTwo());
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync((new Report()));
            return base.OnBackButtonPressed();
        }
        private void SetData()
        {
            App.ListReport[4].ListQuestion[0].ListAnswer[0].Note = txtNum1.Text;

            App.ListReport[4].ListQuestion[1].ListAnswer[0].Note = txtNum2.Text;

            App.ListReport[4].ListQuestion[2].ListAnswer[0].Note = txtNum3aAns.Text;
            App.ListReport[4].ListQuestion[2].ListAnswer[1].Note = txtNum3bAns.Text;
            App.ListReport[4].ListQuestion[2].ListAnswer[2].Note = txtNum3cAns.Text;
            App.ListReport[4].ListQuestion[2].ListAnswer[3].Note = txtNum3dAns.Text;

            App.ListReport[4].ListQuestion[3].ListAnswer[0].Note = txtNum4a.Checked ? "1" : "0";
            App.ListReport[4].ListQuestion[3].ListAnswer[1].Note = txtNum4b.Checked ? "1" : "0";
            App.ListReport[4].ListQuestion[3].ListAnswer[2].Note = txtNum4c.Checked ? "1" : "0";
            //App.ListReport[4].ListQuestion[3].ListAnswer[3].Note = txtNum4d.Checked ? "1" : "0";
            App.ListReport[4].ListQuestion[3].ListAnswer[3].Note = txtNum4Note.Text;

            App.ListReport[4].ListQuestion[4].ListAnswer[0].Note = txtNum5a1.Checked ? "1" : "0";
            App.ListReport[4].ListQuestion[4].ListAnswer[1].Note = txtNum5a2.Checked ? "1" : "0";
        }
        public void GetData()
        {
            txtNum1.Text = App.ListReport[4].ListQuestion[0].ListAnswer[0].Note;

            txtNum2.Text = App.ListReport[4].ListQuestion[1].ListAnswer[0].Note;

            txtNum3a.Checked = !string.IsNullOrEmpty(App.ListReport[4].ListQuestion[2].ListAnswer[0].Note);
            txtNum3b.Checked = !string.IsNullOrEmpty(App.ListReport[4].ListQuestion[2].ListAnswer[1].Note);
            txtNum3c.Checked = !string.IsNullOrEmpty(App.ListReport[4].ListQuestion[2].ListAnswer[2].Note);
            txtNum3d.Checked = !string.IsNullOrEmpty(App.ListReport[4].ListQuestion[2].ListAnswer[3].Note);
            txtNum3aAns.Text = App.ListReport[4].ListQuestion[2].ListAnswer[0].Note;
            txtNum3bAns.Text = App.ListReport[4].ListQuestion[2].ListAnswer[1].Note;
            txtNum3cAns.Text = App.ListReport[4].ListQuestion[2].ListAnswer[2].Note;
            txtNum3dAns.Text = App.ListReport[4].ListQuestion[2].ListAnswer[3].Note;

            txtNum4a.Checked = App.ListReport[4].ListQuestion[3].ListAnswer[0].Note.Equals("1");
            txtNum4b.Checked = App.ListReport[4].ListQuestion[3].ListAnswer[1].Note.Equals("1");
            txtNum4c.Checked = App.ListReport[4].ListQuestion[3].ListAnswer[2].Note.Equals("1");
            txtNum4d.Checked = App.ListReport[4].ListQuestion[3].ListAnswer[3].Note.Equals("1");
            txtNum4d.Checked = !string.IsNullOrEmpty(App.ListReport[4].ListQuestion[3].ListAnswer[3].Note);
            txtNum4Note.Text = App.ListReport[4].ListQuestion[3].ListAnswer[3].Note;

            txtNum5a1.Checked = App.ListReport[4].ListQuestion[4].ListAnswer[0].Note.Equals("1");
            txtNum5b1.Checked = !App.ListReport[4].ListQuestion[4].ListAnswer[0].Note.Equals("1");
            txtNum5a2.Checked = App.ListReport[4].ListQuestion[4].ListAnswer[1].Note.Equals("1");
            txtNum5b2.Checked = !App.ListReport[4].ListQuestion[4].ListAnswer[1].Note.Equals("1");

        }

        async void txtNum5a1ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum5a2.Checked = !checkbox.Checked;
        }
        async void txtNum5a2ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum5a1.Checked = !checkbox.Checked;
        }

        async void txtNum5b1ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum5b2.Checked = !checkbox.Checked;
        }
        async void txtNum5b2ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum5b1.Checked = !checkbox.Checked;
        }
    }
}