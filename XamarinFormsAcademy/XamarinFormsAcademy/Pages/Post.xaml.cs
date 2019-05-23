using DataAccessLayer;
using SQLite;
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
    public partial class Post : ContentPage
    {

        public Post()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PostDatabase.Instance.UpdateItemData(PostContent.Text);
            await Navigation.PopAsync();
            await Navigation.PushAsync(new Home());
        }
    }

    public class PostItem
    {
        [PrimaryKey]
        public uint ID { get; set; }

        [NotNull]
        public string Content { get; set; }
    }

}