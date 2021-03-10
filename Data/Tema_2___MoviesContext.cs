using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tema_2___Movies.Models;

namespace Tema_2___Movies.Data
{
    public class Tema_2___MoviesContext : DbContext
    {
        public Tema_2___MoviesContext (DbContextOptions<Tema_2___MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Tema_2___Movies.Models.MovieClass> MovieClass { get; set; }
    }
}
