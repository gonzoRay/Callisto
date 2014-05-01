using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Callisto.Data.DbModels;

namespace Callisto.Data
{
    [System.Runtime.InteropServices.GuidAttribute("F924B47F-9C47-45F4-84A2-2F463CBD4283")]
    public class ReleaseNoteInitializer
        : System.Data.Entity.DropCreateDatabaseIfModelChanges<ReleaseNoteContext>
    {
        protected override void Seed(ReleaseNoteContext context)
        {
            var releases = new List<ReleaseVersion>
            {
                new ReleaseVersion {Name = "2013-R1", Build = "2013.0131.0339", IsActive = false, IsInitial = true, ReleaseDate = new DateTime(2013, 1, 31)},
                new ReleaseVersion {Name = "2013-R2", Build = "2013.0331.5922", IsActive = false, IsInitial = true, ReleaseDate = new DateTime(2013, 3, 31)},
                new ReleaseVersion {Name = "2013-R3", Build = "2013.0531.1223", IsActive = true, IsInitial = true, ReleaseDate = new DateTime(2013, 5, 31)},
                new ReleaseVersion {Name = "2013-R4", Build = "2013.0731.0654", IsActive = true, IsInitial = true, ReleaseDate = new DateTime(2013, 7, 31)},
                new ReleaseVersion {Name = "2013-R5", Build = "2013.0930.0033", IsActive = true, IsInitial = true, ReleaseDate = new DateTime(2013, 9, 30)},
                new ReleaseVersion {Name = "2013-R6", Build = "2013.1031.0876", IsActive = true, IsInitial = true, ReleaseDate = new DateTime(2013, 10, 31)},
                new ReleaseVersion {Name = "2014-R1", Build = "2014.1229.0234", IsActive = true, IsInitial = true, ReleaseDate = new DateTime(2013, 12, 29)},
            };

            releases.ForEach(r => context.Versions.Add(r));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category {CategoryName = "Database Changes"},
                new Category {CategoryName = "Deployment"},
                new Category {CategoryName = "Exports"},
                new Category {CategoryName = "Forms"},
                new Category {CategoryName = "Messaging"},
                new Category {CategoryName = "Metadata"},
                new Category {CategoryName = "Other"},
                new Category {CategoryName = "Other Standards"},
                new Category {CategoryName = "Salary/Payroll Posting"},
                new Category {CategoryName = "Standard Screens"},
                new Category {CategoryName = "STAR"},
                //TODO: Add other categories to Seed data
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var configurationTypes = new List<ConfigurationType>
            {
                new ConfigurationType {ConfigurationTypeName = "Base"},
                new ConfigurationType {ConfigurationTypeName = "Standard"},
                new ConfigurationType {ConfigurationTypeName = "N/A"}
            };

            configurationTypes.ForEach(c => context.ConfigurationTypes.Add(c));
            context.SaveChanges();

            var modules = new List<Module>
            {
                new Module {ModuleName = "Billing"},
                new Module {ModuleName = "Common"},
                new Module {ModuleName = "Defined Benefit"},
                new Module {ModuleName = "Health & Welfare"},
            };

            modules.ForEach(m => context.Modules.Add(m));
            context.SaveChanges();

            var requiredTypes = new List<RequiredType>
            {
                new RequiredType {RequiredOptionName = "Required"},
                new RequiredType {RequiredOptionName = "Optional"},
                new RequiredType {RequiredOptionName ="Required - Action Needed"}
            };

            requiredTypes.ForEach(r => context.RequiredTypes.Add(r));
            context.SaveChanges();

            //Create an actual release note. 


            var notes = new List<Note>
            {
                new Note
                {
                    IsActive = true,
                    IsEnhancement = false,
                    Categories = (from c in categories
                                 where c.CategoryName.Equals("Forms") || c.CategoryName.Equals("Messaging")
                                     select c).ToList(),
                    Modules = (from m in modules
                              where m.ModuleName.Equals("Common") || m.ModuleName.Equals("Defined Benefit")
                              select m).ToList(),
                    ReleaseVersion = (from rv in releases
                                          where rv.Name == "2014-R1"
                                          select rv).Single(),
                    ConfigurationType = (from ct in configurationTypes
                                             where ct.ConfigurationTypeName == "Standard"
                                             select ct).Single(),
                    Link = new Link{ LinkType = 1, LinkDetail = "http://www.google.com"},
                    NoteText = new NoteText
                    {
                        Summary = "Fix for Bug 1234", 
                        Detail = "Test release note #1 - Fix detail for bug 1234", 
                        Client = "Acme",
                    },
                    RequiredType = (from rt in requiredTypes 
                                        where rt.RequiredOptionName == "Required"
                                        select rt).Single(),
                },

            };

            notes.ForEach(n => context.Notes.Add(n));
            context.SaveChanges();
        }
    }
}
