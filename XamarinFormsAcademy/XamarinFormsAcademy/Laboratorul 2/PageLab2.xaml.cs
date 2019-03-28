
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsAcademy.Laboratorul_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLab2 : ContentPage
    {
        /*
         * Scopul acestui laborator este sa va familiarizati cu View-urile si cu Layout-urile
         * 
         * Scopul final al acestui laborator este sa va creati elementele vizuale fundamnetate 
         * pentru aplicatia ce o veti dezvolta
         */

        public PageLab2()
        {
            // Daca va uitaqti in XAML veti observa ca avem toata distractia acolo
            InitializeComponent();

            // Asta nu ne opreste sa ne jucam si noi aici, in cod
            // Mai jos am legat textul label-ului care ar trebui sa fie un numar
            // de valoarea stepper-ului
            StepperReal.ValueChanged += (s, e) =>
            {
                // Putem sa specificam formatul, cu cate zecimale dorim
                LabelNumar.Text = StepperReal.Value.ToString("0.00");
            };

            // Avem in scroll view un label deci hai sa facem textul acela mare, mare
            // Va ajut eu, ne legam tot de RealStepper
            StepperReal.ValueChanged += (s, e) =>
            {
                // Analog ca mai sus, dar mai fancy, cu string interpolation
                ReallyBigText.Text += $"Acum stepper-ul arata {StepperReal.Value:0.00}. ";
            };

            // TO DO: Cand se modifica ceva in text entry, sa se modifice si in label-ul asociat
            // TO DO: Adaugati schimbarile la acest text mare
        }
    }
}