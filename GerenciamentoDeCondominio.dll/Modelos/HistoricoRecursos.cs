using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeCondominios.BLL.Modelos
{
    public class HistoricoRecursos
    {
        public int HistoricoRecursosId { get; set; }
        public decimal Valor { get; set; }
        public Tipo Tipo { get; set; }
        public int Dia { get; set; }
        public int MesId { get; set; }
        public virtual Mes Mes { get; set; }
        public int Ano { get; set; }
    }

    public enum Tipo
    {
        Entrada,
        Saida
    }
}
