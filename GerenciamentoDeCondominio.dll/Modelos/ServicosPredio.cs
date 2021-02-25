using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeCondominios.BLL.Modelos
{
    public class ServicosPredio
    {
        public int ServicosPredioId { get; set; }
        public int ServicoId { get; set; }
        public virtual Servico Servico { get; set; }
        public DateTime DataExecucao { get; set; }
    }
}