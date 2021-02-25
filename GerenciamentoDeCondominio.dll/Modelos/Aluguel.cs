using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeCondominios.BLL.Modelos
{
    public class Aluguel
    {
        public int AluguelId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Valor Inválido")]
        public decimal Valor { get; set; }

        [Display(Name = "Mês")]
        public int MesId { get; set; }//Chave estrangueira

        public Mes Mes { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(2020, 2030, ErrorMessage = "Valor Inválido")]
        public int Ano { get; set; }

        public virtual ICollection<Pagamento> Pagametos { get; set; }

    }
}
