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
        public Result Login(string email, string password)
        {
            // Initialize the database context
            using var context = new CarParkingContext();

            // Find the user by email
            var user = context.UserInfo.FirstOrDefault(u => u.Email == email);
            if (user == null) return new Result(false, "User not found!");

            // Verify the hashed password
            var passwordHasher = new PasswordHasher<object>();
            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            // Return success or failure based on password verification
            return verificationResult == PasswordVerificationResult.Success
                ? new Result(true, "Login successful!", user)
                : new Result(false, "Invalid password!");
        }
        public Result Update(UserRegisterForm user)
        {
            //logics
            return new Result().DBCommit(carParkingContext, "Updated Successfully!", null, user);
        }
        public Result List()
        {
            try
            {
                using var context = new CarParkingContext();
                var users = context.UserInfo.ToList();

                if (users.Count == 0)
                    return new Result(false, "No users found.");

                return new Result(true, "User list retrieved successfully.", users);
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
