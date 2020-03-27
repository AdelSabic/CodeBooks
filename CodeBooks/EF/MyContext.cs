using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeBooks.Models;

namespace CodeBooks.EF
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Codebooks>()
                .HasIndex(c => c.Code)
                .IsUnique();
        }
        public DbSet<CodeBooks.Models.Codebooks> Codebooks { get; set; }
        public DbSet<CodeBooks.Models.Codes.Codes> Codes { get; set; }
    }
}
