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
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var users = await Users.GetUsers();
            userListView.ItemsSource = users;
        }

        int b = 0;
        int c = 0;

        private async void UpDownArrowsPressed(object sender, EventArgs e)
        {
            b++;

            base.OnAppearing();
            var users = await Users.GetUsers();

            if (b % 2 == 0)
            {
                userListView.ItemsSource = from user in users
                                           orderby user.id_user ascending
                                           select user;
            }
            else
            {
                userListView.ItemsSource = from user in users
                                           orderby user.id_user descending
                                           select user;
            }
            
        }

        private async void UpDownArrowsPressed2(object sender, EventArgs e)
        {
            c++;

            base.OnAppearing();
            var users = await Users.GetUsers();

            if(c % 2 == 0)
            {
                userListView.ItemsSource = from user in users
                                           orderby user.create_time ascending
                                           select user;
            }
            else
            {
                userListView.ItemsSource = from user in users
                                           orderby user.create_time descending
                                           select user;
            }
        }

        public async void OpenHomePageButton_Clicked(object sender, EventArgs e)
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