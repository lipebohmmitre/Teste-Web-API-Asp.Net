using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteApi.Models;

namespace TesteApi.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModels>
    {
        public void Configure(EntityTypeBuilder<TarefaModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
