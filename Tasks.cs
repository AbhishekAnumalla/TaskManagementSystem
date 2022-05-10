using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SemiApprenticeship.Entities
{
    public class Tasks
    {
        public int taskId { get; set; }
        public string description { get; set; }
        public DateTime dueDate { get; set; }
        public string requestedBy { get; set; }
        public DateTime requestedOn { get; set; }
/*        public string date = requestedOn.ToString("dd/MM/yyyy");*/
        public string remarks { get; set; }
        public string action { get; set; }
    }
}
