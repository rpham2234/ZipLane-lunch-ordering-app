namespace ZipLane.Models
{
    //Contains all the global variables for the project
    public class OrderData
    {
        //Url. (Example: http://192.168.1.115:8080, or http://ziplane.hopto.org). Don't forget the port, and DO NOT USE LOCALHOST. 
        //addresses starting with 192.168... (local networks) do not play well with emulators.
        public static string Url = "http://192.168.1.118:80"; //put your nodejs server url here
        public static string ServerUrl
        {
            get { return Url; }
            set { Url = value; }
        }

        //HTTP response (usually a JSON format)
        public static string Response;
        public static string HttpResponse
        {
            get { return Response; }
            set { Response = value; }
        }

        //Parsed JSON data, because apparently, it's important enough to warrant having it's own variable.
        public static LunchMenu lmenu = new LunchMenu();
        public static LunchMenu lunchMenu
        {
            get { return lmenu; }
            set { lmenu = value; }
        }

        //Apparantly, Breakfast needs it's own variable too!!! WTF Microsoft???!?!?!?!?!?!?!?!?!?
        public static BreakfastMenu bmenu = new BreakfastMenu();
        public static BreakfastMenu BreakfastMenu
        {
            get { return bmenu; }
            set { bmenu = value; }
        }

        //Student ID
        public static string Id;
        public static string StudentID
        {
            get { return Id; }
            set { Id = value; }
        }

        //OrderDate
        public static string Date;
        public static string OrderDate
        {
            get { return Date; }
            set { Date = value; }
        }

        //Meal type (Breakfast or Lunch)
        public static string Order;
        public static string OrderType
        {
            get { return Order; }
            set { Order = value; }
        }

        //Pickup Location
        public static string Location;
        public static string DeliveryLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        //Entree order
        public static string Entree;
        public static string EntreeOrder
        {
            get { return Entree; }
            set { Entree = value; }
        }
        //Breakfast order
        public static string Breakfast;
        public static string BreakfastOrder
        {
            get { return Breakfast; }
            set { Breakfast = value; }
        }
        //You can order two side dishes. There are two variables to reflect that; SideOrdered1 and SideOrdered2
        public static string Side1;
        public static string SideOrder1
        {
            get { return Side1; }
            set { Side1 = value; }
        }
        //Second side dish. Pretty self explanatory.
        public static string Side2;
        public static string SideOrder2
        {
            get { return Side2; }
            set { Side2 = value; }
        }
        //Milk order. Milk menu items aren't hard coded and have to be fetched from the server.
        public static string Milk;
        public static string MilkOrder
        {
            get { return Milk; }
            set { Milk = value; }
        }
    }
}
