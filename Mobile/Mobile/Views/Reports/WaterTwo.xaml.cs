using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaterTwo : ContentPage
    {
        public WaterTwo()
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
            await Navigation.PushAsync(new Water());
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            SetData();
            await Navigation.PushAsync(new Report());
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync((new Report()));
            return base.OnBackButtonPressed();
        }
        private void SetData()
        {
            App.ListReport[2].ListQuestion[8].ListAnswer[0].Note = txtNum9a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[8].ListAnswer[1].Note = txtNum9b.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[8].ListAnswer[2].Note = txtNum9c.Text;
            App.ListReport[2].ListQuestion[8].ListAnswer[3].Note = txtNum9d.Text;

            App.ListReport[2].ListQuestion[9].ListAnswer[0].Note = txtNum10a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[9].ListAnswer[1].Note = txtNum10b.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[9].ListAnswer[2].Note = txtNum10c.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[9].ListAnswer[3].Note = txtNum10d.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[9].ListAnswer[4].Note = txtNum10e.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[9].ListAnswer[5].Note = txtNum10f.Checked ? "1" : "0";

            App.ListReport[2].ListQuestion[10].ListAnswer[0].Note = txtNum11a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[10].ListAnswer[1].Note = txtNum11b.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[10].ListAnswer[2].Note = txtNum11c.Checked ? "1" : "0";

            App.ListReport[2].ListQuestion[11].ListAnswer[0].Note = txtNum12.Text;
            App.ListReport[2].ListQuestion[12].ListAnswer[0].Note = txtNum13.Text;

            App.ListReport[2].ListQuestion[13].ListAnswer[0].Note = txtNum14a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[13].ListAnswer[1].Note = txtNum14b.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[13].ListAnswer[2].Note = txtNum14c.Text;
            App.ListReport[2].ListQuestion[13].ListAnswer[3].Note = txtNum14d.Text;

            App.ListReport[2].ListQuestion[14].ListAnswer[0].Note = txtNum15a.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[14].ListAnswer[1].Note = txtNum15b.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[14].ListAnswer[2].Note = txtNum15c.Checked ? "1" : "0";
            App.ListReport[2].ListQuestion[14].ListAnswer[3].Note = txtNum15d.Checked ? "1" : "0";

            App.ListReport[2].ListQuestion[15].ListAnswer[0].Note = txtNum16a.Text;
            App.ListReport[2].ListQuestion[15].ListAnswer[1].Note = txtNum16b.Text;
            App.ListReport[2].ListQuestion[15].ListAnswer[2].Note = txtNum16c.Text;
        }
        public void GetData()
        {
            txtNum9a.Checked = App.ListReport[2].ListQuestion[8].ListAnswer[0].Note.Equals("1");
            txtNum9b.Checked = App.ListReport[2].ListQuestion[8].ListAnswer[1].Note.Equals("1");
            App.ListReport[2].ListQuestion[8].ListAnswer[2].Note = txtNum9c.Text;
            App.ListReport[2].ListQuestion[8].ListAnswer[3].Note = txtNum9d.Text;

            txtNum10a.Checked = App.ListReport[2].ListQuestion[9].ListAnswer[0].Note.Equals("1");
            txtNum10b.Checked = App.ListReport[2].ListQuestion[9].ListAnswer[1].Note.Equals("1");
            txtNum10c.Checked = App.ListReport[2].ListQuestion[9].ListAnswer[2].Note.Equals("1");
            txtNum10d.Checked = App.ListReport[2].ListQuestion[9].ListAnswer[3].Note.Equals("1");
            txtNum10e.Checked = App.ListReport[2].ListQuestion[9].ListAnswer[4].Note.Equals("1");
            txtNum10f.Checked = App.ListReport[2].ListQuestion[9].ListAnswer[5].Note.Equals("1");

            txtNum11a.Checked = App.ListReport[2].ListQuestion[10].ListAnswer[0].Note.Equals("1");
            txtNum11b.Checked = App.ListReport[2].ListQuestion[10].ListAnswer[1].Note.Equals("1");
            txtNum11c.Checked = App.ListReport[2].ListQuestion[10].ListAnswer[2].Note.Equals("1");

            txtNum12.Text = App.ListReport[2].ListQuestion[11].ListAnswer[0].Note;
            txtNum13.Text = App.ListReport[2].ListQuestion[12].ListAnswer[0].Note;

            txtNum14a.Checked = App.ListReport[2].ListQuestion[13].ListAnswer[0].Note.Equals("1");
            txtNum14b.Checked = App.ListReport[2].ListQuestion[13].ListAnswer[1].Note.Equals("1");
            App.ListReport[2].ListQuestion[13].ListAnswer[2].Note = txtNum14c.Text;
            App.ListReport[2].ListQuestion[13].ListAnswer[3].Note = txtNum14d.Text;

            txtNum15a.Checked = App.ListReport[2].ListQuestion[14].ListAnswer[0].Note.Equals("1");
            txtNum15b.Checked = App.ListReport[2].ListQuestion[14].ListAnswer[1].Note.Equals("1");
            txtNum15c.Checked = App.ListReport[2].ListQuestion[14].ListAnswer[2].Note.Equals("1");
            txtNum15d.Checked = App.ListReport[2].ListQuestion[14].ListAnswer[3].Note.Equals("1");

            txtNum16a.Text = App.ListReport[2].ListQuestion[15].ListAnswer[0].Note;
            txtNum16b.Text = App.ListReport[2].ListQuestion[15].ListAnswer[1].Note;
            txtNum16c.Text = App.ListReport[2].ListQuestion[15].ListAnswer[2].Note;
        }

        async void txtNum9aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum9b.Checked = !checkbox.Checked;
        }
        async void txtNum9bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum9a.Checked = !checkbox.Checked;
        }

        async void txtNum11aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum11b.Checked = !checkbox.Checked;
            txtNum11c.Checked = !checkbox.Checked;
        }
        async void txtNum11bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum11c.Checked = !checkbox.Checked;
            txtNum11a.Checked = !checkbox.Checked;
        }
        async void txtNum11cChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum11a.Checked = !checkbox.Checked;
            txtNum11b.Checked = !checkbox.Checked;
        }

        async void txtNum14aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum14b.Checked = !checkbox.Checked;
        }
        async void txtNum14bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum14a.Checked = !checkbox.Checked;
        }
    }
}