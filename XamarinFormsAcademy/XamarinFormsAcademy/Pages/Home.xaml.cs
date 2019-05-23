using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsAcademy.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
        public ObservableCollection<PostItem> Items { get; set; }
        public Home ()
		{
			InitializeComponent ();
            AddButton.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("add_button.png") : ImageSource.FromFile("Assets/add_button.png");
            Items = new ObservableCollection<PostItem>(PostDatabase.Instance.GetItemsAsync().Result);

            MyListView.ItemsSource = Items;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Post());
        }
    }
}