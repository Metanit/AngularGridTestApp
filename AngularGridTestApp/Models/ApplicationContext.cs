using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AngularGridTestApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            db.Users.AddRange(new List<User>
            {
                new User{ Name="Tom", Age=22},
                new User{ Name="Bob", Age=26},
                new User{ Name="Sam", Age=29},
            });

            base.Seed(db);
        }
    }
}