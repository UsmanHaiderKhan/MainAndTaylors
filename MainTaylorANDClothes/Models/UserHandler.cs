using System.Linq;

namespace MainTaylorANDClothes.Models
{
    public class UserHandler
    {
        public User GetUser(string Loginid, string Password)
        {
            TaylorContext db = new TaylorContext();
            using (db)
            {
                return (from v in db.Users where v.LoginId.Equals(Loginid) && v.Password.Equals(Password) select v).FirstOrDefault();
            }
        }
    }
}
