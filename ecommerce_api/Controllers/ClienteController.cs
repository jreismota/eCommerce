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


    }


}
//Tipos de retorno: https://docs.microsoft.com/pt-br/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0
//http://www.macoratti.net/19/06/aspc_tiporet1.htm
