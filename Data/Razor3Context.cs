using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razor3.Model;

namespace Razor3.Data
{
    public class Razor3Context : DbContext
    {
        public Razor3Context (DbContextOptions<Razor3Context> options)
            : base(options)
        {
        }

        public DbSet<Razor3.Model.Item> Item { get; set; } = default!;
        public DbSet<Razor3.Model.Element> Element { get; set; } = default!;
    }
}
