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
    public partial class HomeTwo : ContentPage
    {
        public HomeTwo()
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
            await Navigation.PushAsync(new Home());
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            SetData();
            await Navigation.PushAsync(new Report());
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync((new Home()));
            return base.OnBackButtonPressed();
        }
        private void GetData()
        {
            txtNum1a.Checked = App.ListReport[4].ListQuestion[5].ListAnswer[0].Note.Equals("1");
            txtNum1b.Checked = !string.IsNullOrEmpty(App.ListReport[4].ListQuestion[5].ListAnswer[1].Note);
            txtNum1Note.Text = App.ListReport[4].ListQuestion[5].ListAnswer[1].Note;

            txtNum2a.Checked = App.ListReport[4].ListQuestion[6].ListAnswer[0].Note.Equals("1");
            txtNum2b.Checked = !App.ListReport[4].ListQuestion[6].ListAnswer[0].Note.Equals("1");
            App.ListReport[4].ListQuestion[6].ListAnswer[1].Note = txtNum2Note1.Text;
            App.ListReport[4].ListQuestion[6].ListAnswer[2].Note = txtNum2Note2.Text;

            txtNum3a.Checked = App.ListReport[4].ListQuestion[7].ListAnswer[0].Note.Equals("1");
            txtNum3b.Checked = App.ListReport[4].ListQuestion[7].ListAnswer[1].Note.Equals("1");

            txtNum4.Text = App.ListReport[4].ListQuestion[8].ListAnswer[0].Note;

            txtNum5a.Checked = App.ListReport[4].ListQuestion[9].ListAnswer[0].Note.Equals("1");
            txtNum5b.Checked = App.ListReport[4].ListQuestion[9].ListAnswer[1].Note.Equals("1");

            txtNum6a.Checked = App.ListReport[4].ListQuestion[10].ListAnswer[0].Note.Equals("1");
            txtNum6b.Checked = !App.ListReport[4].ListQuestion[10].ListAnswer[0].Note.Equals("1");
            txtNum6Note1.Text = App.ListReport[4].ListQuestion[10].ListAnswer[1].Note;
            txtNum6Note2.Text = App.ListReport[4].ListQuestion[10].ListAnswer[2].Note;

            txtNum7a.Text = App.ListReport[4].ListQuestion[11].ListAnswer[0].Note;
            txtNum7b.Text = App.ListReport[4].ListQuestion[11].ListAnswer[1].Note;
            txtNum7c.Text = App.ListReport[4].ListQuestion[11].ListAnswer[2].Note;
        }
        private void SetData()
        {
            App.ListReport[4].ListQuestion[5].ListAnswer[0].Note = txtNum1a.Checked ? "1" : "0";
            App.ListReport[4].ListQuestion[5].ListAnswer[1].Note = txtNum1Note.Text;

            App.ListReport[4].ListQuestion[6].ListAnswer[0].Note = txtNum2a.Checked ? "1" : "0";
            App.ListReport[4].ListQuestion[6].ListAnswer[1].Note = txtNum2Note1.Text;
            App.ListReport[4].ListQuestion[6].ListAnswer[2].Note = txtNum2Note2.Text;

            App.ListReport[4].ListQuestion[7].ListAnswer[0].Note = txtNum3a.Checked ? "1" : "0";
            App.ListReport[4].ListQuestion[7].ListAnswer[1].Note = txtNum3b.Checked ? "1" : "0";

            App.ListReport[4].ListQuestion[8].ListAnswer[0].Note = txtNum4.Text;

            App.ListReport[4].ListQuestion[9].ListAnswer[0].Note = txtNum5a.Checked ? "1" : "0";
            App.ListReport[4].ListQuestion[9].ListAnswer[1].Note = txtNum5b.Checked ? "1" : "0";

            App.ListReport[4].ListQuestion[10].ListAnswer[0].Note = txtNum6a.Checked ? "1" : "0";
            App.ListReport[4].ListQuestion[10].ListAnswer[1].Note = txtNum6Note1.Text;
            App.ListReport[4].ListQuestion[10].ListAnswer[2].Note = txtNum6Note2.Text;

            App.ListReport[4].ListQuestion[11].ListAnswer[0].Note = txtNum7a.Text;
            App.ListReport[4].ListQuestion[11].ListAnswer[1].Note = txtNum7b.Text;
            App.ListReport[4].ListQuestion[11].ListAnswer[2].Note = txtNum7c.Text;
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

        async void txtNum2aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum2b.Checked = !checkbox.Checked;
        }
        async void txtNum2bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum2a.Checked = !checkbox.Checked;
        }

        async void txtNum3aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum3b.Checked = !checkbox.Checked;
        }
        async void txtNum3bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum3a.Checked = !checkbox.Checked;
        }

        async void txtNum5aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum5b.Checked = !checkbox.Checked;
        }
        async void txtNum5bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum5a.Checked = !checkbox.Checked;
        }

        async void txtNum6aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum6b.Checked = !checkbox.Checked;
        }
        async void txtNum6bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum3a.Checked = !checkbox.Checked;
        }
    }
}