using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions optons) : base(optons) { }
        public DbSet<Product> Products { get; set; }

    }
}
