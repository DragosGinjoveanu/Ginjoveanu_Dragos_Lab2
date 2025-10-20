using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ginjoveanu_Dragos_Lab2.Models;

namespace Ginjoveanu_Dragos_Lab2.Data
{
    public class Ginjoveanu_Dragos_Lab2Context : DbContext
    {
        public Ginjoveanu_Dragos_Lab2Context (DbContextOptions<Ginjoveanu_Dragos_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Ginjoveanu_Dragos_Lab2.Models.Book> Book { get; set; } = default!;
        
        public DbSet<Ginjoveanu_Dragos_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        
        public DbSet<Ginjoveanu_Dragos_Lab2.Models.Author> Author { get; set; } = default!;
        
        public DbSet<Ginjoveanu_Dragos_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
