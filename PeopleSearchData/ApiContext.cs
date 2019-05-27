using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleSearchData
{
    public class ApiContext : DbContext
    {
        public DbSet<PeopleSearchData.Models.Value> Values { get; set; }
        public DbSet<PeopleSearchData.Models.Person> People { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Person>()
                .HasIndex(b => b.FirstName);
            modelBuilder.Entity<Models.Person>()
                .HasIndex(b => b.LastName);
        }
    }
}
