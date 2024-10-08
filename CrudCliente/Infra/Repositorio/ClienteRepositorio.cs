using CrudCliente.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudCliente.Infra.Repositorio
{
    internal class ClienteRepositorio
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private static int id = 0;

        public void Add(Cliente cliente)
        {
            cliente.Id = id++;
            clientes.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            var clienteBanco = clientes.FirstOrDefault(x => x.Id == cliente.Id);
            if (clienteBanco != null)
            {
                clienteBanco.Nome = cliente.Nome;
                clienteBanco.Email = cliente.Email;
                clienteBanco.DataNascimento = cliente.DataNascimento;
            }
        }

        public void DeleteFisico(Cliente cliente)
        {
            clientes.Remove(cliente);
        }

        public void DeleteLogico(int id)
        {
            var cliente = clientes.FirstOrDefault(x => x.Id == id);
            if (cliente != null)
            {
                cliente.Ativo = false;
            }
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public List<Cliente> ListarClientesAtivos()
        {
            return clientes.Where(x => x.Ativo == true).ToList();
        }
    }
}