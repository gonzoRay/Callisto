using System.Collections.Generic;

namespace Callisto.Data.DbModels
{
    public class Note
    {
        public int Id { get; set; }
        public int RequiredId { get; set; }
        public bool IsActive { get; set; }
        public bool IsEnhancement { get; set; }

        //Foreign keys
        public int VersionId { get; set; }
        public int ConfigurationTypeId { get; set; }
        public int LinkId { get; set; }
        public int NoteTextId { get; set; }
        public int RequiredTypeId { get; set; }
            
        //Navigation properties
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ReleaseVersion ReleaseVersion { get; set; }
        public virtual ConfigurationType ConfigurationType { get; set; }
        public virtual Link Link { get; set; }
        public virtual NoteText NoteText { get; set; }
        public virtual RequiredType RequiredType { get; set; }
    }
}
