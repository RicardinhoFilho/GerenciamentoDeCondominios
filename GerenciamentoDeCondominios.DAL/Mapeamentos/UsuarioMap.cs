using GerenciamentoDeCondominios.BLL.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoDeCondominios.DAL.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.CPF).IsRequired().HasMaxLength(30);
            builder.HasIndex(u => u.CPF).IsUnique();
            builder.Property(u => u.Foto).IsRequired();
            builder.Property(u => u.PrimeiroAcesso).IsRequired();
            builder.Property(u => u.Status).IsRequired();

            builder.HasMany(u => u.ProprieatriosApartamentos).WithOne(u => u.Proprietario);//Um Propeietário pode estar vinculado à vários apartamentos, entretanto um apartamento só pode estar vimculado à um Propeietário
            builder.HasMany(u => u.MoradoresApartamentos).WithOne(u => u.Morador);//Um moradora pode estar vinculado à vários apartamentos, entretanto um apartamento só pode estar vimculado à um morador
            builder.HasMany(u => u.Veiculos).WithOne(u => u.Usuario);//Um usuario pode estar vinculado à vários veiculos, entretanto um veiculos só pode estar vimculado à um usuario
            builder.HasMany(u => u.Pagamentos).WithOne(u => u.Usuario);
            builder.HasMany(u => u.Servicos).WithOne(u => u.Usuario);

            builder.ToTable("Usuarios");
        }
    }
}
