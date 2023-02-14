using Microsoft.EntityFrameworkCore;
using TesteApi.Data.Map;
using TesteApi.Models;

namespace TesteApi.Data
{
    public class SistemaTarefasDBContext : DbContext
    {

        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModels> Usuarios { get; set; }
        public DbSet<TarefaModels> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
