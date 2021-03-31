using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tweet_Client
{
   public  static class SecondaryProcess
    {
        public static async Task Tweet(HttpClient client)
        {
            Console.WriteLine("Post a Tweet");
            string tweet = Console.ReadLine();
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Tweet/"+ Program.i.Id,  tweet);
            var a = await response.Content.ReadAsStringAsync();
            if(a == "true")
            {
                Console.WriteLine("Tweeted Successfully");
            }
            else 
            {
                Console.WriteLine("Post failed, i am sorry try again");
            }
            

        }

        public static async Task GetUserTweets(HttpClient client)
        {
            Console.WriteLine("Getting your tweets");
            //string tweet = Console.ReadLine();
            HttpResponseMessage response = await client.GetAsync("api/Tweet/" + Program.i.Id);
            var a = await response.Content.ReadAsStringAsync();
            if(a != "")
            {
                var jo = JArray.Parse(a);
                foreach (var x in jo)
                {
                    Console.WriteLine(x.ToString());
                }
            }
            else
            {
                Console.WriteLine("");
            }



        }

        public static async Task GetAllUsersAndTweets(HttpClient client)
        {
            Console.WriteLine("Getting all users, tweets");
            //string tweet = Console.ReadLine();
            HttpResponseMessage response = await client.GetAsync("api/Tweet/");
            var a = await response.Content.ReadAsStringAsync();
            if (a != "")
            {
                var jo = JObject.Parse(a);
                foreach (var x in jo)
                {
                    Console.WriteLine(x.Key);
                   /* var y = JArray.Parse(() x.Value);*/
                    foreach (string de in x.Value)
                    {
                        Console.WriteLine(de);
                    }
                        
                    /*var y = JObject.Parse(x);
                    Console.WriteLine(y.ToString());
                    foreach (var j in y)
                    {
                        Console.WriteLine(j);
                    }*/
                    Console.WriteLine("======");
                }
            }
            else
            {
                Console.WriteLine("");
            }



        }

        public static async Task Logout(HttpClient client)
        {
            Console.WriteLine("Logging off");
            //string tweet = Console.ReadLine();
            HttpResponseMessage response = await client.PostAsJsonAsync("api/User/Logout", Program.i.Id);
            var a = await response.Content.ReadAsStringAsync();
            if (a != "false")
            {

                Program.i = null;
                Program.LoginStatus = false;
                Console.WriteLine("Successfully Logged out");
            }
            else
            {
                Console.WriteLine("Please try again to Logout");
            }



        }
    }
}
