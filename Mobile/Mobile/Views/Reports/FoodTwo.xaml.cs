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
    public partial class FoodTwo : ContentPage
    {
        public FoodTwo()
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
            await Navigation.PushAsync(new Food());
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync((new Food()));
            return base.OnBackButtonPressed();
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            SetData();
            await Navigation.PushAsync(new Report());
        }
        private void SetData()
        {
            App.ListReport[3].ListQuestion[6].ListAnswer[0].Note = txtNum7.Text;

            App.ListReport[3].ListQuestion[7].ListAnswer[0].Note = txtNum8a.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[7].ListAnswer[1].Note = txtNum8b.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[7].ListAnswer[2].Note = txtNum8Note.Text;

            App.ListReport[3].ListQuestion[8].ListAnswer[0].Note = txtNum9a.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[8].ListAnswer[1].Note = txtNum9b.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[8].ListAnswer[2].Note = txtNum9c.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[8].ListAnswer[3].Note = txtNum9d.Checked ? "1" : "0";

            App.ListReport[3].ListQuestion[9].ListAnswer[0].Note = txtNum10a.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[9].ListAnswer[1].Note = txtNum10b.Checked ? "1" : "0";

            App.ListReport[3].ListQuestion[10].ListAnswer[0].Note = txtNum11a.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[10].ListAnswer[1].Note = txtNum11b.Checked ? "1" : "0";
            App.ListReport[3].ListQuestion[10].ListAnswer[2].Note = txtNum11Note.Text;

            App.ListReport[3].ListQuestion[10].ListAnswer[0].Note = txtNum12a.Text;
            App.ListReport[3].ListQuestion[10].ListAnswer[1].Note = txtNum12b.Text;
            App.ListReport[3].ListQuestion[10].ListAnswer[2].Note = txtNum12c.Text;
        }
        private void GetData()
        {
            txtNum7.Text = App.ListReport[3].ListQuestion[6].ListAnswer[0].Note;

            txtNum8a.Checked = App.ListReport[3].ListQuestion[7].ListAnswer[0].Note.Equals("1");
            txtNum8b.Checked = App.ListReport[3].ListQuestion[7].ListAnswer[1].Note.Equals("1");
            App.ListReport[3].ListQuestion[7].ListAnswer[2].Note = txtNum8Note.Text;

            txtNum9a.Checked = App.ListReport[3].ListQuestion[8].ListAnswer[0].Note.Equals("1");
            txtNum9b.Checked = App.ListReport[3].ListQuestion[8].ListAnswer[1].Note.Equals("1");
            txtNum9c.Checked = App.ListReport[3].ListQuestion[8].ListAnswer[2].Note.Equals("1");
            txtNum9d.Checked = App.ListReport[3].ListQuestion[8].ListAnswer[3].Note.Equals("1");

            txtNum10a.Checked = App.ListReport[3].ListQuestion[9].ListAnswer[0].Note.Equals("1");
            txtNum10b.Checked = App.ListReport[3].ListQuestion[9].ListAnswer[1].Note.Equals("1");

            txtNum11a.Checked = App.ListReport[3].ListQuestion[10].ListAnswer[0].Note.Equals("1");
            txtNum11b.Checked = App.ListReport[3].ListQuestion[10].ListAnswer[1].Note.Equals("1");
            txtNum11Note.Text = App.ListReport[3].ListQuestion[10].ListAnswer[2].Note;

            txtNum12a.Text = App.ListReport[3].ListQuestion[10].ListAnswer[0].Note;
            txtNum12b.Text = App.ListReport[3].ListQuestion[10].ListAnswer[1].Note;
            txtNum12c.Text = App.ListReport[3].ListQuestion[10].ListAnswer[2].Note;
        }
        async void txtNum8bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum8a.Checked = !checkbox.Checked;
        }
        async void txtNum8aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum8b.Checked = !checkbox.Checked;
        }
    }
}