using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDTPAdminUI.Models
{
    public class ParticipantViewModel
    {
        public string Name { get; set; }
        public string CurrentNetDebitCap { get; set; }
        public string ActualNetDebitCap { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
