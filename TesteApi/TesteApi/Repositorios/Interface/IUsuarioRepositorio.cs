using TesteApi.Models;

namespace TesteApi.Repositorios.Interface
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModels>> BuscarTodosUsuarios();
        Task<UsuarioModels> BuscarPorId(int Id);
        Task<UsuarioModels> Adicionar(UsuarioModels usuario);
        Task<UsuarioModels> Atualizar(UsuarioModels usuario, int Id);
        Task<bool> Apagar(int Id);
    }
}
