using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciamentoDeCondominios.BLL.Modelos
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrogatório")]//"{0} escreve o nome do nosso campo na mensagem"
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrogatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Marca { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrogatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrogatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrogatório")]
        public string UsuarioId { get; set; }//Será nossa chave estrangeira relacionada com o usuário
        public Usuario Usuario { get; set; }
    }
}
