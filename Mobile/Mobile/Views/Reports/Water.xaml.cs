using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Water : ContentPage
    {
        public Water()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            btnBack.Clicked += Back_Clicked;
            btnNext.Clicked += Next_Clicked;
            
            Title = App.localizeResProvider.GetText("String107");
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
            await Navigation.PushAsync(new WaterTwo());
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync((new Report()));
            return base.OnBackButtonPressed();
        }
        public void SetData()
        {
            App.ListReport[2].ListQuestion[0].ListAnswer[0].Note = txtNum1a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[0].ListAnswer[1].Note = txtNum1b.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[1].ListAnswer[0].Note = txtNum2.Text;
            App.ListReport[2].ListQuestion[2].ListAnswer[0].Note = txtNum3a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[2].ListAnswer[1].Note = txtNum3b.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[2].ListAnswer[2].Note = txtNum3c.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[2].ListAnswer[3].Note = txtNum3d.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[2].ListAnswer[4].Note = txtNum3e.Checked ? "1" : "0";

            App.ListReport[2].ListQuestion[3].ListAnswer[0].Note = txtNum4a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[3].ListAnswer[1].Note = txtNum4b.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[3].ListAnswer[2].Note = txtNum4c.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[3].ListAnswer[3].Note = txtNum4Note.Text;

            App.ListReport[2].ListQuestion[4].ListAnswer[0].Note = txtNum5a.Text;
            App.ListReport[2].ListQuestion[4].ListAnswer[1].Note = txtNum5b.Text;

            App.ListReport[2].ListQuestion[5].ListAnswer[0].Note = txtNum6a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[5].ListAnswer[1].Note = txtNum6b.Checked ? "1" : "0";

            App.ListReport[2].ListQuestion[6].ListAnswer[0].Note = txtNum7.Text;

            App.ListReport[2].ListQuestion[7].ListAnswer[0].Note = txtNum8a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[7].ListAnswer[1].Note = txtNum8b.Checked ? "1" : "0";
        }
        public void GetData()
        {
            txtNum1a.Checked = App.ListReport[2].ListQuestion[0].ListAnswer[0].Note.Equals("1");
            txtNum1b.Checked = App.ListReport[2].ListQuestion[0].ListAnswer[1].Note.Equals("1");
            App.ListReport[2].ListQuestion[1].ListAnswer[0].Note = txtNum2.Text;
            txtNum3a.Checked = App.ListReport[2].ListQuestion[2].ListAnswer[0].Note.Equals("1");
            txtNum3b.Checked = App.ListReport[2].ListQuestion[2].ListAnswer[1].Note.Equals("1");
            txtNum3c.Checked = App.ListReport[2].ListQuestion[2].ListAnswer[2].Note.Equals("1");
            txtNum3d.Checked = App.ListReport[2].ListQuestion[2].ListAnswer[3].Note.Equals("1");
            txtNum3e.Checked = App.ListReport[2].ListQuestion[2].ListAnswer[4].Note.Equals("1");

            txtNum4a.Checked = App.ListReport[2].ListQuestion[3].ListAnswer[0].Note.Equals("1");
            txtNum4b.Checked = App.ListReport[2].ListQuestion[3].ListAnswer[1].Note.Equals("1");
            txtNum4c.Checked = App.ListReport[2].ListQuestion[3].ListAnswer[2].Note.Equals("1");
            txtNum4Note.Text = App.ListReport[2].ListQuestion[3].ListAnswer[3].Note;

            App.ListReport[2].ListQuestion[4].ListAnswer[0].Note = txtNum5a.Text;
            App.ListReport[2].ListQuestion[4].ListAnswer[1].Note = txtNum5b.Text;

            txtNum6a.Checked = App.ListReport[2].ListQuestion[5].ListAnswer[0].Note.Equals("1");
            txtNum6b.Checked = App.ListReport[2].ListQuestion[5].ListAnswer[1].Note.Equals("1");

            txtNum7.Text = App.ListReport[2].ListQuestion[6].ListAnswer[0].Note;

            txtNum8a.Checked = App.ListReport[2].ListQuestion[7].ListAnswer[0].Note.Equals("1");
            txtNum8b.Checked = App.ListReport[2].ListQuestion[7].ListAnswer[1].Note.Equals("1");
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

        async void txtNum4aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum4b.Checked = !checkbox.Checked;
            //txtNum4c.Checked = !checkbox.Checked;
        }
        async void txtNum4bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum4a.Checked = !checkbox.Checked;
            //txtNum4c.Checked = !checkbox.Checked;
        }
        async void txtNum4cChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum4b.Checked = !checkbox.Checked;
            txtNum4a.Checked = !checkbox.Checked;
        }

        async void txtNum6aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum6b.Checked = !checkbox.Checked;
        }
        async void txtNum6bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum6a.Checked = !checkbox.Checked;
        }

        async void txtNum8aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum8b.Checked = !checkbox.Checked;
        }
        async void txtNum8bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum8a.Checked = !checkbox.Checked;
        }
    }
}