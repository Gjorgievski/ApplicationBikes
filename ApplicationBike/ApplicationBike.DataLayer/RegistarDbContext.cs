using ApplicationBike.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBike.DataLayer
{
    public class RegistarDbContext : DbContext
    {
        public RegistarDbContext():base("RegisterDb")
        {
        }

        public DbSet<Bike> Bikes { get; set; }
    }
}
