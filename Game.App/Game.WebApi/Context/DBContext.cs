using Game.WebApi.Models;
using System.Data.Entity;

namespace Game.WebApi.Context
{
    public class DBContext : DbContext
    {

        public DBContext()
             : base("AuthContext")
        {}

        public DbSet<RegisterUser> RegisterUser { get; set; }
    }
}