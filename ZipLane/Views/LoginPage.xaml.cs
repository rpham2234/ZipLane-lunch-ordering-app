using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZipLane.ViewModels;

namespace ZipLane.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}