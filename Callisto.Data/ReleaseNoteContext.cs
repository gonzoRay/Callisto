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
        public DbSet<Link> Links { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<NoteText> NoteTexts { get; set; }
        public DbSet<RequiredType> RequiredTypes { get; set; }
        public DbSet<ReleaseVersion> Versions { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
