using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Person> Person => Set<Person>();
        public DbSet<Address> Address => Set<Address>();
        public DbSet<UserProfile> UserProfile => Set<UserProfile>();
    }
}