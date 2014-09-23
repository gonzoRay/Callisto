using System.ComponentModel.DataAnnotations;

namespace Callisto.Data.DbModels
{
    public class ConfigurationType
    {
        [Key]
        public int Id { get; set; }
        public string ConfigurationTypeName { get; set; }
    }
}
