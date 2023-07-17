
using ServiceStack;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Humanizer;
using System.Data.SqlTypes;
using System;

namespace SWP_template.Models
{
    public static class EFManage
    {
        public static string UserAccountIdGenerate()
        {
            Random res = new();
            const string str = "0123456789";
            const int size = 8;
            string id = "US";
            for (int i = 0; i < size; i++)
            {
                // Selecting a index randomly
                int x = res.Next(str.Length);
                // Appending the character at the 
                // index to the random alphanumeric string.
                id += str[x];
            }
            return id;
        }

        public static string OwnerAccountIdGenerate()
        {
            Random res = new();
            const string str = "0123456789";
            const int size = 8;
            string id = "OW";
            for (int i = 0; i < size; i++)
            {
                // Selecting a index randomly
                int x = res.Next(str.Length);
                // Appending the character at the 
                // index to the random alphanumeric string.
                id += str[x];
            }
            return id;
        }
        public static string AdminAccountIdGenerate()
        {
            Random res = new();
            const string str = "0123456789";
            const int size = 8;
            string id = "AD";
            for (int i = 0; i < size; i++)
            {
                // Selecting a index randomly
                int x = res.Next(str.Length);
                // Appending the character at the 
                // index to the random alphanumeric string.
                id += str[x];
            }
            return id;
        }
        public static void SinupAccount(string name, string username, string email, string password, string role)
        {
            string accID;
            using var dbContext = new Swp1Context();
            if (role.Equals("R001")) accID = AdminAccountIdGenerate();
            else if (role.Equals("R002")) accID = OwnerAccountIdGenerate();
            else accID = UserAccountIdGenerate();
            var p1 = new Accountss()
            {
                AccountId = accID,
                Username = username,
                Password = password,
                RoleId = role,
                Email = email,
                Name = name,
                Phone = " ",
                Gender = " ",
                Birthday = " ",
                Nation = "  ",
                Identitycard = " ",
            };
            dbContext.AddAsync(p1);
            dbContext.SaveChanges();
        }

        public static Accountss Login(string username, string password, string role)
        {
            using var dbcontext = new Swp1Context();
            
            var account = (from a in dbcontext.Accountsses
                           where a.Username.Equals(username) && a.Password.Equals(password) && a.RoleId.Equals(role)
                           select a).FirstOrDefault();
            if (account != null)
            {
                return account;
            }
            return null;
        }
        public static Accountss ForgotPassword(string account, string email)
        {
            using var dbcontext = new Swp1Context();
            return (from a in dbcontext.Accountsses where a.Username.Equals(account) && a.Email.Equals(email) select a).FirstOrDefault();
        }

        public static void ChangePassword(string username, string password, string roleID)
        {
            using var dbcontext = new Swp1Context();
            (from a in dbcontext.Accountsses where a.Username.Equals(username) && a.RoleId.Equals(roleID) select a)
                .ToList().ForEach(x => x.Password = password);
            dbcontext.SaveChanges();
        }
        public static void EditProfile(string accID, string name, string DOB, string email, string phone, string nation, string gender, string identitycard)
        {
            using var dbcontext = new Swp1Context();
            (from a in dbcontext.Accountsses where a.AccountId.Equals(accID) select a).ToList().ForEach(a => 
            { a.Name = name; a.Birthday = DOB; a.Email = email; a.Phone = phone; a.Nation = nation; a.Gender = gender; a.Identitycard = identitycard; });
            dbcontext.SaveChanges();
        }

        public static ArrayList SelectOrdersByMonth(string OwnerID)
        {
            ArrayList countList = new ArrayList();
            var context = new Swp1Context();
            int orderNumber = 0;
            for (int month = 1; month <= 12; month++)
            {
                var orders = (from o in context.Orders
                              where o.CheckOut.Year == DateTime.Now.Year && o.CheckOut.Month == month && o.CheckOut.Day == DateTime.Now.Day && o.CheckOut.Hour + 14 <= DateTime.Now.Hour
                              || o.CheckOut.Year == DateTime.Now.Year && o.CheckOut.Month == month && o.CheckOut.Day < DateTime.Now.Day
                              || o.CheckOut.Month ==month && o.CheckOut.Year == DateTime.Now.Year && o.CheckOut < DateTime.Now
                              join r in context.Rooms on o.RoomId equals r.RoomId
                              join h in context.Hotels on r.HotelId equals h.HotelId
                              where h.AccountId == OwnerID
                              select new { month = o.CheckIn.Month }).Count();
                countList.Add(orders);
            }
            return countList;
        }

        public static int DateDiff (string OwnerID)
        {
            var count = 0;
            int devide = 0;
            var context = new Swp1Context();

            var select = (from o in context.Orders
                     where o.CheckOut.Year == DateTime.Now.Year && o.CheckOut <= DateTime.Now
                          join r in context.Rooms on o.RoomId equals r.RoomId
                     join h in context.Hotels on r.HotelId equals h.HotelId
                     where h.AccountId == OwnerID
                     let dateDiff = EF.Functions.DateDiffDay(o.CheckIn, o.CheckOut)
                     select new {diff = dateDiff}).ToList();
            foreach(var item in select)
            {
                devide++;
                count += item.diff;
            }
            
            return count / devide;
        }

        public static SqlMoney IncomeForDashboard(string OwnerID, int month)
        {
            var context = new Swp1Context();
            SqlMoney money = 0;
            int day = DateTime.Now.Day;

            var monthIncome = from o in context.Orders
                              where o.CheckOut.Year == DateTime.Now.Year && month == o.CheckOut.Month && month < DateTime.Now.Month
                              || o.CheckOut.Year == DateTime.Now.Year&& o.CheckOut.Month == month && month == DateTime.Now.Month && o.CheckOut.Day <= DateTime.Now.Day
                              join r in context.Rooms on o.RoomId equals r.RoomId
                              join h in context.Hotels on r.HotelId equals h.HotelId
                              where h.AccountId == OwnerID
                              select new { monthTotal = o.TotalPrice };
            foreach (var item in monthIncome) money += item.monthTotal;

            return money;
        }

        //Admin
        public static List<Accountss> GetAllUserAccount()
        {
            var context = new Swp1Context();
            var account = context.Accountsses.Where(a => a.RoleId != "R001").ToList();
            return account;
        }
        public static void RemoveUserAccount(string id)
        {
            var context = new Swp1Context();
            var account = context.Accountsses.Where(a => a.AccountId == id).FirstOrDefault();
            context.Accountsses.Remove(account);
            context.SaveChanges();
        }
    }
}