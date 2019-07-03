using System;
using System.Collections.Generic;

namespace Fixbi.Domains
{
    public partial class TipoUsuarios
    {
        public TipoUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
