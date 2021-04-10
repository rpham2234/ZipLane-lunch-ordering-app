using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZipLane.Models;
using ZipLane.Services;

namespace ZipLane.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Order_Summary : ContentPage
    {
        //Creates new instance of Web API class
        Web_API api = new Web_API();

        public Order_Summary()
        {
            InitializeComponent();
            mealtype.Text = OrderData.OrderType;
            date.Text = OrderData.OrderDate;
            studentId.Text = OrderData.StudentID;
            entree.Text = OrderData.Entree;
            side1.Text = OrderData.SideOrder1;
            side2.Text = OrderData.SideOrder2;
            milk.Text = OrderData.MilkOrder;
            location.Text = OrderData.Location;

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //Sends a POST request to http://192.168.1.118/Sales
            string orderDataBody = OrderData.OrderDate + "," + OrderData.StudentID + "," + OrderData.EntreeOrder + "," + OrderData.SideOrder1 + "," + OrderData.SideOrder2 + "," + OrderData.MilkOrder + "," + OrderData.DeliveryLocation; //Body to send POST request.
            api.SendOrderData(orderDataBody);
            Navigation.PushAsync(new Thank_You());
        }
    }
}