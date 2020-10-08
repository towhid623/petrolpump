using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name = projectconnectionstring")
        {

        }
        public virtual DbSet<ConfigMaster> ConfigMasters { get; set; }
        public virtual DbSet<ConfigValueSet> ConfigValueSets { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Thana> Thanas { get; set; }
        public virtual DbSet<Pump> Pumps { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<PumpItem> PumpItems { get; set; }
    }
}
