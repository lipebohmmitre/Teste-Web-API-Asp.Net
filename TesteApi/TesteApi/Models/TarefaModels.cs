using TesteApi.Enums;

namespace TesteApi.Models
{
    public class TarefaModels
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
