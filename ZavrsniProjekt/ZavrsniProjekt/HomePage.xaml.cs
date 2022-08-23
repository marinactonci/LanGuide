using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZavrsniProjekt.Helpers;

namespace ZavrsniProjekt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void OnGridCardTappedOpenUsers(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new UsersPage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnGridCardTappedOpenResults(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new ResultsPage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnGridCardTappedOpenLanguages(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new LanguagesPage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnLinkTappedSignOut(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}