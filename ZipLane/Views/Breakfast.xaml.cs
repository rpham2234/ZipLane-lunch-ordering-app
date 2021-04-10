using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZipLane.Models;
namespace ZipLane.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Breakfast : ContentPage
    {
        public Breakfast()
        {
            InitializeComponent();
            //Sets the labels to desired values
            Breakfast1Text.Text = OrderData.BreakfastMenu.breakfast1;
            Breakfast2Text.Text = OrderData.BreakfastMenu.breakfast2;
            Breakfast3Text.Text = OrderData.BreakfastMenu.breakfast3;

            //Sets the image to desired values. Images are from cloudinary, and I had to employ a weird naming algorithm.
            Breakfast1Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Breakfast1Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Breakfast2Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Breakfast2Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Breakfast3Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Breakfast3Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");

        }

        private void OrderButton1_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Breakfast1Text.Text);
        }

        private void OrderButton2_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Breakfast2Text.Text);
        }

        private void OrderButton3_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Breakfast3Text.Text);
        }

        //Sets the BreakfastOrder global variable, then navigates to the sides option.
        public async void AnyButton_Clicked(string order)
        {
            OrderData.EntreeOrder = order;
            Debug.WriteLine(OrderData.EntreeOrder);
            await Navigation.PushAsync(new SideDish());
        }
    }
}