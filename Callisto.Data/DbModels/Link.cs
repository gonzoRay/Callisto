using System.Collections;
using System.Collections.Generic;

namespace Callisto.Data.DbModels
{
    public class Link
    {
        public Link()
        {
            this.Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public LinkType LinkType { get; set; }
        public string TrackingId { get; set; }
        
        public virtual ICollection<Note> Notes { get; set; }
    }
}
