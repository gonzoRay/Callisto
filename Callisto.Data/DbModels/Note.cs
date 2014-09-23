using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Callisto.Data.DbModels
{
    public class Note
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsInitial { get; set; }
        public bool IsActionRequired { get; set; }
        public string RequiredAction { get; set; }

        //Foreign keys
        public int NoteTextId { get; set; } 
        public int ModuleId { get; set; }
        public int ConfigurationTypeId { get; set; }
        public int RequiredTypeId { get; set; }
        public int NoteTypeId { get; set; }
            
        //Navigation properties
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ReleaseVersion> ReleaseVersions { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual NoteText NoteText { get; set; }
        
        [Required]
        public virtual Module Module { get; set; }
        [Required]
        public virtual ConfigurationType ConfigurationType { get; set; }
        [Required]
        public virtual RequiredType RequiredType { get; set; }
        [Required]
        public virtual NoteType NoteType { get; set; }
    }
}
