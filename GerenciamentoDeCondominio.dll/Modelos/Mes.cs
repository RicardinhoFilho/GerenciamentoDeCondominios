using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeCondominios.BLL.Modelos
{
    public class Mes
    {
        public int MesId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Aluguel> Algueis { get; set; }
        public virtual ICollection<HistoricoRecursos> HistoricoRecursos { get; set; }
    }
}
