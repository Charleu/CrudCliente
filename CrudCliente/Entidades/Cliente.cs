using System;

namespace CrudCliente.Entidades
{
    internal class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }

        public Cliente()
        {
            Ativo = true;
        }
    }
}