using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsAcademy.Laboratorul_2;
using XamarinFormsAcademy.Utils;

namespace XamarinFormsAcademy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Auth : ContentPage
    {
        public Auth()
        {
            InitializeComponent();
            if (Settings.RememberMe)
            {
                RememberMe.IsToggled = true;
                Username.Text = Settings.Username;
                Password.Text = Settings.Password;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;
            bool remember = RememberMe.IsToggled;
            bool loggedIn = false;

            Settings.RememberMe = remember;

            if (remember)
            {
                Settings.Username = username;

                if (Settings.Password == Settings.DefaultPassword)
                {
                    Settings.Password = password;
                }
            }
            else
            {
                Settings.Username = username;
                if (Settings.Password == password)
                {
                    Settings.Password = Settings.DefaultPassword;
                    loggedIn = true;
                }
                Settings.Username = string.Empty;
            }

            if (loggedIn || (Settings.Password == password))
            {
                await Navigation.PushAsync(new PageLab2());
            }
            else
            {
                await DisplayAlert("Alert", "Invalid Password", "OK");
            }
        }
    }
}