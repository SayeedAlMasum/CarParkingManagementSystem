//UserInfoService.cs
using Business.FormModel;
using Database.Context;
using Database.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services;
namespace Business.Services
{
    public class UserInfoService
    {
        // Initialize the database context to interact with the database
        CarParkingContext carParkingContext = new CarParkingContext();

        // Method to handle the registration of a new user
         public Result Registration(UserRegisterForm user, string role)
        {
            if (carParkingContext.UserInfo.Any(x => x.Email == user.Email))
                return new Result(false, "Email already registered!");

            var userInfo = new UserInfo
            {
                    Name = user.Name,
                    Email=user.Email,
                    PasswordHash = new PasswordHasher<UserInfo>().HashPassword(null,user.Password),
                    Role = role,
                    IsActive=true,
                    Location="Unknown"
            };
            carParkingContext.UserInfo.Add(userInfo);
            carParkingContext.SaveChanges();
            return new Result(true, "Registered Successfully!");
        }
        // Handles user login
        public Result LogIn(UserLogInForm user)
        {
            var userInfo = carParkingContext.UserInfo.FirstOrDefault(x => x.Email == user.Email);

            if (userInfo == null)
            {
                return new Result(false, "Email not found. Please register first.");
            }

            var passwordVerification = new PasswordHasher<UserInfo>().VerifyHashedPassword(userInfo, userInfo.PasswordHash, user.Password);

            if (passwordVerification == PasswordVerificationResult.Success)
            {
                // Return the role along with the success message
                return new Result(true, $"{userInfo.Name} successfully logged in!", userInfo.Role);
            }
            else
            {
                return new Result(false, "Incorrect password.");
            }
        }





        public Result Update(UserRegisterForm user)
        {
            //logics
            return new Result().DBCommit(carParkingContext, "Updated Successfully!", null, user);
        }
        public Result List()
        {
            //logics
            try
            {
                var Users = carParkingContext.UserInfo.ToList();
                return new Result(true, "Success", Users);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
        public Result Single(string userInfoId)
        {
            try
            {
                using var context = new CarParkingContext();
                var user = context.UserInfo.FirstOrDefault(u => u.UserInfoId == userInfoId);

                if (user == null)
                    return new Result(false, "User not found.");

                return new Result(true, "User retrieved successfully.", user);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

    }
}
