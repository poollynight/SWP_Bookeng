using ServiceStack;

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
        public static void SinupAccount(string username, string email, string password, string role)
        {
            string accID;
            using var dbContext = new Swp1Context();
            if (role.Equals("R002")) accID = OwnerAccountIdGenerate();
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
            return account.AccountId;
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
        // public void ReadHotel(){

        // }
        //public async Task OnGetAsync(string searchString)
        //{
        //    using var dbcontext = new Swp1Context();
        //    //int totalHotel = dbcontext.Hotels.Where
        //}
    }
}