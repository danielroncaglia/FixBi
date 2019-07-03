using System;
using System.Collections.Generic;

namespace Fixbi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Ciclistas = new HashSet<Ciclistas>();
            Mecanicos = new HashSet<Mecanicos>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }

        public virtual TipoUsuarios IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Ciclistas> Ciclistas { get; set; }
        public virtual ICollection<Mecanicos> Mecanicos { get; set; }
    }
}
