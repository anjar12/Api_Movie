using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.DB
{
    public class MovieDB : DbContext
    {
        public MovieDB(DbContextOptions<MovieDB> options) : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
        }
    }
}
    