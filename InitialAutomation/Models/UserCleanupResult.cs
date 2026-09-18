using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialAutomation.Models
{
    public class UserCleanupResult
    {
        public int TotalUsuarios { get; set; }

        public List<string> UsuariosAfetados { get; set; } = [];


    }
}