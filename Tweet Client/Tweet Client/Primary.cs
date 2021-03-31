using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tweet_Client
{
    public static class Primary
    {
        public static async Task ForgotPassword(HttpClient client)
        {
            Console.WriteLine("Please Entert your Email");
            string email = Console.ReadLine();
            HttpResponseMessage response = await client.GetAsync("api/User/" + email);
            var a = await response.Content.ReadAsStringAsync();
            if (a == "true")
            {
                Console.WriteLine("Please Entert your Password");
                string password = Console.ReadLine();
                if (password == "" | password.Length > 10) { Console.WriteLine("Password is not valid"); }
                else
                {
                    HttpResponseMessage respo = await client.PutAsJsonAsync("api/User/" + email, password);
                    var b = await respo.Content.ReadAsStringAsync();
                    if (b == "true")
                    {
                        Console.WriteLine("password updated Successfull");

                    }
                    else
                    {
                        Console.WriteLine("password updation failed");

                    }
                }
            }

            else
            {
                Console.WriteLine("Verify your Email ");

            }



        }

        public static async Task<HttpResponseMessage> Login(HttpClient client)
        {
            try 
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
            catch (Exception e) 
            {
                Console.WriteLine(e.Message.ToString());
                
            }
            return new HttpResponseMessage { StatusCode = (System.Net.HttpStatusCode)400 };
        }
        public static async Task<HttpResponseMessage>? Register(HttpClient client)
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
                Dob = string.IsNullOrWhiteSpace(Dob) ? (DateTime?)null : Convert.ToDateTime(Dob),
                Email = Email,
                Password = Password
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/User", u);
            return response;

           

        }
    }
}







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
