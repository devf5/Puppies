using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PuppiesContext : DbContext, IDisposable
    {
        private const string local = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string azure = @"Server=tcp:devf5.database.windows.net,1433;Initial Catalog=puppies;Persist Security Info=False;User ID=admindevf5;Password=Devf5@Desenv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public PuppiesContext() : base(azure)
        {

        }

        new public void Dispose()
        {
            base.Dispose(true);
        }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Usuario>().HasKey(u => u.ID);
            modelBuilder.Entity<Usuario>().Property(u => u.Email).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Sobrenome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Senha).IsRequired();

            modelBuilder.Entity<Sessao>().HasKey(s => s.ID);
            modelBuilder.Entity<Sessao>().Property(s => s.Dispositivo).IsRequired();
            modelBuilder.Entity<Sessao>().Property(s => s.Encerrada).IsRequired();
            modelBuilder.Entity<Sessao>().Property(s => s.UltimoAcesso).IsRequired();
            modelBuilder.Entity<Sessao>().Property(s => s.UltimoIP).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Sessao>().HasRequired(s => s.Usuario).WithMany(u => u.Sessoes).HasForeignKey(s => s.UsuarioID);
        }
    }
}
