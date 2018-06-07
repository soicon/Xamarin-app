using Mobile.Models.ModelBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.News
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDetailTemp : ContentPage
    {
        private NewBO news { get; set; }
        public NewDetailTemp(NewBO news)
        {
            InitializeComponent();
            Title = news.Title;
            this.news = news;
            BindingContext = news;
            txtTitle.Text = news.Title;
            articleweb.Source = new HtmlWebViewSource
            {
                Html = news.OriginalContent
            };
        }
    }
}