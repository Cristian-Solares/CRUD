using Microsoft.EntityFrameworkCore;
using proyecto_udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_udemy.Data
{
    public class ApplicationDbContext : DbContext //hereda de DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<usuario> usuario { get; set; }//se configura el primer modelo
        //o tablas
            //<modelo usuario>

    }
}
