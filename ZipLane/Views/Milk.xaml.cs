using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZipLane.Models;

namespace ZipLane.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Milk : ContentPage
    {
        public Milk()
        {
            InitializeComponent();
            if (OrderData.lunchMenu != null)
            {
                Milk1Text.Text = OrderData.lunchMenu.milk1;
                Milk2Text.Text = OrderData.lunchMenu.milk2;
                Milk3Text.Text = OrderData.lunchMenu.milk3;

            }
            else //If you ordered breakfast instead of lunch.
            {
                Milk1Text.Text = OrderData.BreakfastMenu.milk1;
                Milk2Text.Text = OrderData.BreakfastMenu.milk2;
                Milk3Text.Text = OrderData.BreakfastMenu.milk3;

            }
            //Sets the image to desired values. Images are from cloudinary, and I had to employ a weird naming algorithm. Images are uploaded manually.
            Milk1Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Milk1Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Milk2Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Milk2Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Milk3Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Milk3Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");

        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Clears side order variables in case user changes his/her/their mind.
            OrderData.SideOrder1 = null;
            OrderData.SideOrder2 = null;
            Debug.WriteLine(OrderData.SideOrder1);
            Debug.WriteLine(OrderData.SideOrder2);


        }

        private async void Nextbutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Order_Summary());
        }
        private void OrderButton1_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Milk1Text.Text);
        }

        private void OrderButton2_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Milk2Text.Text);
        }

        private void OrderButton3_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Milk3Text.Text);
        }


        //Sets the MilkOrder global variable, then navigates to the sides option.
        public async void AnyButton_Clicked(string order)
        {
            OrderData.MilkOrder = order;
            Debug.WriteLine(OrderData.MilkOrder);
            await Navigation.PushAsync(new Order_Summary());
        }
    }
}