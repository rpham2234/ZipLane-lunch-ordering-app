using Xamarin.Forms;

using ZipLane.Models;
using ZipLane.ViewModels;

namespace ZipLane.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}