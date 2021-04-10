using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZipLane.Models;

namespace ZipLane.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideDish : ContentPage
    {
        public int NumSides = 0;

        bool CheckBox1Clicked;
        bool CheckBox2Clicked;
        bool CheckBox3Clicked;
        bool CheckBox4Clicked;

        public SideDish()
        {
            InitializeComponent();
            //resetSides(false);
            //Sets the labels to desired values
            if (OrderData.lunchMenu != null)
            {
                Fruit1Text.Text = OrderData.lunchMenu.fruit1;
                Fruit2Text.Text = OrderData.lunchMenu.fruit2;
                Fruit3Text.Text = OrderData.lunchMenu.fruit3;
                Fruit4Text.Text = OrderData.lunchMenu.fruit4;
            }
            else //If you ordered breakfast instead of lunch.
            {
                Fruit1Text.Text = OrderData.BreakfastMenu.fruit1;
                Fruit2Text.Text = OrderData.BreakfastMenu.fruit2;
                Fruit3Text.Text = OrderData.BreakfastMenu.fruit3;
                Fruit4Text.Text = OrderData.BreakfastMenu.fruit4;
            }




            //Sets the image to desired values. Images are from cloudinary, and I had to employ a weird naming algorithm. Images are uploaded manually.
            Fruit1Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Fruit1Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Fruit2Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Fruit2Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Fruit3Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Fruit3Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
            Fruit4Image.Source = "https://res.cloudinary.com/lunchapp/image/upload/Placeholder%20Images/" + Fruit4Text.Text.Replace("w/", "with").Replace("&", "+").Replace(" ", "");
        }

        private void OrderCheckBox1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (OrderCheckBox1.IsChecked == true)
            {
                CheckBox1Clicked = true;
                Debug.WriteLine(CheckBox1Clicked);
            }
            else if (OrderCheckBox1.IsChecked == false)
            {
                CheckBox1Clicked = false;
                Debug.WriteLine(CheckBox1Clicked);
            }
        }

        private void OrderCheckBox2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (OrderCheckBox2.IsChecked == true)
            {
                CheckBox2Clicked = true;
                Debug.WriteLine(CheckBox2Clicked);
            }
            else if (OrderCheckBox2.IsChecked == false)
            {
                CheckBox2Clicked = false;
                Debug.WriteLine(CheckBox1Clicked);
            }
        }

        private void OrderCheckBox3_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (OrderCheckBox3.IsChecked == true)
            {
                CheckBox3Clicked = true;
                Debug.WriteLine(CheckBox3Clicked);
            }
            else if (OrderCheckBox3.IsChecked == false)
            {
                CheckBox3Clicked = false;
                Debug.WriteLine(CheckBox1Clicked);
            }
        }

        private void OrderCheckBox4_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (OrderCheckBox4.IsChecked == true)
            {
                CheckBox4Clicked = true;
                Debug.WriteLine(CheckBox4Clicked);
            }
            else if (OrderCheckBox4.IsChecked == false)
            {
                CheckBox4Clicked = false;
                Debug.WriteLine(CheckBox1Clicked);
            }
        }

        private async void Nextbutton_Clicked(object sender, EventArgs e)
        {
            if (CheckBox1Clicked == true)
            {
                OrderData.SideOrder1 = Fruit1Text.Text;
                NumSides++;
            }
            if (CheckBox2Clicked == true)
            {
                if (OrderData.SideOrder1 == "")
                {
                    OrderData.SideOrder1 = Fruit2Text.Text;
                    NumSides++;
                }
                else
                {
                    OrderData.SideOrder2 = Fruit2Text.Text;
                    NumSides++;
                }
            }
            if (CheckBox3Clicked == true)
            {
                if (OrderData.SideOrder1 == "")
                {
                    OrderData.SideOrder1 = Fruit3Text.Text;
                    NumSides++;
                }
                else
                {
                    OrderData.SideOrder2 = Fruit3Text.Text;
                    NumSides++;
                }
            }
            if (CheckBox4Clicked == true)
            {
                if (OrderData.SideOrder1 == "")
                {
                    OrderData.SideOrder1 = Fruit4Text.Text;
                    NumSides++;
                }
                else
                {
                    OrderData.SideOrder2 = Fruit4Text.Text;
                    NumSides++;
                }
            }

            //Ensures that the sides are selected. Cannot select more than 2 sides
            if (NumSides == 0 || NumSides >= 3)
            {
                resetSides(true);
            }
            else
            {
                Debug.WriteLine(OrderData.SideOrder1);
                Debug.WriteLine(OrderData.SideOrder2);
                await Navigation.PushAsync(new Milk());
            }
        }

        public async void resetSides(bool show)
        {
            NumSides = 0; //Resets the counter
            CheckBox1Clicked = false; //Resets all the checkboxes
            CheckBox2Clicked = false;
            CheckBox3Clicked = false;
            CheckBox4Clicked = false;
            OrderCheckBox1.IsChecked = false;
            OrderCheckBox2.IsChecked = false;
            OrderCheckBox3.IsChecked = false;
            OrderCheckBox4.IsChecked = false;
            OrderData.SideOrder1 = null;
            OrderData.SideOrder2 = null;
            if (show == true)
            {
                await DisplayAlert("You Must Select 1 or 2 sides", "", "OK"); //shows the prompt.
            }

        }
        //What happens if you click any of the "Order" buttons, code here is pretty repetitive.



    }
}