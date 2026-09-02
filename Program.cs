using System;
using System.Collections.Generic;

class Chamado
{
    public int Id;
    public string Titulo = "";
    public string Descricao = "";
    public string Solicitante = "";
    public string Categoria = "";
    public string Prioridade = "";
    public string Status = "";
}

class Program
{
    static List<Chamado> chamados = new List<Chamado>();
    static int proximoId = 1;

    static void Main()
    {
        string opcao = "";

        while (opcao != "0")
        {
            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("      SISTEMA DE CHAMADOS TI");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine("1 - Abrir chamado");
            Console.WriteLine("2 - Listar chamados");
            Console.WriteLine("3 - Buscar chamado");
            Console.WriteLine("4 - Alterar status");
            Console.WriteLine("5 - Fechar chamado");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();

            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine() ?? "";

            if (opcao == "1")
            {
                AbrirChamado();
            }
            else if (opcao == "2")
            {
                ListarChamados();
            }
            else if (opcao == "3")
            {
                BuscarChamado();
            }
            else if (opcao == "4")
            {
                AlterarStatus();
            }
            else if (opcao == "5")
            {
                FecharChamado();
            }
            else if (opcao == "0")
            {
                Console.WriteLine();
                Console.WriteLine("Sistema encerrado.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida!");
            }

            if (opcao != "0")
            {
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
        }
    }

    static void AbrirChamado()
    {
        Console.Clear();

        Console.WriteLine("=== ABRIR CHAMADO ===");
        Console.WriteLine();

        Chamado chamado = new Chamado();

        chamado.Id = proximoId;

        Console.Write("Título: ");
        chamado.Titulo = Console.ReadLine() ?? "";

        Console.Write("Descrição: ");
        chamado.Descricao = Console.ReadLine() ?? "";

        Console.Write("Solicitante: ");
        chamado.Solicitante = Console.ReadLine() ?? "";

        Console.Write("Categoria: ");
        chamado.Categoria = Console.ReadLine() ?? "";

        Console.Write("Prioridade (Baixa/Média/Alta): ");
        chamado.Prioridade = Console.ReadLine() ?? "";

        chamado.Status = "Aberto";

        chamados.Add(chamado);

        proximoId++;

        Console.WriteLine();
        Console.WriteLine("Chamado criado com sucesso!");
        Console.WriteLine("ID do chamado: " + chamado.Id);
    }

    static void ListarChamados()
    {
        Console.Clear();

        Console.WriteLine("=== LISTA DE CHAMADOS ===");
        Console.WriteLine();

        if (chamados.Count == 0)
        {
            Console.WriteLine("Nenhum chamado cadastrado.");
            return;
        }

        foreach (Chamado chamado in chamados)
        {
            Console.WriteLine("ID: " + chamado.Id);
            Console.WriteLine("Título: " + chamado.Titulo);
            Console.WriteLine("Solicitante: " + chamado.Solicitante);
            Console.WriteLine("Categoria: " + chamado.Categoria);
            Console.WriteLine("Prioridade: " + chamado.Prioridade);
            Console.WriteLine("Status: " + chamado.Status);
            Console.WriteLine("--------------------------------");
        }
    }

    static void BuscarChamado()
    {
        Console.Clear();

        Console.WriteLine("=== BUSCAR CHAMADO ===");
        Console.WriteLine();

        Console.Write("Digite o ID: ");
        string entrada = Console.ReadLine() ?? "";

        int id;

        if (!int.TryParse(entrada, out id))
        {
            Console.WriteLine();
            Console.WriteLine("ID inválido.");
            return;
        }

        foreach (Chamado chamado in chamados)
        {
            if (chamado.Id == id)
            {
                Console.WriteLine();
                Console.WriteLine("ID: " + chamado.Id);
                Console.WriteLine("Título: " + chamado.Titulo);
                Console.WriteLine("Descrição: " + chamado.Descricao);
                Console.WriteLine("Solicitante: " + chamado.Solicitante);
                Console.WriteLine("Categoria: " + chamado.Categoria);
                Console.WriteLine("Prioridade: " + chamado.Prioridade);
                Console.WriteLine("Status: " + chamado.Status);

                return;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Chamado não encontrado.");
    }

    static void AlterarStatus()
    {
        Console.Clear();

        Console.WriteLine("=== ALTERAR STATUS ===");
        Console.WriteLine();

        Console.Write("Digite o ID do chamado: ");
        string entrada = Console.ReadLine() ?? "";

        int id;

        if (!int.TryParse(entrada, out id))
        {
            Console.WriteLine();
            Console.WriteLine("ID inválido.");
            return;
        }

        foreach (Chamado chamado in chamados)
        {
            if (chamado.Id == id)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Aberto");
                Console.WriteLine("2 - Em andamento");
                Console.WriteLine("3 - Fechado");
                Console.WriteLine();

                Console.Write("Escolha o novo status: ");
                string opcao = Console.ReadLine() ?? "";

                if (opcao == "1")
                {
                    chamado.Status = "Aberto";
                }
                else if (opcao == "2")
                {
                    chamado.Status = "Em andamento";
                }
                else if (opcao == "3")
                {
                    chamado.Status = "Fechado";
                }
                else
                {
                    Console.WriteLine("Status inválido.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("Status alterado com sucesso!");

                return;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Chamado não encontrado.");
    }

    static void FecharChamado()
    {
        Console.Clear();

        Console.WriteLine("=== FECHAR CHAMADO ===");
        Console.WriteLine();

        Console.Write("Digite o ID do chamado: ");
        string entrada = Console.ReadLine() ?? "";

        int id;

        if (!int.TryParse(entrada, out id))
        {
            Console.WriteLine();
            Console.WriteLine("ID inválido.");
            return;
        }

        foreach (Chamado chamado in chamados)
        {
            if (chamado.Id == id)
            {
                chamado.Status = "Fechado";

                Console.WriteLine();
                Console.WriteLine("Chamado fechado com sucesso!");

                return;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Chamado não encontrado.");
    }
}