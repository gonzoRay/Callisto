using System;

namespace Callisto.Domain.Entities
{
    public class ReleaseVersion
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string Build { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Narrative { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
}
