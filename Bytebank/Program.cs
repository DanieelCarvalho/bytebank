using System;
using System.Reflection;
using System.Security.Cryptography;

namespace ByteBank
{

    public class Program
    {

        static void ShowMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }
        public static void ShowMenuConta()
        {
           
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Transferir");
            Console.WriteLine("3 - Saque");
            Console.WriteLine("4 - Saldo");
            Console.WriteLine("0 - Sair da conta");
            Console.Write("Digite a opção desejada: ");

        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Cadastre seu cpf: ");
            string salvarCpf = Console.ReadLine();

            if(salvarCpf.Length < 11 || salvarCpf.Length > 11)
            {
                Console.WriteLine("CPF Inexistente. Tente novamente");
                return;
            }
          
                cpfs.Add(salvarCpf);
            
            Console.Write("Cadastre seu nome: ");
            string salvarNome = Console.ReadLine();

            if (salvarNome.Length == 0)
            {
                Console.WriteLine("O nome não foi inserido. Tente Novamente.");
                return;
            }
            titulares.Add(salvarNome);



            Console.Write("crie uma senha: ");
            string SalvarSenha = GetPassword();

            if (SalvarSenha.Length < 6 )
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("Erro! Crie uma senha com mais de 6 caracteres!");
                return;
            }
            Console.Write("Confirme a senha criada: ");
            string ConfirmaSenha = GetPassword();
            if (SalvarSenha != ConfirmaSenha)
            {
                Console.WriteLine("As senhas não são iguais");
                return;
            }
            
                senhas.Add(SalvarSenha);
            
           
           

