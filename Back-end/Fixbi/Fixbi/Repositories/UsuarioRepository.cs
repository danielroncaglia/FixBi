using Fixbi.Interfaces;
using Fixbi.ViewModels;
using Fixbi.Domains;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Fixbi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (FixBiContext ctx = new FixBiContext())
            {
                return ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.EmailUsuario == login.Email && x.SenhaUsuario == login.Senha);
            }
        }
    }
}
        