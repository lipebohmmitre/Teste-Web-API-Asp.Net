using Microsoft.EntityFrameworkCore;
using TesteApi.Data;
using TesteApi.Models;
using TesteApi.Repositorios.Interface;

namespace TesteApi.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly SistemaTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModels> Adicionar(UsuarioModels usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int Id)
        {
            UsuarioModels usuarioporId = await BuscarPorId(Id);

            if (usuarioporId == null)
                throw new Exception($"Usuário para o Id: {Id} Não foi encontrado.");

            _dbContext.Usuarios.Remove(usuarioporId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModels> Atualizar(UsuarioModels usuario, int Id)
        {
            UsuarioModels usuarioporId = await BuscarPorId(Id);

            if (usuarioporId == null)
                throw new Exception($"Usuário para o Id: {Id} Não foi encontrado.");

            usuarioporId.Name = usuario.Name;
            usuarioporId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioporId);
            await _dbContext.SaveChangesAsync();

            return usuarioporId;           
        }

        public async Task<UsuarioModels> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModels>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
