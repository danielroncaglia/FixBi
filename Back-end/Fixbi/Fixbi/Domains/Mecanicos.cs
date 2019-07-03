using System;
using System.Collections.Generic;

namespace Fixbi.Domains
{
    public partial class Mecanicos
    {
        public Mecanicos()
        {
            Atendimentos = new HashSet<Atendimentos>();
        }

        public int IdMecanico { get; set; }
        public int? IdUsuario { get; set; }
        public string NomeMecanico { get; set; }
        public string TelefoneMecanico { get; set; }
        public string InformacoesMecanico { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Atendimentos> Atendimentos { get; set; }
    }
}
