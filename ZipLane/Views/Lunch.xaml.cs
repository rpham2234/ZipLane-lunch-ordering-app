using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZipLane.Models;

namespace ZipLane.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Lunch : ContentPage
    {
        public Lunch()
        {
            InitializeComponent();

            //Parses the recieved JSON
            //LunchMenu Menu = JsonConvert.DeserializeObject<LunchMenu>(OrderData.HttpResponse);

            //Sets the labels to desired values
            Entree1Text.Text = OrderData.lunchMenu.entree1;
            Entree2Text.Text = OrderData.lunchMenu.entree2;
            Entree3Text.Text = OrderData.lunchMenu.entree3;
            Entree4Text.Text = OrderData.lunchMenu.entree4;
            Entree5Text.Text = OrderData.lunchMenu.entree5;
            Entree6Text.Text = OrderData.lunchMenu.entree6;


            //Sets the image to desired values. Images are from cloudinary, and I had to employ a weird naming algorithm.
            Entree1Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Entree1Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Entree2Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Entree2Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Entree3Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Entree3Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Entree4Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Entree4Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Entree5Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Entree5Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Entree6Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Entree6Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");

        }

        //What happens if you click any of the "Order" buttons, code here is pretty repetitive.
        private void OrderButton1_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Entree1Text.Text);
        }

        private void OrderButton2_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Entree2Text.Text);
        }

        private void OrderButton3_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Entree3Text.Text);
        }

        private void OrderButton4_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Entree4Text.Text);
        }

        private void OrderButton5_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Entree5Text.Text);
        }

        private void OrderButton6_Clicked(object sender, EventArgs e)
        {
            AnyButton_Clicked(Entree6Text.Text);
        }

        //Sets the EntreeOrder global variable, then navigates to the sides option.
        public async void AnyButton_Clicked(string order)
        {
            OrderData.EntreeOrder = order;
            Debug.WriteLine(OrderData.EntreeOrder);
            await Navigation.PushAsync(new SideDish());
        }
    }
}