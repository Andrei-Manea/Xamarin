using Xamarin.Forms;
using MyPopUp;
using DataAccessLayer.DTO;
using DataAccessLayer;

namespace XamarinFormsAcademy.Laboratorul_4
{
    internal class NewPage : ContentPage
    {   
        private readonly ShoppingItem _currentItem;
        public uint ID => _currentItem.ID;
        public string Name => _currentItem.ItemName;
        private readonly Entry ItemNameEntry = new Entry();
        private readonly Entry ItemIDEntry = new Entry();




        public NewPage (ShoppingItem itemToPresent)
        {
            _currentItem = itemToPresent;
            ItemNameEntry.Text = _currentItem.ItemName;
            ItemIDEntry.Text = _currentItem.ID.ToString();

            this.Content = new StackLayout
            {
                Children =
                {
                    ItemNameEntry, ItemIDEntry
                }
            };
        }

        private async void GoBack(object sender, System.EventArgs e)
        {
            // TO DO: Update the item data acordingly
            GoBackToMainPage();
        }

        protected override bool OnBackButtonPressed()
        {
            GoBackToMainPage();
            return true;

        }

        private async void GoBackToMainPage()
        {
            _currentItem.ItemName = ItemNameEntry.Text;
            _currentItem.ID = uint.Parse(ItemIDEntry.Text);

            await Database.Instance.UpdateItemData(_currentItem);
            await App.NavigationMethod.PopAsync();
        }
    }
}