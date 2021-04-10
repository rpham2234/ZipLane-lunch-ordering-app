using Newtonsoft.Json;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZipLane.Models;
using ZipLane.Services;

namespace ZipLane.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Order : ContentPage
    {


        public Order()
        {
            InitializeComponent();
            OrderDate.Date = DateTime.Now;
        }

        //SendGETREQUEST
        public async void SendGETRequest(string Mealtype)
        {
            //Sends GET request, then navigates to next page.
            Web_API api = new Web_API(); //I recommend getting a real phone to test it on; I don't know how this will work on emulators, or if emulators can connect to local network.
            OrderData.HttpResponse = await api.GetMenu(Mealtype, OrderData.OrderDate); //The "/" (forward slash) has already been added into the function.
            var status = await api.GetStatusCode(Mealtype, OrderData.OrderDate);

            //Status code is not a number, unlike Thunkable
            if (status.ToString() == "OK" && OrderData.HttpResponse != "") //Makes sure the data is loaded before navigating to the next page
            {
                if (Mealtype == "OVHS2") //Jim and John built the server, and the JSON's, not me. It hasn't been updated since August of 2020
                {
                    OrderData.lunchMenu = JsonConvert.DeserializeObject<LunchMenu>(OrderData.HttpResponse);
                    Debug.WriteLine(OrderData.lunchMenu);
                    OrderData.BreakfastMenu = null; //Before navigating to the next page, it clears the BreakfastMenu data to prevent problems with the Side Dish.
                    await Navigation.PushAsync(new Lunch());
                }
                else if (Mealtype == "OVHSBreakfast") //I added this part of the server later on.
                {
                    OrderData.BreakfastMenu = JsonConvert.DeserializeObject<BreakfastMenu>(OrderData.HttpResponse);
                    Debug.WriteLine(OrderData.BreakfastMenu);
                    OrderData.lunchMenu = null;
                    await Navigation.PushAsync(new Breakfast());
                }
            }
            else if (status.ToString() == "OK" && OrderData.HttpResponse == "")
            {
                await DisplayAlert("Invalid Date, try again", "", "OK");
            }



            Debug.WriteLine(OrderData.HttpResponse);
        }

        //When Button that says Breakfast is clicked
        private void BreakfastButton_Clicked(object sender, EventArgs e)
        {
            OrderData.OrderType = "Breakfast";
            AnyButtonClicked("Breakfast");
        }

        //When Button that says Lunch is clicked
        private void LunchButton_Clicked(object sender, EventArgs e)
        {
            OrderData.OrderType = "Lunch";
            AnyButtonClicked("Lunch");
        }

        //What happens if you press breakfast or lunch buttons. it takes a mealtype parameter.
        public async void AnyButtonClicked(string Mealtype)
        {
            if (Classroom.Text == null)
            {
                await DisplayAlert("Invalid Entry", "You need to enter your 4th period classroom", "OK");
            }
            else
            {
                //These are global variables
                OrderData.OrderDate = OrderDate.Date.ToString("MM/dd/yyyy"); //I need to format the date in DatePicker
                OrderData.DeliveryLocation = Classroom.Text;

                //I need to make sure the variables are carrying the correct data.
                Debug.WriteLine("Student ID is " + OrderData.StudentID);
                Debug.WriteLine("OrderDate is " + OrderData.OrderDate);
                Debug.WriteLine("Delivery Location is " + OrderData.DeliveryLocation);



                if (Mealtype == "Breakfast")
                {
                    SendGETRequest("OVHSBreakfast"); //Sends the request. Once the request is completed, it navigates to the next page.


                }
                else if (Mealtype == "Lunch")
                {
                    SendGETRequest("OVHS2");


                }
            }
        }
    }
}