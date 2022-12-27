using Microsoft.EntityFrameworkCore;
using MySociety.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySociety.DAL.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
    }
}
