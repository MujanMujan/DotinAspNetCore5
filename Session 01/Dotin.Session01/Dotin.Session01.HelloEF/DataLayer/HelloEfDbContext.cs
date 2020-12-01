using Dotin.Session01.HelloEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotin.Session01.HelloEF.DataLayer
{
    public class HelloEfDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\Sql2019; Database=HelloEfDb;Integrated Security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Course> Courses{ get; set; }

        
    }
}
