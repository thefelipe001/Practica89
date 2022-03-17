using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Models
{
    public  class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {


        }
        public DbSet<Libros>Libros { get; set; }
        public DbSet<Editoriales>Editoriales { get; set; }
    }
}
