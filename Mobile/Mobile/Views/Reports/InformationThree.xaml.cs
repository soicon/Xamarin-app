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
    public partial class InformationThree : ContentPage
    {
        public InformationThree()
        {
            App.localizer.SetLocale(App.defaultCulture);
            InitializeComponent();
            btnBack.Clicked += Back_Clicked;
            btnNext.Clicked += Next_Clicked;
            GetData();
        
            Title = App.localizeResProvider.GetText("String105");
        }
        async void Back_Clicked(object sender, EventArgs e)
        {
            SetData();
            await Navigation.PushAsync(new InformationTwo(), true);
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            SetData();
            await Navigation.PushAsync(new Report(), true);
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new InformationTwo(), true);
            return base.OnBackButtonPressed();
        }
        private void SetData()
        {
            App.ListReport[0].ListQuestion[17].ListAnswer[0].Note = txtNum18a.Text;
            App.ListReport[0].ListQuestion[17].ListAnswer[1].Note = txtNum18b.Text;
            App.ListReport[0].ListQuestion[18].ListAnswer[0].Note = txtNum19a.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[18].ListAnswer[1].Note = txtNum19bNote.Text;
            App.ListReport[0].ListQuestion[19].ListAnswer[0].Note = txtNum20a.Text;
            App.ListReport[0].ListQuestion[19].ListAnswer[1].Note = txtNum20b.Text;
            App.ListReport[0].ListQuestion[19].ListAnswer[2].Note = txtNum20c.Text;
        }
        public void GetData()
        {
            txtNum18a.Text = App.ListReport[0].ListQuestion[17].ListAnswer[0].Note;
            txtNum18b.Text = App.ListReport[0].ListQuestion[17].ListAnswer[1].Note;
            txtNum19a.Checked = App.ListReport[0].ListQuestion[18].ListAnswer[0].Note.Equals("1");
            if (App.ListReport[0].ListQuestion[18].ListAnswer[1].Note != "" && !txtNum19a.Checked)
            {
                txtNum19a.Checked = false;
                txtNum19b.Checked = true;
                txtNum19bNote.Text = App.ListReport[0].ListQuestion[18].ListAnswer[1].Note;
            }
            txtNum20a.Text = App.ListReport[0].ListQuestion[19].ListAnswer[0].Note;
            txtNum20b.Text = App.ListReport[0].ListQuestion[19].ListAnswer[1].Note;
            txtNum20c.Text = App.ListReport[0].ListQuestion[19].ListAnswer[2].Note;
        }

        async void num19aChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum19b.Checked = !checkbox.Checked;
        }
        async void num19bChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            txtNum19a.Checked = !checkbox.Checked;
        }
    }
}