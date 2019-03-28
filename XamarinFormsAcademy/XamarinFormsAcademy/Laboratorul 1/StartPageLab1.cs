
using Xamarin.Forms;

namespace XamarinFormsAcademy.Laboratorul_1
{
    // Nu este nevoie sa aveti si XAML pentru o pagina, va puteti construi
    // aplicatia doar cu cod
    public class StartPageLab1 : ContentPage
    {
        /*
         * Scopul acestui laborator este sa va familiarizati cu tipurile de pagini
         * si cu metodele de navigare, stoc sunt prezentate 3 pagini si 2 metode de navigare
         * 
         * Scopul final al acestui laborator este sa va ganditi la aplicatia pe care
         * o veti realiza si sa va definiti structura de navigare si a paginilor
         */

        public StartPageLab1()
        {
            // Cum nu ne intereseaza continutul in acest laborator vom adauga
            // doar un buton pentru navigare
            Content = new StackLayout
            {
                Children = {
                    new Button {
                        Text = "Apasa-ma",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        // Comanda este o comanda de navigare catre noua pagina
                        Command = new Command(
                            () => App.NavigationMethod.PushAsync(new TabbedPageLab1())
                            )
                    }
                }
            };

            // Va recomand sa va jucati cu toate tipurile de pagina 
        }
    }
}