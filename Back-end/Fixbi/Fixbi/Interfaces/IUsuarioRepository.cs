using Fixbi.Domains;
using Fixbi.ViewModels;

namespace Fixbi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);
    }
}