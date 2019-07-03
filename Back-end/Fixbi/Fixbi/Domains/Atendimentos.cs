using System;
using System.Collections.Generic;

namespace Fixbi.Domains
{
    public partial class Atendimentos
    {
        public int IdAtendimento { get; set; }
        public int? IdCiclista { get; set; }
        public int? IdMecanico { get; set; }
        public DateTime DataHorario { get; set; }
        public string DescricaoAtendimento { get; set; }
        public string SituacaoAtendimento { get; set; }

        public virtual Ciclistas IdCiclistaNavigation { get; set; }
        public virtual Mecanicos IdMecanicoNavigation { get; set; }
    }
}
