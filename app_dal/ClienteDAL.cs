using System;
using eCommerce.Models.DataContext;
using eCommerce.Models.Table;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ecommerceDAL
{
    public class ClienteDAL
    {
        private readonly eCommerceContext _context;

        public ClienteDAL(eCommerceContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> Listar()
        {
            var clientes = await _context.Clientes.Include("IdPessoaNavigation.PessoaFisica")
                .Include("IdPessoaNavigation.PessoaJuridica")
                .ToListAsync();

            return clientes;
        }

        public async Task<Cliente> Inserir(Cliente cliente)
        {
            //chamar: var pessoa = new PessoaDAL(_context).obterPessoa(cliente.IdPessoaNavigation.CpfCnpj);
            // if (pessoa != null)
            // {
            //     cliente.IdPessoa = pessoa.IdPessoa;
            //     cliente.IdPessoaNavigation = null;
            // }
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> ObterApenasPessoaVinculada(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.IdPessoaNavigation)
                .FirstOrDefaultAsync(m => m.IdPessoa == id);

            return cliente;
        }

        public async Task<IPagedList<Cliente>> ListarPaginado(string search, int numeroPagina, int qtdRegistros)
        {
            var clientes = await _context.Clientes.Include("IdPessoaNavigation.PessoaFisica")
                .Include("IdPessoaNavigation.PessoaJuridica")
                .Where(x => x.IdPessoaNavigation.Nome.Contains(search) || string.IsNullOrEmpty(search))
                .ToPagedListAsync(numeroPagina, qtdRegistros);

            return clientes;
        }

        public async Task<Cliente> ObterComPessoaFisicaOuJuridicaVinculada(int id)
        {
            var cliente = await _context.Clientes.Include(c => c.IdPessoaNavigation.PessoaFisica)
                .Include(c => c.IdPessoaNavigation.PessoaJuridica)
                .SingleAsync(c => c.IdPessoa == id);

            return cliente;
        }

        public async Task<Cliente> ObterPorId(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            return cliente;
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.IdPessoa))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return cliente;
        }

        public async Task<bool> Excluir(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExcluirPorId(int id)
        {
            var cliente = await this.ObterPorId(id);
            await this.Excluir(cliente);

            return true;
        }


        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdPessoa == id);
        }

    }
}
