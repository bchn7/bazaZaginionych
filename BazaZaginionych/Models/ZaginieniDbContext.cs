using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaZaginionych.Models
{
    public class ZaginieniDbContext:DbContext
    {
        public ZaginieniDbContext(DbContextOptions<ZaginieniDbContext> options):base(options)
        {
            
        }

        public DbSet<ZaginieniModel> Zaginieni { get; set; }
    }
}
