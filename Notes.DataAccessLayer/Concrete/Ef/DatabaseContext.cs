using Notes.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DataAccessLayer.Concrete
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Liked> Likes { get; set; }
    }
}
