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
    class Program
    {
        static bool LoginStatus = false;
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {

              Console.WriteLine("Welcome To Tweet APP");
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
                     Process2Async();
            }
             

  

           
            
            Console.ReadLine();
        }

        private static void Process2Async()
        {
            Console.WriteLine("2 process");
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
                        var url = await Register();

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
                        var url = await Login();
                        var a = await url.Content.ReadAsStringAsync();
                        if(a == "true")
                        {
                            Console.WriteLine("Login Successfull");
                            LoginStatus = true;
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
                    
                    break;
            }
        }

        static async Task<HttpResponseMessage> Login()
        {
            Console.WriteLine("Please Enter Your Login Credentials\n1.UserName (Required)\n2.Password (Required)\n");
            var UserName = Console.ReadLine();
            var Password = Console.ReadLine();

            Login login = new Login()
            {
                username = UserName,
                password = Password

            };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/User/Login", login);
            return response;
        }
        static async Task<HttpResponseMessage>? Register()
        {
            Console.WriteLine("Please Enter Your Details as Below For Registration\n1.FirstName (Required)\n2.LastName (Optional)\n3.Gender (Male/Female) (Required)\n4.Birth Date (Optional, dd-MM-yyyy)\n5.UserName (Required, Must be Unique)\n6.Password (Required)\n");
            var FirstName = Console.ReadLine();
            var Lastname = Console.ReadLine();
            var Gender = Console.ReadLine();
            var Dob = Console.ReadLine();
            var Email = Console.ReadLine();
            var Password = Console.ReadLine();
            User u = new User
            {
                FirstName = FirstName,
                Lastname = Lastname,
                Gender = Gender,
                Dob  = string.IsNullOrWhiteSpace(Dob)? (DateTime?)null : Convert.ToDateTime(Dob),
                Email = Email,
                Password = Password
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/User", u);
            return response;

            /* var context = new ValidationContext(u, null, null);
             var result = new List<ValidationResult>(); var isValid = Validator.TryValidateObject(u, context, result, true);
 */

            /* if (result.Count == 0)
             {
                 HttpResponseMessage response = await client.PostAsJsonAsync("api/User", u);
                 return response;
             }
             else
             {
                 foreach (var str in result)
                 {
                     Console.WriteLine(str.ErrorMessage.ToString());
                 }

                 return null;
             }*/

            //response.EnsureSuccessStatusCode();


        }
    }
}
