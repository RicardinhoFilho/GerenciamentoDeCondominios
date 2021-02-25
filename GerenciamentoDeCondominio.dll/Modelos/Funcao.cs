using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeCondominios.BLL.Modelos
{
    public class Funcao: IdentityRole<string>
    {
        public string Descricao { get; set; }
    }
}
