using System;
using System.Collections;
using System.Collections.Generic;

namespace Callisto.Data.DbModels
{
    public class ReleaseVersion
    {
        public ReleaseVersion()
        {
            this.Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string Version { get; set; }
        public string Build { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Narrative { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
