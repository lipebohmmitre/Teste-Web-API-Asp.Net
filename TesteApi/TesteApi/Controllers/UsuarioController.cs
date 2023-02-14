using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using TesteApi.Models;
using TesteApi.Repositorios;
using TesteApi.Repositorios.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<UsuarioModels>>> BuscarTodosUsuarios()
        {
            List<UsuarioModels> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModels>> BuscarPorId(int Id)
        {
            UsuarioModels usuario = await _usuarioRepositorio.BuscarPorId(Id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModels>> Cadastrar([FromBody] UsuarioModels usuarioModel)
        {
            UsuarioModels usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModels>> Atualizar([FromBody] UsuarioModels usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModels usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModels>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
