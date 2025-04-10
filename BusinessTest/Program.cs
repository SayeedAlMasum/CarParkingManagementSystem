//BusinessTest/Program.cs
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
            Registration();
            LogIn();
            UserListTest();
            UserInfoTest();
        }

        static void Registration()
        {
            try
            {
                UserRegisterForm userRegisterForm = new UserRegisterForm();
                Console.WriteLine("Enter Full Name:");
                userRegisterForm.Name = Console.ReadLine();  // Use Name as defined in the model
                Console.WriteLine("Enter the Email:");
                userRegisterForm.Email = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                userRegisterForm.Password = Console.ReadLine();

                var userInfoService = new UserInfoService();  // Instance of service
                Result result = userInfoService.Registration(userRegisterForm," ");  // Call registration method
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
        static void LogIn()
        {
            try
            {
                UserLogInForm userLoginForm = new UserLogInForm();
                Console.WriteLine("Enter the Email:");
                userLoginForm.Email = Console.ReadLine();
                Console.WriteLine("Enter the Password:");
                userLoginForm.Password = Console.ReadLine();

                var userService = new UserInfoService();  // Instance of service
                Result result = userService.LogIn(userLoginForm);  // Call login method
                Console.WriteLine(result.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        static void UserListTest()
        {
            Result result = new UserInfoService().List();
            Console.WriteLine(result.Message);
            if (result.Success)
            {
                // If result is successful, print user details
                foreach (var user in (List<UserInfo>)result.Data)
                {
                    Console.WriteLine($"Name: {user.Name}, Email: {user.Email}, RoleId: {user.RoleId}");
                }
            }
        }

        static void UserInfoTest()
        {
            Console.WriteLine("Enter UserId:");
            string userInfoId = Console.ReadLine();
            Result result = new UserInfoService().Single(userInfoId);
            Console.WriteLine(result.Message);
        }
    }
}