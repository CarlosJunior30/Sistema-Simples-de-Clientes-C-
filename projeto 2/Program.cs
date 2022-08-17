using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace projeto_2
{
    internal class Program
    {
        [System.Serializable]
        struct CLiente
        {
            public string nome;
            public string email;
            public string CPF;
        }

        static List<CLiente> clientes = new List<CLiente>();


        enum menu { Listagem = 1, Adicionar = 2, Remover = 3, Sair = 4 }

        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (!escolheuSair)
            {

                Console.WriteLine("Sistema de Clientes -  Sejam Bem Vindos");
                Console.WriteLine("Escolha uma das opções:");
                Console.WriteLine("1 - Listagem\n2 - Adicionar\n3 - Remover\n4 - Sair");

                int intOp = int.Parse(Console.ReadLine());
                menu opcao = (menu)intOp;


                switch (opcao)
                {

                    case menu.Listagem:
                        Listagem();
                        break;
                    case menu.Adicionar:
                        Adicionar();
                        break;
                    case menu.Remover:
                        Remover();
                        break;
                    case menu.Sair:
                        escolheuSair = true;
                        break;

                }
                Console.Clear();
            }
        }

        static void Adicionar()
        {
            CLiente cliente = new CLiente();
            Console.WriteLine("Cadastro de Clientes: ");
            Console.WriteLine("Nome do Cliente:");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("Email do Cliente:");
            cliente.email = Console.ReadLine();
            Console.WriteLine("CPF do Cliente");
            cliente.CPF = Console.ReadLine();


            clientes.Add(cliente);
            Salvar();

            Console.WriteLine("Cadastro concluido, aperte enter pada sair");
            Console.ReadLine();

        }

        static void Listagem()

        {
            if (clientes.Count > 0)
            {
                Console.WriteLine("Lista de Clientes:");
                int i = 0;
                foreach (CLiente cliente in clientes)
                {
                    Console.WriteLine($"ID: {i}");
                    Console.WriteLine($"Nome: {cliente.nome}");
                    Console.WriteLine($"E-mail: {cliente.email}");
                    Console.WriteLine($"CPF:  {cliente.CPF}");
                    Console.WriteLine("================");
                    i++;
                }

            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado");
            }
            Console.WriteLine("aperte enter para sair");
            Console.ReadLine();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do cliente quei voce quer remover: ");
            int id = int.Parse(Console.ReadLine());
            
            if(id >= 0 && id <clientes.Count)
            {
                clientes.RemoveAt(id);

            }

            else
            {

                Console.WriteLine("Id digitado é invalido, tente novamente!");
            }
        }


        static void Salvar()
        {

            FileStream stream = new FileStream("Clientes.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, clientes);

            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("Clientes.dat", FileMode.OpenOrCreate);

            try
            {
                
                BinaryFormatter enconder = new BinaryFormatter();

                clientes = (List<CLiente>)enconder.Deserialize(stream);

                if(clientes==null)
                {
                    clientes=new List<CLiente>();   

                }             

            }
            catch (Exception e)
            {

                clientes = new List<CLiente>();
            }

            stream.Close();


        }


    }
}














