using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Cryptography;
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
            //Insert dummy release versions
            var releases = new List<ReleaseVersion>
            {
                new ReleaseVersion {Version = "2013-R1", Build = "2013.0131.0339", Narrative = "This is the release with the cool stuff.", IsActive = false, ReleaseDate = new DateTime(2013, 1, 31)},
                new ReleaseVersion {Version = "2013-R2", Build = "2013.0331.5922", Narrative = "Has extra configuration stuff.", IsActive = false, ReleaseDate = new DateTime(2013, 3, 31)},
                new ReleaseVersion {Version = "2013-R3", Build = "2013.0531.1223", Narrative = "All about XYZ feature.", IsActive = true, ReleaseDate = new DateTime(2013, 5, 31)},
                new ReleaseVersion {Version = "2013-R4", Build = "2013.0731.0654", Narrative = "Has mostly bug fixes related to ABC feature.", IsActive = true, ReleaseDate = new DateTime(2013, 7, 31)},
                new ReleaseVersion {Version = "2013-R5", Build = "2013.0930.0033", Narrative = "All about Acme.", IsActive = true, ReleaseDate = new DateTime(2013, 9, 30)},
                new ReleaseVersion {Version = "2013-R6", Build = "2013.1031.0876", Narrative = "HIPAA compliance release.", IsActive = true, ReleaseDate = new DateTime(2013, 10, 31)},
                new ReleaseVersion {Version = "2014-R1", Build = "2014.1229.0234", Narrative = "Usability enhancements.", IsActive = true, ReleaseDate = new DateTime(2013, 12, 29)},
            };

            releases.ForEach(r => context.Versions.Add(r));
            context.SaveChanges();

            //Insert default categories
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

            //Insert default config types
            var configurationTypes = new List<ConfigurationType>
            {
                new ConfigurationType {ConfigurationTypeName = "Base"},
                new ConfigurationType {ConfigurationTypeName = "Standard"},
                new ConfigurationType {ConfigurationTypeName = "N/A"}
            };

            configurationTypes.ForEach(c => context.ConfigurationTypes.Add(c));
            context.SaveChanges();

            //Insert default modules
            var modules = new List<Module>
            {
                new Module {ModuleName = "Billing"},
                new Module {ModuleName = "Common"},
                new Module {ModuleName = "Defined Benefit"},
                new Module {ModuleName = "Health & Welfare"},
            };

            modules.ForEach(m => context.Modules.Add(m));
            context.SaveChanges();

            //Insert default required types
            var requiredTypes = new List<RequiredType>
            {
                new RequiredType {RequiredOptionName = "Required"},
                new RequiredType {RequiredOptionName = "Optional"},
            };

            requiredTypes.ForEach(r => context.RequiredTypes.Add(r));
            context.SaveChanges();

            //Insert default note types
            var noteTypes = new List<NoteType>
            {
                new NoteType { NoteTypeName = "Enhancement" },
                new NoteType { NoteTypeName = "Bug Fix" },
                new NoteType { NoteTypeName = "Manage Data" },
                new NoteType { NoteTypeName = "Other" },
            };

            noteTypes.ForEach(n => context.NoteTypes.Add(n));
            context.SaveChanges();

            //Insert default link types
            var linkTypes = new List<LinkType>
            {
                new LinkType { LinkTypeName = "CustomerWise", LinkDescription = "CustomerWise tracking URL" , LinkTemplateUrl = "http://customerwise.msi.com/id={0}"},
                new LinkType { LinkTypeName = "OnTime", LinkDescription = "OnTime tracking URL", LinkTemplateUrl = "http://ontime.msi.com/id={0}" },
                new LinkType { LinkTypeName = "Other", LinkDescription = "Other tracking URL", LinkTemplateUrl = "{0}" },
            };

            linkTypes.ForEach(lt => context.LinkTypes.Add(lt));
            context.SaveChanges();

            //Create some actual release notes. 
            var notes = new List<Note>
            {
                //TEST NOTE FOR BUG FIX - Multiple Releases
                createNote(
                    /* seed data structures */
                    noteTypes, categories, modules, releases, configurationTypes, requiredTypes, linkTypes,
                    /* seed data specifiers */
                    noteType: "Bug Fix",
                    requiredType: "Required",
                    releaseVersions: "2014-R1,2013-R6",
                    categoryNames: "Database Changes,Exports",
                    configurationType: "Standard",
                    moduleName: "Defined Benefit",
                    noteText: new NoteText
                    {
                        Client = "Acme",
                        Summary = "Fix for Bug 1235",
                        Detail = "Test release note #1 - Fix detail for bug 1235",
                    },
                    trackingLinks: new List<Link>
                    {
                        createLink(linkTypes, "OT-1235", "OnTime"),
                        createLink(linkTypes, "CW-98766", "CustomerWise"),
                    }),

                //TEST NOTE FOR ENHANCEMENT - Single Release
                createNote(
                    /* seed data structures */
                    noteTypes, categories, modules, releases, configurationTypes, requiredTypes, linkTypes,
                    /* seed data specifiers */
                    noteType: "Enhancement",
                    requiredType: "Optional",
                    releaseVersions: "2014-R1",
                    categoryNames: "Database Changes,Exports, Deployments",
                    configurationType: "Standard",
                    moduleName: "Common",
                    noteText: new NoteText
                    {
                        Client = "Acme",
                        Summary = "Enhancing the UI",
                        Detail = "Test release note #2 - UI enhancement for customer widget",
                    },
                    trackingLinks: new List<Link>
                    {
                        createLink(linkTypes, "CW-34533", "CustomerWise"),
                        createLink(linkTypes, "http://sharepoint.msi.com/?doc=file1.docx&sharepointsucks=true", "Other"),   
                    }),

                //TEST NOTE FOR ENHANCEMENT - Multiple Release
                createNote(
                    /* seed data structures */
                    noteTypes, categories, modules, releases, configurationTypes, requiredTypes, linkTypes,
                    /* seed data specifiers */
                    noteType: "Enhancement",
                    requiredType: "Required",
                    releaseVersions: "2014-R1, 2013-R6, 2013-R5",
                    categoryNames: "Metadata",
                    configurationType: "Base",
                    moduleName: "Billing",
                    noteText: new NoteText
                    {
                        Client = "Canada",
                        Summary = "Added new Billing IDs",
                        Detail = "Test release note #3 - Added extra billing IDs for Canada",
                    },
                    trackingLinks: new List<Link>
                    {
                        createLink(linkTypes, "OT-3392", "OnTime"),
                        createLink(linkTypes, "CW-85288", "CustomerWise"),
                        createLink(linkTypes, "http://sphere.msi.com/?idblah=somethingsomethingdarkside", "Other"),   
                    }),

                //TEST NOTE FOR BUG FIX - Single Release (not yet active)
                createNote(
                    /* seed data structures */
                    noteTypes, categories, modules, releases, configurationTypes, requiredTypes, linkTypes,
                    /* seed data specifiers */
                    noteType: "Bug Fix",
                    requiredType: "Required",
                    releaseVersions: "2014-R1",
                    categoryNames: "STAR",
                    configurationType: "N/A",
                    moduleName: "Defined Benefit",
                    noteText: new NoteText
                    {
                        Client = "HRI",
                        Summary = "Fix for Bug 3456",
                        Detail = "Test release note #4 - STAR bugfix in DB - Fix detail for bug 3456",
                    },
                    trackingLinks: new List<Link>
                    {
                        createLink(linkTypes, "CW-36521", "CustomerWise"),
                        createLink(linkTypes, "http://sphere.msi.com/?idblah=somethingsomethingdarkside", "Other"),   
                    },
                    isActive: false),

            };
            notes.ForEach(n => context.Notes.Add(n));
            context.SaveChanges();
        }

        private Note createNote(List<NoteType> noteTypes,
                                List<Category> categories,
                                List<Module> modules,
                                List<ReleaseVersion> releases,
                                List<ConfigurationType> configurationTypes,
                                List<RequiredType> requiredTypes,
                                List<LinkType> linkTypes,
                                string noteType,
                                string requiredType,
                                string releaseVersions,
                                string categoryNames,
                                string configurationType,
                                string moduleName,
                                NoteText noteText,
                                List<Link> trackingLinks,
                                bool isActive = true,
                                bool isInitial = true,
                                bool isActionRequired = false,
                                string requiredAction = null)
        {
            return new Note
            {
                IsActive = isActive,
                IsInitial = isInitial,
                IsActionRequired = isActionRequired,
                RequiredAction = requiredAction,
                ModuleId = (modules.Where(m => moduleName.Contains(m.ModuleName)).Select(m => m.Id)).Single(),
                ConfigurationTypeId = (configurationTypes.Where(ct => ct.ConfigurationTypeName == configurationType).Select(ct => ct.Id)).Single(),
                NoteTypeId = (noteTypes.Where(nt => nt.NoteTypeName.Equals(noteType)).Select(nt => nt.Id)).Single(),
                RequiredTypeId = (from rt in requiredTypes
                                  where rt.RequiredOptionName == requiredType
                                  select rt.Id).Single(),
                Categories = (categories.Where(c => categoryNames.Contains(c.CategoryName))).ToList(),
                ReleaseVersions = (releases.Where(rv => rv.Version == releaseVersions)).ToList(),
                NoteText = noteText,
                Links = trackingLinks,
            };
        }

        private Link createLink(List<LinkType> linkTypes, string trackingId, string linkType)
        {
            var specifiedLinkType = (linkTypes.Where(lt => lt.LinkTypeName.Equals(linkType))).Single();

            return new Link
            {
                LinkType = specifiedLinkType,
                TrackingId = trackingId,
            };
        }
    }
}
