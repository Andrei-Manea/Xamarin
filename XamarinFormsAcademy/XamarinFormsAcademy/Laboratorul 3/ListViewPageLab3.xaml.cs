using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsAcademy.Laboratorul_3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPageLab3 : ContentPage
    {
        /*
         * Scopul acestui laborator este sa va familiarizati cu colectiile observabile
         * si cu conceptul de datatemplating
         * 
         * Scopul final al acestui laborator este aveti o interactiune reala cu elementele
         * de tip lista pe care le veti folosi in aplicatia voastra
         */

        // Folosim colectii observabile pentru a putea monitoriza schimbarile
        public ObservableCollection<string> Items { get; set; }

        public ListViewPageLab3()
        {
            InitializeComponent();

            // Ne initializam obiectele cu date dummy
            // TO DO: Creati obiecte anonime complexe, cu cel putin 3 proprietati
            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
			
			MyListView.ItemsSource = Items;
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
