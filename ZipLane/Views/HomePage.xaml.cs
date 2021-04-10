using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZipLane.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        int studentID;


        public HomePage()
        {
            InitializeComponent();
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            studentID = Convert.ToInt32(StudentID.Text);

            ZipLane.Models.OrderData.StudentID = StudentID.Text;

            Debug.WriteLine("Variable", studentID);
            Debug.WriteLine("Entry", StudentID.Text);


            if (studentID > 10000 && studentID < 10000000)
            {
                await Navigation.PushAsync(new Order());
            }
            else if (StudentID.Text == null)
            {
                await DisplayAlert("Invalid Student ID", "You must enter a Student ID", "OK");
            }
            else
            {
                await DisplayAlert("Invalid Student ID", "You must enter a Student ID", "OK");
            }

        }
    }
}