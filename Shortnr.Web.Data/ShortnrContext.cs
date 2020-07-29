using Shortnr.Web.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Shortnr.Web.Data
{
    public class ShortnrContext : DbContext
    {


       
        public ShortnrContext() : base("Shortnr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShortnrContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stat>()
                .HasRequired(s => s.ShortUrl)
                .WithMany(u => u.Stats)
                .Map(m => m.MapKey("shortUrl_id"));
        }

        public virtual DbSet<ShortUrl> ShortUrls {get; set;}
        public virtual DbSet<Stat> Stats { get; set; }


       
    }
}
