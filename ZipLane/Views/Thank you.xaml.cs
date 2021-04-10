using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZipLane.Models;

namespace ZipLane.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Thank_You : ContentPage
    {
        public Thank_You()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            OrderData.OrderDate = OrderData.StudentID = OrderData.EntreeOrder = OrderData.SideOrder1 = OrderData.SideOrder2 = OrderData.MilkOrder = OrderData.DeliveryLocation = null; //Order has been placed. Data needs to be cleared.
            Navigation.PushAsync(new HomePage()); //Takes you back to the homepage. Nothing much to it.
        }
    }
}