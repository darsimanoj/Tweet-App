using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Tweet_Client
{
    public static class Program
    {
        public static bool LoginStatus = false;
        public static Info i;
        public static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {

            //Console.WriteLine("Welcome To Tweet APP");
            RunAsync().GetAwaiter().GetResult();

        }

        static async Task RunAsync() 
        {
           
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

              Console.WriteLine("Welcome To Tweet APP");

            while (true)
            {
                if (!LoginStatus)
                    await Process1Async();
                else
                     await Process2Async();
            }
            Console.ReadLine();
        }

        private static async Task Process1Async()
        {
            
            Console.WriteLine("Please Select The Below Options to Proceed Further\n1.Register\n2.Login\n3.Forgot Password\n");
            int Primary_Choice = Convert.ToInt32(Console.ReadLine());
            switch (Primary_Choice)
            {
                case 1:
                    try
                    {
                        var url = await Primary.Register(client);

                        // Console.WriteLine(await url.Content.ReadAsStringAsync());
                        var a = await url.Content.ReadAsStringAsync();
                       
                       

                        //Console.WriteLine(id);
                        //Console.WriteLine(url == null ? "" : await url.Content.ReadAsStringAsync());

                        if (a == "")
                        {
                            Console.WriteLine("Your Registration is Successful, Please continue with Login");
                        }
                        else
                        {
                            var jo = JObject.Parse(a);
                            var id = jo["errors"];

                            Console.WriteLine(id.ToString());
                            Console.WriteLine("Please try registering again");
                        }
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message.ToString());
                    }
                    break;

                case 2:
                    try
                    {
                        var url = await Primary.Login(client);
                         var a = await url.Content.ReadAsStringAsync();
                        if(a != "")
                        {
                            Console.WriteLine("Login Successfull");
                            LoginStatus = true;
                            var jo = JObject.Parse(a);
                            
                            i = new Info() { Id = (int)jo["id"], Username = (string)jo["username"] };
                        }
                        else 
                        {
                            Console.WriteLine("Login failed");
                            
                        }
                    }
                    catch (Exception e) 
                    {
                        Console.WriteLine(e);
                    }
                     break;
                case 3:
                    try
                    {
                        await Primary.ForgotPassword(client);
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                default:
                    Console.WriteLine("please enter valid number");
                    break;
            }
        }

        
        private static async Task Process2Async()
        {
            Console.WriteLine("Please Select The Below Options to Proceed Further\n1.Post a Tweet\n2.View my tweets\n3.View All Users and their respective tweets\n4.Reset Password\n5.Logout");
            int secondary_Choice = Convert.ToInt32(Console.ReadLine());
            switch (secondary_Choice)
            {
                case 1:
                    try
                    {
                         await SecondaryProcess.Tweet(client);

                        

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message.ToString());
                    }
                    break;

                case 2:
                    try
                    {
                         await SecondaryProcess.GetUserTweets(client);
                        
                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                case 3:
                    try
                    {
                        await SecondaryProcess.GetAllUsersAndTweets(client);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                case 5:
                    try 
                    {
                        await SecondaryProcess.Logout(client);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                default:
                    Console.WriteLine("please enter valid number");
                    break;
            }


            //Console.ReadLine();
        }


      
    }
}
