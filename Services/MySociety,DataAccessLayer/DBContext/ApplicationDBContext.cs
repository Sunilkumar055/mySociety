using Microsoft.EntityFrameworkCore;
using MySociety.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySociety_DataAccessLayer.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<UserModel> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users");
        }
    }
}
