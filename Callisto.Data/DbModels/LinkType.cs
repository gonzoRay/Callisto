using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Data.DbModels
{
    public class LinkType
    {
        public int Id { get; set; }
        public string LinkTypeName { get; set; }
        public string LinkDescription { get; set; }
        public string LinkTemplateUrl { get; set; }
    }
}
