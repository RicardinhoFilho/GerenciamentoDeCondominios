using GerenciamentoDeCondominios.BLL.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeCondominios.DAL.Mapeamentos
{
    class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.Descricao).IsRequired().HasMaxLength(30);

            builder.HasData(
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Morador",
                    NormalizedName = "MORADOR",
                    Descricao = "Morador do Prédio"
                },


               new Funcao
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Sindico",
                   NormalizedName = "SINDICO",
                   Descricao = "Sindico do Prédio"
               },

               new Funcao
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Administrador",
                   NormalizedName = "ADMINISTRADOR",
                   Descricao = "Administrador do Prédio"
               }
            );
            builder.ToTable("Funcoes");
        }
    }
}
