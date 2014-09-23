using System.Collections.Generic;

namespace Callisto.Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public int RequiredId { get; set; }
        public bool IsActive { get; set; }
        public bool IsEnhancement { get; set; }
        public bool IsInitial { get; set; }

        //Foreign keys
        //public int VersionId { get; set; }
        public int ConfigurationTypeId { get; set; }
        //public int LinkId { get; set; }
        public int NoteTextId { get; set; }
        public int NoteTypeId { get; set; }
        public int RequiredTypeId { get; set; }
            
        //Navigation properties
        //public ICollection<ReleaseVersion> ReleaseVersion { get; set; }
        //public ICollection<Link> Link { get; set; }
        //public ConfigurationType ConfigurationType { get; set; }
        //public NoteText NoteText { get; set; }
        //public RequiredType RequiredType { get; set; }
    }
}
