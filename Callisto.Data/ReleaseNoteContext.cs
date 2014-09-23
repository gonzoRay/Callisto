using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Callisto.Data.DbModels;

namespace Callisto.Data
{
    public class ReleaseNoteContext : DbContext
    {
        static ReleaseNoteContext()
        {
            Database.SetInitializer<ReleaseNoteContext>(new ReleaseNoteInitializer());
        }

        public ReleaseNoteContext()
        {
            
        }

        public ReleaseNoteContext(string connectionName) : base(connectionName)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ConfigurationType> ConfigurationTypes { get; set; }
        public DbSet<LinkType> LinkTypes { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<NoteText> NoteTexts { get; set; }
        public DbSet<RequiredType> RequiredTypes { get; set; }
        public DbSet<ReleaseVersion> Versions { get; set; }
        public DbSet<NoteType> NoteTypes { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Create Many to Many rel. between Notes <-> Category
            modelBuilder.Entity<Note>()
                .HasMany(n => n.Categories)
                .WithMany(c => c.Notes)
                .Map(c =>
                {
                    c.ToTable("CategoryLookup");
                });

            //Create Many to Many rel. between Notes <-> ReleaseVersion
            modelBuilder.Entity<Note>()
                .HasMany(n => n.ReleaseVersions)
                .WithMany(rv => rv.Notes)
                .Map(rv =>
                {
                    rv.ToTable("ReleaseVersionLookup");
                });
            
            //Create Many to Many rel. between Notes <-> Link
            modelBuilder.Entity<Note>()
                .HasMany(n => n.Links)
                .WithMany(ll => ll.Notes)
                .Map(ll =>
                {
                    ll.ToTable("LinkLookup");
                });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
