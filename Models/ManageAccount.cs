using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP_template.Models
{
    public class ManageAccount
    {
        public static string UserAccountIdGenerate()
        {
            Random res = new Random();
            string str = "0123456789";
            int size = 8;
            string id = "US";
            for (int i = 0; i < size; i++)
            {
                // Selecting a index randomly
                int x = res.Next(str.Length);
                // Appending the character at the 
                // index to the random alphanumeric string.
                id = id + str[x];
            }
            return id;
        }


        public static void SinupAccount(string username, string email, string password, string role)
        {
            using var dbContext = new SwpContext();
            string accID = UserAccountIdGenerate();
            var info = new InfoAccount()
            {
                AccountId = accID,
                Name = "",
                Age = "",
                Phone = "",
                Email = email,
                Gender = "",
                Birthday = "",
                Nation = "",
                Identitycard = "",
            };
            var p1 = new Accountss()
            {
                AccountId = accID,
                Username = username,
                Password = password,
                Role = role,
                Email = email,
            };


            dbContext.AddAsync(p1);
            dbContext.AddAsync(info);

            dbContext.SaveChanges();

        }

        public static Accountss UserLogin(string username, string password, string RoleID)
        {
            using var dbcontext = new SwpContext();
            var account = (from a in dbcontext.Accountsses
                           where a.Username.Equals(username) && a.Password.Equals(password) && a.Role.Equals(RoleID)
                           select a).FirstOrDefault();
            if (account != null)
                return account;
            return null;
        }
        // public void ReadHotel(){

        // }
    }
}