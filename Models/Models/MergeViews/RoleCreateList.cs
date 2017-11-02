using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class RoleCreateList
    {
            public IEnumerable<Role> ExistingRoles { get; set; }
            public Role Role { get; set; }        
    }
}