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
    public partial class Information : ContentPage
    {
        public Information()
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
            await Navigation.PushAsync(new Report(), true);
        }
        async void Next_Clicked(object sender, EventArgs e)
        {
            try
            {
                SetData();
                //Navigation.RemovePage(this);
                await Navigation.PushAsync(new InformationTwo(), true);
            }
            catch (Exception ex)
            {

            }
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new Report(), true);
            return base.OnBackButtonPressed();
        }
        private void SetData()
        {
            App.ListReport[0].ListQuestion[0].ListAnswer[0].Note = txtOne.Text;
            App.ListReport[0].ListQuestion[1].ListAnswer[0].Note = txtTwo.Text;
            App.ListReport[0].ListQuestion[2].ListAnswer[0].Note = txtThree.Text;
            App.ListReport[0].ListQuestion[3].ListAnswer[0].Note = txtFour.Text;
            App.ListReport[0].ListQuestion[4].ListAnswer[0].Note = txtFive.Text;
            App.ListReport[0].ListQuestion[5].ListAnswer[0].Note = txtSix.Text;
            App.ListReport[0].ListQuestion[6].ListAnswer[0].Note = txtSevent.Text;
            App.ListReport[0].ListQuestion[7].ListAnswer[0].Note = txtEight.Text;
            App.ListReport[0].ListQuestion[8].ListAnswer[0].Note = txtNine.Text;
            App.ListReport[0].ListQuestion[9].ListAnswer[0].Note = txtTen.Text;
            App.ListReport[0].ListQuestion[10].ListAnswer[0].Note = txtElevent.Text;
            App.ListReport[0].ListQuestion[11].ListAnswer[0].Note = txtTwelve.Text;
            App.ListReport[0].ListQuestion[12].ListAnswer[0].Note = txtAnswerA.Text;
            App.ListReport[0].ListQuestion[12].ListAnswer[1].Note = txtAnswerB.Text;
            App.ListReport[0].ListQuestion[12].ListAnswer[2].Note = txtAnswerC.Text;
            App.ListReport[0].ListQuestion[12].ListAnswer[3].Note = txtAnswerD.Text;
            App.ListReport[0].ListQuestion[12].ListAnswer[4].Note = txtAnswerE.Text;
            App.ListReport[0].ListQuestion[12].ListAnswer[5].Note = txtAnswerF.Text;
        }
        private void GetData()
        {
            txtOne.Text = App.ListReport[0].ListQuestion[0].ListAnswer[0].Note;
            txtTwo.Text = App.ListReport[0].ListQuestion[1].ListAnswer[0].Note;
            txtThree.Text = App.ListReport[0].ListQuestion[2].ListAnswer[0].Note;
            txtFour.Text = App.ListReport[0].ListQuestion[3].ListAnswer[0].Note;
            txtFive.Text = App.ListReport[0].ListQuestion[4].ListAnswer[0].Note;
            txtSix.Text = App.ListReport[0].ListQuestion[5].ListAnswer[0].Note;
            txtSevent.Text = App.ListReport[0].ListQuestion[6].ListAnswer[0].Note;
            txtEight.Text = App.ListReport[0].ListQuestion[7].ListAnswer[0].Note;
            txtNine.Text = App.ListReport[0].ListQuestion[8].ListAnswer[0].Note;
            txtTen.Text = App.ListReport[0].ListQuestion[9].ListAnswer[0].Note;
            txtElevent.Text = App.ListReport[0].ListQuestion[10].ListAnswer[0].Note;
            txtTwelve.Text = App.ListReport[0].ListQuestion[11].ListAnswer[0].Note;
            txtAnswerA.Text = App.ListReport[0].ListQuestion[12].ListAnswer[0].Note;
            txtAnswerB.Text = App.ListReport[0].ListQuestion[12].ListAnswer[1].Note;
            txtAnswerC.Text = App.ListReport[0].ListQuestion[12].ListAnswer[2].Note;
            txtAnswerD.Text = App.ListReport[0].ListQuestion[12].ListAnswer[3].Note;
            txtAnswerE.Text = App.ListReport[0].ListQuestion[12].ListAnswer[4].Note;
            txtAnswerF.Text = App.ListReport[0].ListQuestion[12].ListAnswer[5].Note;
        }
    }
}