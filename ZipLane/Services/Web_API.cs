using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ZipLane.Models;

namespace ZipLane.Services
{
    //This class manages ALL HTTP requests to and from the server. The backend server is built in Node.js
    class Web_API
    {
        //These use the default System.Net.Http class.

        HttpClient client = new HttpClient();

        //This gets the status code of the request.
        public async Task<System.Net.HttpStatusCode> GetStatusCode(string path, string day)
        {
            var response = await client.GetAsync(OrderData.ServerUrl + "/" + path + "?day=" + day);

            return response.StatusCode;
        }

        //This gets the menu JSON
        public async Task<string> GetMenu(string path, string day) //path = "/OVHS2, and day = "03/18/2020"
        {
            string response = await client.GetStringAsync(OrderData.ServerUrl + "/" + path + "?day=" + day);

            return response;
        }

        //This sends a POST request of the order data. It uses the RestSharp Nuget package, since I don't know the default method of sending POST requests.
        public void SendOrderData(string OrderData)
        {
            string url = "http://192.168.1.118:80/Sales";

            var client = new RestClient(url);

            var request = new RestRequest();

            var body = OrderData; //Raw data format.

            request.AddJsonBody(body);

            var response = client.Post(request);

            Console.WriteLine(response.StatusCode.ToString());
        }
    }
}
