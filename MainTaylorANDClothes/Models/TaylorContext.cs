using System.Data.Entity;

namespace MainTaylorANDClothes.Models
{
    public class TaylorContext : DbContext
    {
        public TaylorContext() : base("name=constr")
        {

        }

        public DbSet<Taylor> Taylors { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
