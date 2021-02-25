using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeCondominios.BLL.Modelos
{
    public class Usuario : IdentityUser<string>//Definimos querecebemos está herança que é especifica para usuários, e o tipo da chave primária definimos como uma string
    {
        public string CPF { get; set; }
        public string Foto { get; set; }
        public bool PrimeiroAcesso { get; set; }//Queremos saber se é seu primeiro acesso, pois caso seja a primeira vez, nós iremos redireciona-lo para uma página para redefinir seu login
        public StatusConta Status { get; set; }//Classe que define status de seu login, se foi autorizado ou não
        public virtual ICollection<Apartamento> MoradoresApartamentos { get; set; } //iremos utilizar a propriedade de nosso endity framework lazilowli que faz com que carregamos o campo somente se necessário, melhorando nosso desempoenho, por isso estamos definindo ela como virtual
        public virtual ICollection<Apartamento> ProprieatriosApartamentos { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
    }

    public enum StatusConta
    {
        Analisando,//Quando o usuário se cadastrar pela primeira vez
        Aprovado,//Caso o adm aprovar
        Reprovado//Caso o adm reprovar
    }
}
