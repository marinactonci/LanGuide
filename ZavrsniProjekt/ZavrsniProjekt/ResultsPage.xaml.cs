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
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var results = await Results.GetResults();
            resultListView.ItemsSource = results;
        }

        private async void searchID_TextChanged(object sender, EventArgs e)
        {
            var user_input = searchID.Text;
            var results = await Results.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from x in results
                                             where x.id_user == Int32.Parse(user_input)
                                             select x;
            }
            else
                return;
        }

        public async void searchExerciseID_TextChanged(object sender, EventArgs e)
        {
            var user_input = searchExerciseID.Text;
            var results = await Results.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = results.Where(result => result.id_exercise.ToLower().StartsWith(user_input.ToLower()));
        }

        private async void searchLanguage_SearchButtonPressed(object sender, EventArgs e)
        {
            var user_input = searchLanguage.Text;
            var results = await Results.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = results.Where(result => result.language.Contains(user_input));
        }


        private async void ImageButton_Pressed(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Results.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.id_user ascending
                                         select result;
        }

        private async void ImageButton_Pressed_1(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Results.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.create_time);
        }

        private async void ImageButton_Pressed_2(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Results.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.id_exercise);
        }

        private async void ImageButton_Pressed_3(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Results.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.result_percent ascending
                                         select result;
        }

        private async void ImageButton_Pressed_4(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Results.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.result_score ascending
                                         select result;
        }

        private async void ImageButton_Pressed_5(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Results.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.result_max ascending
                                         select result;
        }

        private async void ImageButton_Pressed_6(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Results.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.skill);
        }

        private async void ImageButton_Pressed_7(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Results.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.language);
        }

        private async void ImageButton_Pressed_8(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Results.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.result_date);
        }

        private async void resultPercentMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = resultPercentMax.Text;
            base.OnAppearing();
            var results = await Results.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_percent <= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        private async void resultPercentMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = resultPercentMin.Text;
            base.OnAppearing();
            var results = await Results.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_percent >= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        private async void resultScoreMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = resultScoreMax.Text;
            base.OnAppearing();
            var results = await Results.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_score <= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;

        }

        private async void resultScoreMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = resultScoreMin.Text;
            base.OnAppearing();
            var results = await Results.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_score >= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        private async void scoreMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = scoreMax.Text;
            base.OnAppearing();
            var results = await Results.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_max <= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        private async void scoreMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = scoreMin.Text;
            base.OnAppearing();
            var results = await Results.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_max >= Int16.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        public async void OpenHomePageButton_Clicked2(object sender, EventArgs e)
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