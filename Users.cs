using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemiApprenticeship.Entities
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string LoginName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string Remarks { get; set; }
        /*public string Status { get; set; }*/
    }
}
