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
    public partial class Food : ContentPage
    {
        public Food()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            btnBack.Clicked += Back_Clicked;
            btnNext.Clicked += Next_Clicked;
            Title = App.localizeResProvider.GetText("String108");
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
            await Navigation.PushAsync(new FoodTwo());
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync((new Report()));
            return base.OnBackButtonPressed();
        }
        private void SetData()
        {
            App.ListReport[3].ListQuestion[0].ListAnswer[0].Note = txtNum1a.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[0].ListAnswer[1].Note = txtNum1b.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[0].ListAnswer[2].Note = txtNum1Note.Text;

            App.ListReport[3].ListQuestion[1].ListAnswer[0].Note = txtNum2a.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[1].ListAnswer[1].Note = txtNum2b.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[1].ListAnswer[2].Note = txtNum2Note.Text;

            App.ListReport[3].ListQuestion[2].ListAnswer[0].Note = txtNum3.Text;

            App.ListReport[3].ListQuestion[3].ListAnswer[0].Note = txtNum4a.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[3].ListAnswer[1].Note = txtNum4b.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[3].ListAnswer[2].Note = txtNum4c.Text;
            App.ListReport[3].ListQuestion[3].ListAnswer[3].Note = txtNum4d.Text;

            App.ListReport[3].ListQuestion[4].ListAnswer[0].Note = txtNum5a.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[4].ListAnswer[1].Note = txtNum5b.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[4].ListAnswer[2].Note = txtNum5Note.Text;

            App.ListReport[3].ListQuestion[5].ListAnswer[0].Note = txtNum6a.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[5].ListAnswer[1].Note = txtNum6b.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[5].ListAnswer[2].Note = txtNum6c.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[5].ListAnswer[3].Note = txtNum6d.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[5].ListAnswer[4].Note = txtNum6e.Checked ? "1" : "0";

        }
        private void GetData()
        {
            txtNum1a.Checked = App.ListReport[3].ListQuestion[0].ListAnswer[0].Note.Equals("1");
            txtNum1b.Checked = App.ListReport[3].ListQuestion[0].ListAnswer[1].Note.Equals("1");
            txtNum1Note.Text = App.ListReport[3].ListQuestion[0].ListAnswer[2].Note;

            txtNum2a.Checked = App.ListReport[3].ListQuestion[1].ListAnswer[0].Note.Equals("1");
            txtNum2b.Checked = App.ListReport[3].ListQuestion[1].ListAnswer[1].Note.Equals("1");
            txtNum2Note.Text = App.ListReport[3].ListQuestion[1].ListAnswer[2].Note;

            txtNum3.Text = App.ListReport[3].ListQuestion[2].ListAnswer[0].Note;

            txtNum4a.Checked = App.ListReport[3].ListQuestion[3].ListAnswer[0].Note.Equals("1");
            txtNum4b.Checked = App.ListReport[3].ListQuestion[3].ListAnswer[1].Note.Equals("1");
            txtNum4c.Text = App.ListReport[3].ListQuestion[3].ListAnswer[2].Note;
            txtNum4d.Text = App.ListReport[3].ListQuestion[3].ListAnswer[3].Note;

            txtNum5a.Checked = App.ListReport[3].ListQuestion[4].ListAnswer[0].Note.Equals("1");
            txtNum5b.Checked = App.ListReport[3].ListQuestion[4].ListAnswer[1].Note.Equals("1");
            txtNum5Note.Text = App.ListReport[3].ListQuestion[4].ListAnswer[2].Note;

            txtNum6a.Checked = App.ListReport[3].ListQuestion[5].ListAnswer[0].Note.Equals("1");
            txtNum6b.Checked = App.ListReport[3].ListQuestion[5].ListAnswer[1].Note.Equals("1");
            txtNum6c.Checked = App.ListReport[3].ListQuestion[5].ListAnswer[2].Note.Equals("1");
            txtNum6d.Checked = App.ListReport[3].ListQuestion[5].ListAnswer[3].Note.Equals("1");
            txtNum6e.Checked = App.ListReport[3].ListQuestion[5].ListAnswer[4].Note.Equals("1");
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

        async void txtNum4aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum4b.Checked = !checkbox.Checked;
        }
        async void txtNum4bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum4a.Checked = !checkbox.Checked;
        }

        async void txtNum5bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum5a.Checked = !checkbox.Checked;
        }
        async void txtNum5aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum5b.Checked = !checkbox.Checked;
        }
    }
}