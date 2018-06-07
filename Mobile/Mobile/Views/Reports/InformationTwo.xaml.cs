using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationTwo : ContentPage
    {
        public InformationTwo()
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
            //Navigation.RemovePage(this);
            await Navigation.PushAsync(new Information(), true);
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            SetData();
            //Navigation.RemovePage(this);
            await Navigation.PushAsync(new InformationThree(), true);
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new Information(), true);
            return base.OnBackButtonPressed();
        }
        private void SetData()
        {
            App.ListReport[0].ListQuestion[13].ListAnswer[0].Note = txtNum14a.Text;
            App.ListReport[0].ListQuestion[13].ListAnswer[1].Note = txtNum14b.Text;
            App.ListReport[0].ListQuestion[14].ListAnswer[0].Note = txtNum15.Text;

            App.ListReport[0].ListQuestion[15].ListAnswer[0].Note = txtNum16a.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[15].ListAnswer[1].Note = txtNum16b.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[15].ListAnswer[2].Note = txtNum16c.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[15].ListAnswer[3].Note = txtNum16d.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[15].ListAnswer[4].Note = txtNum16e.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[15].ListAnswer[5].Note = txtNum16f.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[15].ListAnswer[6].Note = txtNum16Note.Text;

            App.ListReport[0].ListQuestion[16].ListAnswer[0].Note = num17a1.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[16].ListAnswer[1].Note = num17b1.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[16].ListAnswer[2].Note = num17c1.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[16].ListAnswer[3].Note = num17a3.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[16].ListAnswer[4].Note = num17b3.Checked ? "1" : "0";
            App.ListReport[0].ListQuestion[16].ListAnswer[5].Note = num17c4.Checked ? "1" : "0";
        }
        private void GetData()
        {
            txtNum14a.Text = App.ListReport[0].ListQuestion[13].ListAnswer[0].Note;
            txtNum14b.Text = App.ListReport[0].ListQuestion[13].ListAnswer[1].Note;
            txtNum15.Text = App.ListReport[0].ListQuestion[14].ListAnswer[0].Note;
            txtNum16Note.Text = App.ListReport[0].ListQuestion[15].ListAnswer[6].Note;
            #region Num16
            if (App.ListReport[0].ListQuestion[15].ListAnswer[0].Note.Equals("1"))
            {
                txtNum16a.Checked = true;
            }
            else
            {
                txtNum16a.Checked = false;
            }
            if (App.ListReport[0].ListQuestion[15].ListAnswer[1].Note.Equals("1"))
            {
                txtNum16b.Checked = true;
            }
            else
            {
                txtNum16b.Checked = false;
            }
            if (App.ListReport[0].ListQuestion[15].ListAnswer[2].Note.Equals("1"))
            {
                txtNum16c.Checked = true;
            }
            else
            {
                txtNum16c.Checked = false;
            }
            if (App.ListReport[0].ListQuestion[15].ListAnswer[3].Note.Equals("1"))
            {
                txtNum16d.Checked = true;
            }
            else
            {
                txtNum16d.Checked = false;
            }
            if (App.ListReport[0].ListQuestion[15].ListAnswer[4].Note.Equals("1"))
            {
                txtNum16e.Checked = true;
            }
            else
            {
                txtNum16e.Checked = false;
            }
            if (App.ListReport[0].ListQuestion[15].ListAnswer[5].Note.Equals("1"))
            {
                txtNum16f.Checked = true;
            }
            else
            {
                txtNum16f.Checked = false;
            }
            #endregion
            #region Num17
            if (App.ListReport[0].ListQuestion[16].ListAnswer[0].Note.Equals("1"))
            {
                num17a1.Checked = true;
                num17a2.Checked = false;
            }
            else
            {
                num17a1.Checked = false;
                num17a2.Checked = true;
            }
            if (App.ListReport[0].ListQuestion[16].ListAnswer[1].Note.Equals("1"))
            {
                num17b1.Checked = true;
                num17b2.Checked = false;
            }
            else
            {
                num17b1.Checked = false;
                num17b2.Checked = true;
            }
            if (App.ListReport[0].ListQuestion[16].ListAnswer[2].Note.Equals("1"))
            {
                num17c1.Checked = true;
                num17c2.Checked = false;
            }
            else
            {
                num17c1.Checked = false;
                num17c2.Checked = true;
            }
            if (App.ListReport[0].ListQuestion[16].ListAnswer[3].Note.Equals("1"))
            {
                num17a3.Checked = true;
                num17a4.Checked = false;
            }
            else
            {
                num17a3.Checked = false;
                num17a4.Checked = true;
            }
            if (App.ListReport[0].ListQuestion[16].ListAnswer[4].Note.Equals("1"))
            {
                num17b3.Checked = true;
                num17b4.Checked = false;
            }
            else
            {
                num17b3.Checked = false;
                num17b4.Checked = true;
            }
            if (App.ListReport[0].ListQuestion[16].ListAnswer[5].Note.Equals("1"))
            {
                num17c3.Checked = true;
                num17c4.Checked = false;
            }
            else
            {
                num17c3.Checked = false;
                num17c4.Checked = true;
            }
            #endregion
        }
        async void num17a1ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17a2.Checked = !checkbox.Checked;
        }
        async void num17a2ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17a1.Checked = !checkbox.Checked;
        }
        async void num17a3ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17a4.Checked = !checkbox.Checked;
        }
        async void num17a4ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17a3.Checked = !checkbox.Checked;
        }


        async void num17b1ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17b2.Checked = !checkbox.Checked;
        }
        async void num17b2ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17b1.Checked = !checkbox.Checked;
        }
        async void num17b3ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17b4.Checked = !checkbox.Checked;
        }
        async void num17b4ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17b3.Checked = !checkbox.Checked;
        }

        async void num17c1ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17c2.Checked = !checkbox.Checked;
        }
        async void num17c2ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17c1.Checked = !checkbox.Checked;
        }
        async void num17c3ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17c4.Checked = !checkbox.Checked;
        }
        async void num17c4ChangeEvent(object sender, EventArgs e)
        {
            var checkbox = sender as Checkbox;
            num17c3.Checked = !checkbox.Checked;
        }
    }
}