using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Role
    {
        public Roles role {  get; set; }

        public enum Roles
        {
            assesse, 
            assessor, 
            admin
        }
    }
}
