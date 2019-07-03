using System;
using System.Collections.Generic;

namespace Fixbi.Domains
{
    public partial class Ciclistas
    {
        public Ciclistas()
        {
            Atendimentos = new HashSet<Atendimentos>();
        }

        public int IdCiclista { get; set; }
        public int? IdUsuario { get; set; }
        public string NomeCiclista { get; set; }
        public string TelefoneCiclista { get; set; }
        public string InformacoesCiclista { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Atendimentos> Atendimentos { get; set; }
    }
}
