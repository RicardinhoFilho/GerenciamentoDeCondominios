using GerenciamentoDeCondominios.BLL.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeCondominios.DAL.Mapeamentos
{
    public class ServicosMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.Property(s => s.ServicoId);
            builder.Property(s => s.Nome).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Valor).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.UsuarioId).IsRequired();

            builder.HasOne(s => s.Usuario).WithMany(s => s.Servicos).HasForeignKey(s => s.UsuarioId);//Um usuário pode requisitar VÁRIOS serviços
            builder.HasMany(s => s.ServicosPredios).WithOne(s => s.Servico);//Vários serviços podem estar relacionados a um Serviço

            builder.ToTable("Servicos");

        }
    }
}
