using CrudCliente.Controllers;
using CrudCliente.Enumeradores;
using System;

namespace CrudCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            OpcaoEnum opcao = 0;

            do
            {
                Console.WriteLine("Escolha ");
                Console.WriteLine("1) Cadastrar cliente\n" +
                    "2) Listar todos clientes\n" +
                    "3) Editar Cliente\n" +
                    "4) Apagar um Cliente");
                MenuEnum menu = Enum.Parse<MenuEnum>(Console.ReadLine());

                ClienteController clienteController = new ClienteController();

                switch (menu)
                {
                    case MenuEnum.Adicionar:
                        {
                            Console.WriteLine("Insira o nome do cliente:");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Insira o e-mail do cliente:");
                            string email = Console.ReadLine();
                            Console.WriteLine("Informe a data de nascimento do cliente:");
                            DateTime nascimento = DateTime.Parse(Console.ReadLine());
                            clienteController.AddCliente(nome, email, nascimento);
                        }
                        break;
                    case MenuEnum.ListarTodos:
                        {
                            var clientes = clienteController.GetClientes();
                            clientes.ForEach(cliente => Console.WriteLine(
                                            $"Cliente : {cliente.Nome}\n" +
                                            $"Data de Nascimento: {cliente.DataNascimento.ToString("dd-MM-yyyy")}\n" +
                                            $"Email : {cliente.Email}")
                                          );
                        }
                        break;
                    case MenuEnum.EditarCliente:
                        {
                            Console.WriteLine("Para atualizar as informações do cliente, forneça os seguintes dados:");
                            Console.WriteLine("ID do cliente a ser atualizado:");
                            int clienteId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Insira o novo nome do cliente:");
                            string novoNome = Console.ReadLine();
                            Console.WriteLine("Insira o novo e-mail do cliente:");
                            string novoEmail = Console.ReadLine();
                            Console.WriteLine("Informe a nova data de nascimento:");
                            DateTime novaDataNascimento = DateTime.Parse(Console.ReadLine());
                            clienteController.EditarCliente(clienteId, novoNome, novoEmail, novaDataNascimento);
                        }
                        break;
                    case MenuEnum.DeletarClienteFisico:
                        {
                            Console.WriteLine("Informe o ID do cliente a ser excluído:");
                            int clienteId = int.Parse(Console.ReadLine());
                            clienteController.DeleteClienteFisico(clienteId);
                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                        break;
                }
                Console.WriteLine("Deseja realizar outra operação?");
                opcao = Enum.Parse<OpcaoEnum>(Console.ReadLine());
                Console.Clear();

            } while (opcao != OpcaoEnum.Nao);
        }
    }
}