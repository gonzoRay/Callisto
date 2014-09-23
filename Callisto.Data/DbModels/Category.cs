using System.Collections;
using System.Collections.Generic;

namespace Callisto.Data.DbModels
{
    public class Category
    {
        public Category()
        {
            this.Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
