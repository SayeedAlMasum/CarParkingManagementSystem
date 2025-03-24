//Program.cs
using Business;
using Business.FormModel;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Identity;

namespace BusinessTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegistrationTest();
            LoginTest();
            UserListTest();
        }

        static void RegistrationTest()
        {
            try
            {
                UserRegisterForm userRegisterForm = new UserRegisterForm();
                Console.WriteLine("Enter Full Name:");
                userRegisterForm.Name = Console.ReadLine();

                Console.WriteLine("Enter the Email:");
                userRegisterForm.Email = Console.ReadLine();

                Console.WriteLine("Enter Password:");
                userRegisterForm.Password = Console.ReadLine();

                var userInfoService = new UserInfoService();  // Instance of service
                Result result = userInfoService.Registration(userRegisterForm,"");  // Call registration method
                if (result.Success)
                {
                    Console.WriteLine("Registration successful!");
                }
                else
                {
                    Console.WriteLine($"Registration failed: {result.Message}");
                }
            }
          
              catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
        static void LoginTest()
        {
            UserLogInForm loginForm = new UserLogInForm();
            Console.WriteLine("Email");
            loginForm.Email = Console.ReadLine();
            Console.WriteLine("Password");
            loginForm.Password = Console.ReadLine();
            Result result = new UserInfoService().Login(loginForm.Email,loginForm.Password);
            Console.WriteLine(result.Message);
        }
        static void UserListTest()
        {
            Result result = new UserInfoService().List();

        }
        static void UserTest()
        {
            Result result = new UserInfoService().Single("UserId");

        }
    }
}