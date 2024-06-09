using Domain.Auth;
using GINVEST.Domain.Bussines;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Portifolio> Portifolios { get; set; }
        public DbSet<Ativo> Ativos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            DefineUsuarios(ref modelBuilder);
            DefinePortifolio(ref modelBuilder);
            DefineAtivo(ref modelBuilder);

        }

        private void DefineAtivo(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ativo>(entity =>
            {
                entity.ToTable("ativo");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Codigo)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.HasMany(p => p.Transacoes)
                    .WithOne(b => b.Ativo)
                    .HasForeignKey(p => p.AtivoId);
            });
        }
        private void DefinePortifolio(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portifolio>(entity =>
            {
                entity.ToTable("portifolio");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Nome)
                    .HasColumnName("Nome")
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(u => u.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsRequired();
                
                entity.Property(u => u.UsuarioId)
                    .IsRequired();

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Portifolios)
                    .HasForeignKey(d => d.UsuarioId);

            });
        }
        private void DefineUsuarios(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Nome)
                        .HasColumnName("Nome")
                        .HasMaxLength(50)
                        .IsRequired();
                entity.Property(u => u.Email)
                        .HasColumnName("Email")
                        .HasMaxLength(255)
                        .IsRequired();
                entity.Property(u => u.Senha)
                        .HasMaxLength(50)
                        .IsRequired();

            });
        }
    }
}