            saldos.Add(0);
        }
        static string GetPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }
        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(d => d == cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("Não foi possível encontrar este CPR");
                Console.WriteLine("MOTIVO: conta não foi encontrada.");
                return;
            }
            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);
            Console.WriteLine("Conta deletada com sucesso.");
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            if (cpfs.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma conta cadastrada no momento.");
            }
            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentaConta(i, cpfs, titulares, saldos);
            }
        }
        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum():F2}");
           
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(d => d == cpfParaApresentar);
            

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta conta");
                Console.WriteLine("MOTIVO: conta não foi encontrada.");
            }
            ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
        }
        static void ManipularConta(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            ShowMenuConta();
           
        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
           
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

       
        static void DepositarConta(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            {
                Console.Write("Digite o CPF para qual você quer depositar:");

                string cpfParaDeposito = Console.ReadLine();
                int indexParaDeposito = cpfs.FindIndex(cpf => cpf == cpfParaDeposito);

                if (indexParaDeposito == -1)
                {
                    Console.WriteLine("CPF não encontrado/escolha a opção desajada novamente:");
                }
                else
                {

                    Console.Write("Digite o valor do depósito: R$");
                    double valorDeposito = double.Parse(Console.ReadLine());
                    Console.Write("Confirme sua senha: ");
                    string senhaParaDepositar = GetPassword();
                    int indexSenha = senhas.FindIndex(d => d == senhaParaDepositar);

                    if (indexSenha == -1)
                    {
                        Console.WriteLine("Senha inválida. Tente novamente.");
                        return;
                    }
                    saldos[indexParaDeposito] += valorDeposito;
                  
                    Console.WriteLine($"Depósito de R$ {valorDeposito:F2} feito com succeso para {titulares[indexParaDeposito]} ");
                   
                }
            }
        }
        static void Tranferir(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            Console.Write("Digite o CPF para qual você quer tranferir:");

            
            string cpfParatranferir = Console.ReadLine();
            int indexParatranferir = cpfs.FindIndex(cpf => cpf == cpfParatranferir);

            if (indexParatranferir == -1 )
            {
                Console.WriteLine("CPF não encontrado/escolha a opção desejada novamente:");
                return;
            }
            else if(indexParatranferir == indexParatranferir )
            {
                Console.WriteLine("Não é possível tranferir dinheiro para a sua própria conta");
                return;
            }
            
                Console.Write("Digite o valor da tranferência: R$ ");
                double valorTranferencia = double.Parse(Console.ReadLine());
            Console.Write("Confirme seu cpf: ");
            string cpfParaValidar = Console.ReadLine();
            int indexCpf = cpfs.FindIndex(d => d == cpfParaValidar);

            Console.Write("Confirme sua senha: ");
            string senhaParaDepositar = GetPassword();
            int indexSenha = senhas.FindIndex(d => d == senhaParaDepositar);


            if (indexSenha == -1 && indexCpf == -1)
            {
                Console.WriteLine("CPF ou senha inválida. Tente novamente.");
                return;
            }

            if (saldos[indexCpf] < valorTranferencia)
            {
                Console.WriteLine("Você não possui saldo para essa operação");

            }
            else
            {
                saldos[indexCpf] -= valorTranferencia;
                saldos[indexParatranferir] += valorTranferencia;

                Console.WriteLine($"Tranferência de R$ {valorTranferencia:F2} feita com sucesso para {titulares[indexParatranferir]}. Seu saldo atual é de {saldos[indexCpf]:F2}");
            }
        }
        static void Saque(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas )
        {
            Console.Write("Digite o valor do saque: R$ ");
            double valorSaque = double.Parse(Console.ReadLine());

            Console.Write("Confirme sua senha: ");
            string senhaParaDepositar = GetPassword();
            int indexSenha = senhas.FindIndex(d => d == senhaParaDepositar);

            if (indexSenha == -1)
            {
                Console.WriteLine("Senha inválida. Tente novamente.");
                return;
            }
            if (saldos[indexSenha] < valorSaque)
            {
                Console.WriteLine($"Valor indisponível no momento.");
                return;
            }

            saldos[indexSenha] -= valorSaque;

            Console.WriteLine($"Você sacou R${valorSaque:F2}. Seu saldo é de R$ {saldos[indexSenha]:F2}");

        }
        static void SaldoConta(List<double> saldos, List<string> senhas, List<string> titulares)
        {
            Console.Write("Confirme sua senha: ");
            string senhaParaDepositar = GetPassword();
            int indexSenha = senhas.FindIndex(d => d == senhaParaDepositar);
            
            if (indexSenha == -1)
            {
                Console.WriteLine("Senha inválida. Tente novamente.");
                return;
            }
            Console.WriteLine($"Olá, {titulares[indexSenha]}. Seu Saldo é de R$ {saldos[indexSenha]:F2}");
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;

            do
            {
                
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("-----------------");

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, saldos, senhas);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case 6:
                        int escolha;
                        Console.WriteLine("Faça seu login");
                        Console.Write("Digite seu cpf: ");
                        string cpfParaValidar = Console.ReadLine();
                        int indexCpf = cpfs.FindIndex(d => d == cpfParaValidar);

                        Console.Write("Digite a senha: ");
                        string senhaParaDepositar = GetPassword();
                        int indexSenha = senhas.FindIndex(d => d == senhaParaDepositar);
                        


                        if (indexSenha == -1 || indexCpf == -1)
                        {
                            Console.WriteLine("CPF não encontrado ou senha inválida. Tente novamente.");
                           
                        }else
                        {
                            Console.WriteLine("-----------------");
                            Console.WriteLine($"Olá, {titulares[indexCpf]}");

                            do
                            {
                                
                                ShowMenuConta();
                                escolha = int.Parse(Console.ReadLine());

                                
                                switch (escolha)
                                {
                                    case 1:
                                        DepositarConta(cpfs, titulares, saldos, senhas);
                                        break;
                                    case 2:
                                        Tranferir(cpfs, titulares, saldos, senhas);
                                        break;
                                    case 3:
                                        Saque(cpfs, titulares, saldos, senhas);
                                        break;
                                    case 4:
                                        SaldoConta(saldos,senhas, titulares);
                                        break;
                                }

                            } while (escolha != 0);

                            
                        }
                        break;

                }

                Console.WriteLine("-----------------");

            } while (option != 0);



        }

    }

}