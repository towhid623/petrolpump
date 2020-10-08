namespace Repository.Migrations
{
    using Entities.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.DatabaseContext.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Repository.DatabaseContext.DatabaseContext context)
        {
          
            context.ConfigMasters.AddOrUpdate(a => a.ConfigShortName,
            new ConfigMaster { ConfigName = "Material Icon", ConfigShortName = "MIcon" });

            //context.ConfigValueSets.AddOrUpdate(a => a.ConfigShortValue,
            //new ConfigValueSet { ConfigValue = "User in Box", ConfigShortValue = "UserBox", ConfigValueSetId = context.ConfigMasters.FirstOrDefault(f => f.ConfigShortName == "MIcon").ConfigId, Attribute1 = "account_box" },
            //new ConfigValueSet { ConfigValue = "User in Circle", ConfigShortValue = "UserCircle", ConfigValueSetId = context.ConfigMasters.FirstOrDefault(f => f.ConfigShortName == "MIcon").ConfigId, Attribute1 = "account_circle" },
            //new ConfigValueSet { ConfigValue = "Security", ConfigShortValue = "Security", ConfigValueSetId = context.ConfigMasters.FirstOrDefault(f => f.ConfigShortName == "MIcon").ConfigId, Attribute1 = "security" },
            //new ConfigValueSet { ConfigValue = "Users Solid", ConfigShortValue = "Solid Users", ConfigValueSetId = context.ConfigMasters.FirstOrDefault(f => f.ConfigShortName == "MIcon").ConfigId, Attribute1 = "group" }
            //);
        }
    }
}
