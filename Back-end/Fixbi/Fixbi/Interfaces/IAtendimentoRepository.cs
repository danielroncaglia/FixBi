using Fixbi.Domains;
using System.Collections.Generic;

namespace Fixbi.Interfaces
{
    public interface IAtendimentoRepository
    {
        void cadastrarAtendimento(Atendimentos atendimento);

        List<Atendimentos> todosAtendimentos();
    }
}