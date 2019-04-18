using DataAccessLayer;
using DataAccessLayer.DTO;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsAcademy.Laboratorul_4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPageLab4 : ContentPage
    {
        /*
         * Scopul acestui laborator este sa va familiarizati SQL Lite
         * 
         * Scopul final al acestui laborator este sa puteti persista datele in baza de date
         * sau in fisiere, daca alegeti aceasta cale
         */

        public ObservableCollection<ShoppingItem> Items { get; set; }

        public ListPageLab4()
        {
            InitializeComponent();

            Items = new ObservableCollection<ShoppingItem>(Database.Instance.GetItemsAsync().Result);
			
			MyListView.ItemsSource = Items;
            // TO DO: Inspectati elementele noi
        }

        // TO DO: Folosind acelst Handler si niste modificari in XAML,
        // faceti item-ul editabil`
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            await Navigation.PushAsync(new NewPage((ShoppingItem)e.Item));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Items = new ObservableCollection<ShoppingItem>(Database.Instance.GetItemsAsync().Result);
            MyListView.ItemsSource = Items;
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            // Din cauza constrangerii, dorim sa ne asiguram ca nu vom primi o exceptie
            uint itemID = Items.Count > 0 ? Items.Max(x => x.ID) + 1 : 0;

            // Vom crea un nou element, cat mai simplu
            ShoppingItem toAdd = new ShoppingItem {
                ID= itemID,
                ItemName = $"Item_{itemID:000}"
            };

            // Il vom adauga sau updata in baza de date
            Database.Instance.UpdateItemData(toAdd);
            // Il vom adauga in lista
            Items.Add(toAdd);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Items = new ObservableCollection<ShoppingItem>(Database.Instance.GetItemsAsync().Result);
            MyListView.ItemsSource = Items;
        }
    }
}
