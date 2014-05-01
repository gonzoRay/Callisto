using System;

namespace Callisto.Data.DbModels
{
    public class ReleaseVersion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Build { get; set; }
        public bool IsInitial { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
}
