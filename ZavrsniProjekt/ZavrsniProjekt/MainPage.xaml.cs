﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZavrsniProjekt.Helpers;

namespace ZavrsniProjekt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (!isEmailEmpty && !isPasswordEmpty)
            {
                bool result = await Auth.LoginUser(emailEntry.Text, passwordEntry.Text);
                if (result)
                    App.Current.MainPage = new HomePage();
            }
        }
    }
}
