using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialAutomation.Models
{
    public class ConfigModel
    {
        public string Dominio { get; set; } = "";
        public string Usuario { get; set; } = "";
        public string Senha { get; set; } = "";
        public bool LembrarSenha { get; set; }
    }
}
