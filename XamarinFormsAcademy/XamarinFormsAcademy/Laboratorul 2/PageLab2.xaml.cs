using System;
using System.Collections.Generic;
using System.Linq;
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
        List<string> strings = new List<string>();
        bool flag;

        public PageLab2()
        {
            // Daca va uitaqti in XAML veti observa ca avem toata distractia acolo
            InitializeComponent();
           PapaVatican.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("poza.jpg") : ImageSource.FromFile("Assets/poza.jpg");

            Grid mainGrid = (Grid)this.Content;
            mainGrid.RowSpacing = 0;
            // Asta nu ne opreste sa ne jucam si noi aici, in cod
            // Mai jos am legat textul label-ului care ar trebui sa fie un numar
            // de valoarea stepper-ului
            StepperReal.ValueChanged += (s, e) =>
            {
                // Putem sa specificam formatul, cu cate zecimale dorim
                LabelNumar.Text = StepperReal.Value.ToString("0.0");
            };

            // Avem in scroll view un label deci hai sa facem textul acela mare, mare
            // Va ajut eu, ne legam tot de RealStepper
            StepperReal.ValueChanged += (s, e) =>
            {
                // Analog ca mai sus, dar mai fancy, cu string interpolation
                if (e.NewValue > e.OldValue)
                {
                    string text = $"Acum stepper-ul arata {StepperReal.Value: 0.0}." + "\n";
                    ReallyBigText.Text += text;
                    strings.Insert(0, text);
                } else
                {
                    strings.RemoveAt(0);
                    List<string> clone = strings.Select(x=>x.ToString()).ToList();
                    clone.Reverse();
                    ReallyBigText.Text = String.Join("", clone);
                }
            };

            // TO DO: Cand se modifica ceva in text entry, sa se modifice si in label-ul asociat
            DoarUnEntry.TextChanged += (s, e) =>
            {
                DoarUnLabel.Text = e.NewTextValue;
                if (e.NewTextValue.Length > (e?.OldTextValue?.Length??0))
                {
                    ReallyBigText.Text += e.NewTextValue.Substring(e.NewTextValue.Length - 1);
                    flag = false;
                } else
                {
                    if (!flag)
                    {
                        ReallyBigText.Text += Environment.NewLine;
                        flag = true;

                    }
                }
                
            };
            // TO DO: Adaugati schimbarile la acest text mare
            
        }
    }
}