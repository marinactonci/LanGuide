using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZavrsniProjekt.Model;

namespace ZavrsniProjekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagesPage : ContentPage
    {
        public LanguagesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var languages = await Results.GetResults();
            languageListView.ItemsSource = languages.GroupBy(x => x.language).Select(x => x.First());
        }

        public async void OpenHomePageButton_Clicked3(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new HomePage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}