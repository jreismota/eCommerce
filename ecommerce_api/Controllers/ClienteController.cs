using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerce.Models.DataContext;
using eCommerce.Models.DTO;
using eCommerce.Models.Table;
using ecommerceDAL;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_api.Controllers
{
    [Route("api/v1/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ClienteDAL clienteDAL;
        private readonly Mapper mapper;

        public ClienteController(eCommerceContext context)
        {
            clienteDAL = new ClienteDAL(context);
            mapper = AutoMapperConfiguration.Initialize();
        }

        [HttpGet("ListarClientes/{pagina}/{qtdRegistros}")]
        public async Task<object> ListarPaginado(int pagina, int qtdRegistros)
        {
            var clientes = await clienteDAL.ListarPaginado("", pagina, qtdRegistros);

            var listaClientes = clientes.ToList();

            var clientesDto = mapper.Map<List<Cliente>, List<ClienteDTO>>(listaClientes);

            dynamic result = new ExpandoObject();
            result.TotalRegistros = clientes.TotalItemCount;
            result.TotalPaginas = clientes.PageCount;
            result.ListaClientes = clientesDto;

            return result;
        }
        [HttpPost("Inserir")]
        public async Task<ActionResult<ClienteDTO>> Inserir([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto.IdPessoa != 0)
            {
                return BadRequest();
            }
            var cliente = mapper.Map<ClienteDTO, Cliente>(clienteDto);
            var clienteRetorno = await clienteDAL.Inserir(cliente);
            var clienteResult = mapper.Map<Cliente, ClienteDTO>(clienteRetorno);
            return Ok(clienteResult);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, ClienteDTO clienteDTO)
        {
            return Ok();
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            return Ok();
        }


    }


}

