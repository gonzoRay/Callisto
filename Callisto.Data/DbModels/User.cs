using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Data.DbModels
{
    public class User
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //Foreign keys
        

        //Navigation properties
        public virtual ICollection<Role> Roles { get; set; }
    }
}
