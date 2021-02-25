using GerenciamentoDeCondominios.BLL.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeCondominios.DAL.Mapeamentos
{
    public class ServicosPrediosMap : IEntityTypeConfiguration<ServicosPredio>
    {
        public void Configure(EntityTypeBuilder<ServicosPredio> builder)
        {
            builder.HasKey(sp => sp.Servico);
            builder.Property(sp => sp.ServicoId).IsRequired();
            builder.Property(sp => sp.DataExecucao).IsRequired();

            builder.HasOne(sp => sp.Servico).WithMany(sp => sp.ServicosPredios).HasForeignKey(sp => sp.ServicoId);

            builder.ToTable("ServicoPredios");
        }
    }
}
