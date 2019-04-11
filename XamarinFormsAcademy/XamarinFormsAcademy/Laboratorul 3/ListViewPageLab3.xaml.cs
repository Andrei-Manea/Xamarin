using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Extended;
using Xamarin.Forms.Xaml;

namespace XamarinFormsAcademy.Laboratorul_3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPageLab3 : ContentPage
    {
        private static readonly Random _randomGenerator = new Random();
        /*
         * Scopul acestui laborator este sa va familiarizati cu colectiile observabile
         * si cu conceptul de datatemplating
         * 
         * Scopul final al acestui laborator este aveti o interactiune reala cu elementele
         * de tip lista pe care le veti folosi in aplicatia voastra
         */

        // Folosim colectii observabile pentru a putea monitoriza schimbarile
        public ObservableCollection<Person> Items { get; set; }

        public ListViewPageLab3()
        {
            InitializeComponent();

            // Ne initializam obiectele cu date dummy
            // TO DO: Creati obiecte anonime complexe, cu cel putin 3 proprietati
            Items = new ObservableCollection<Person>();
            MyListView.ItemsSource = Items;

            GetPPL();
        }

        private async void GetPPL()
        {
            while (true)
            {
                foreach (Person currentP in new List<Person>{
                new Person(_randomGenerator.Next(0, 100))
                {
                    Name = "Andrei",
                    Height = 1.8f
                },
                new Person(_randomGenerator.Next(0, 100))
                {
                    Name = "Cristi",
                    Height = 1.9f
                },
                new Person(_randomGenerator.Next(0, 100))
                {
                    Name = "Robert",
                    Height = 1.6f
                } })
                {
                    Items.Add(currentP);
                }


                    await Task.Delay(1000);
            }

        }

        // Avem nevoie sa tratatm evenimentul de selectare a unui item din lista
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            // Afisam un mesaj corespunzator
            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
public class Person
{
    public string Name { get; set; }
    public double Age { get; set; }
    public double AgeDisplay { get; set; }
    public float Height { get; set; }
    public int MinAge { get; set; } = 0;
    public int MaxAge { get; set; } = 100;

    public Person(double age)
    {
        Age = age;
        AgeDisplay = age / MaxAge;
    }
}
