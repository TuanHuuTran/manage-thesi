using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace ManageThesis_Project.Modal
{
    public class MyDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Thesis> Thesess { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Point> Points { get; set; }
    }
}
