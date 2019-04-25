using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsAcademy.Laboratorul_1;
using XamarinFormsAcademy.Laboratorul_2;
using XamarinFormsAcademy.Laboratorul_3;
using XamarinFormsAcademy.Laboratorul_4;

// Aceasta este o setare ce imbunatateste performanta aplicatiei
// prin compilarea inclusiv a fisierelor .xaml
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinFormsAcademy
{
    // Aceasta clasa este aplicatia in sine
    // Prin ea se incarca componente si se afiseaza clase
    public partial class App : Application
    {
        // Pagina de navigare, este posibil sa dorim sa o accesam din diverse locatii
        public static readonly NavigationPage NavigationMethod = new NavigationPage();

        public App()
        {
            // Aceasta metoda incarca continutul paginii XAML
            // Fara ea nu avem access la componentele paginii si
            // este posibil sa genereze un crash lipsa ei
            InitializeComponent();

            // Ii spunem paginii de navigare ca prima pagina cu care ne vom intalni
            // este StartPageLab1, aceasta o puteti modifica voi oricand
            NavigationMethod.PushAsync(new Pages.Auth());


            // Aici vom seta pagina care va fi afisata prima si care
            // va fi radacina vizuala a aplicatiei noastre
            MainPage = NavigationMethod;

            // In fiecare clasa aveti TO DO-uri, spor si bafta! Mai jos le gasiti pe cele din aceasta
            // Clasa, separate pentru fiecare laborator
            // TO DO LAB 1 - Folositi pagina de start pentru Laboratorul 1
            // TO DO LAB 1 - Instalati "Rg.Plugins.Popup" si urmariti "GettingStarted"
            // TO DO LAB 1 - Incercati https://github.com/rotorgames/Rg.Plugins.Popup/wiki/PopupPage
            // TO DO LAB 2 - Schimbati pagina astfel incat sa folositi Laboratorul 2
            // TO DO LAB 3 - Schimbati pagina astfel incat sa folositi Laboratorul 3
            // TO DO LAB 3 - Urmati tutorialul din curs pentru a obtine o lista infinita
            // TO DO LAB 4 - Schimbati pagina astfel incat sa folositi Laboratorul 4
            // TO DO LAB 4 - Incercati https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/files?tabs=windows
            /* Cam pe aici se termina partea unde construim si incepe parte unde finisam constructia */
            // TO DO LAB 5 - Folositi https://docs.microsoft.com/en-us/xamarin/essentials/ in proiectul Vostru
            // Aceast laborator nu are continut propriu si are ca scop imbunatatirea aplicatiei voastre
            // TO DO LAB 6 - Interactiv la proiector si in proiectul vostru
            // TO DO LAB 7 - Spargeti in componente si pregatiti teste unitare, iar pentru pagini UI Tests
            // De asemenea, la finalul laboratorului va trebui sa generati un APK cu proiectul vostru pentru
            // a primi feedback pentru urmatoarea etapa / a va da mari
            // TO DO LAB 8 - PRISM - incercati sa va regstructurati proiectul in MVVM sau sa il rescrieti
            // cu ajutorul Framework-ului PRISM, va fi nevoie doar de copy paste
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
