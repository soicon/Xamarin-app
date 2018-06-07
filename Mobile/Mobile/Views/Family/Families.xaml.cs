using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Models;
using Mobile.Models.ModelBO;
using Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Families : ContentPage
    {
        private List<FamilyList> _listOfFamily;
        public List<FamilyList> ListOfFamily { get { return _listOfFamily; } set { _listOfFamily = value; base.OnPropertyChanged(); } }
        public Families()
        {
            InitializeComponent();
            Title = "Gia đình";
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Models.Family;
            if (item == null)
                return;
            await Navigation.PushAsync((new Family.Detail(item)));
            ItemsListView.SelectedItem = null;
        }
        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync((new Family.Create()));
        }
        protected override async void OnAppearing()
        {
            try
            {
                ListOfFamily = new List<FamilyList>();
                RestClient restClient = App.restClient;
                var families = await restClient.Get<List<FamilyWrap>>("families/location");
                if (families != null)
                {
                    //families = families.OrderBy(x => x.Name).ToList();
                    var lstUserEmpty = families.Where(x => x.location == null);
                    var lstAlphabet = families.Where(x => x.location != null).Select(y => y.location).ToList();
                    lstAlphabet = lstAlphabet.GroupBy(x => x.LocationId).Select(y => y.FirstOrDefault()).ToList();
                    FamilyList familyList = null;
                    foreach (var item in lstAlphabet)
                    {
                        familyList = new FamilyList();
                        var heading = item;
                        var lstTemp = families.Where(x => x.location != null && x.location.LocationId == item.LocationId).ToList();
                        familyList.Heading = heading.Name;
                        foreach (var ele in lstTemp)
                        {
                            ele.family.Location = ele.location;
                        }
                        familyList.AddRange(lstTemp.Select(x => x.family).ToList());
                        ListOfFamily.Add(familyList);
                    }
                    if (lstUserEmpty.Any())
                    {
                        familyList = new FamilyList();
                        ListOfFamily.Add(familyList);
                        familyList.Heading = "Unknow";
                        foreach (var ele in lstUserEmpty)
                        {
                            ele.family.Location = ele.location;
                        }
                        familyList.AddRange(lstUserEmpty.Select(x => x.family).ToList());
                    }
                    ItemsListView.ItemsSource = ListOfFamily;
                }
                ItemsListView.ItemsSource = ListOfFamily;
            }
            catch (Exception ex)
            {

            }
            base.OnAppearing();
        }
    }
}