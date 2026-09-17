using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialAutomation.Models;

namespace InitialAutomation.Models
{
    public class DomainInfo
    {
        public string Hostname { get; set; } = "";
        public string Domain { get; set; } = "";
        public bool PartOfDomain { get; set; }
    }
}