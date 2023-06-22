using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP_template.Models
{
    public class EFManage
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

        public static string OwnerAccountIdGenerate()
        {
            Random res = new Random();
            string str = "0123456789";
            int size = 8;
            string id = "OW";
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
            string accID;
            using var dbContext = new Swp1Context();
            if(role.Equals("R002")) accID = OwnerAccountIdGenerate();
             else accID = UserAccountIdGenerate();
           
            var p1 = new Accountss()
            {
                AccountId = accID,
                Username = username,
                Password = password,
                RoleId = role,
                Email = email,
                Name = " ",
                Phone = " ",
                Gender = " ",
                Birthday = " ",
                Nation = "  ",
                Identitycard = " ",
            };


            dbContext.AddAsync(p1);
            dbContext.SaveChanges();

        }

        public static string Login(string username, string password, string role)
        {
            using var dbcontext = new Swp1Context();
            var account = (from a in dbcontext.Accountsses
                           where a.Username.Equals(username) && a.Password.Equals(password) && a.RoleId.Equals(role)
                           select a).FirstOrDefault();
            if (account != null)
                return account.AccountId;
            return null;
        }
        // public void ReadHotel(){

        // }
        public async Task OnGetAsync(string searchString)
        {
            using var dbcontext = new Swp1Context();
            //int totalHotel = dbcontext.Hotels.Where
        }
    }
}