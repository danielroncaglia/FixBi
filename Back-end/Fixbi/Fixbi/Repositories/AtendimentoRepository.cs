using Fixbi.Domains;
using Fixbi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Fixbi.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        public void cadastrarAtendimento(Atendimentos atendimento)
        {
            using (FixBiContext ctx = new FixBiContext())
            {
                ctx.Atendimentos.Add(atendimento);
                ctx.SaveChanges();
            }
        }
        public List<Atendimentos> todosAtendimentos()
        {
            using (FixBiContext ctx = new FixBiContext())
            {
                return ctx.Atendimentos.ToList();
            }
        }
    }
}