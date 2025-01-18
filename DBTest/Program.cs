using Database.Context;
using Database.Model;
using System.Data;
namespace DBTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new CarParkingContext();
            try
            {
                if (db.UserInfo != null)
                {
                    for (int i = 0; i < 50; i++)
                    {
                        db.UserInfo.Add(new UserInfo
                        {
                            Name = "User-" + i,
                            Email = "User" + i + "@user.user",
                            PasswordHash = "Hash" + i,
                            Location = "Location" + i,
                            IsActive = i % 2 == 0,
                            RoleId = 3
                        });
                    }
                    db.SaveChanges();
                }

                db.SaveChanges();

            }


            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }
        }

        Console.WriteLine(DateTime.Now);


        }
    }
}
