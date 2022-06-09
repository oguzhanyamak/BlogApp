using DataAccessLayer.FluentApiConfiguration;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;database=BlogAppDB;Integrated Security=True;");
            //
            
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentApi_AuthorConf());
            modelBuilder.ApplyConfiguration(new FluentApi_BlogConf());
            modelBuilder.ApplyConfiguration(new FluentApi_CategoryConf());
            modelBuilder.ApplyConfiguration(new FluentApi_CommentConf());
            modelBuilder.ApplyConfiguration(new FluentApi_ContactConf());
        }
    }
}