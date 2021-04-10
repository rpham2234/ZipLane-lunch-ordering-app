using Xamarin.Forms;
using ZipLane.ViewModels;

namespace ZipLane.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}