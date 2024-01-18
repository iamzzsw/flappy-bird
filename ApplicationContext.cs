using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Flappy_Bird
{
    class ApplicationContext : DbContext
    {
        public DbSet<Result> Results { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
