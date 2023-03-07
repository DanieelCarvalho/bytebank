using Bytebank.Model.DTO;
using Bytebank.Model.Entities;
using Bytebank.Service;
namespace Bytebank.Controllers;

public class MenuCrontrole
{
    
    public static void MenuControle(ContaService service)
    {
        int opcao = 0;
        int opcao2 = 0;
        int retorno = 0;
        // ContaService contaService = new ContaService();


        do
        {
           
            View.MenuView.ShowMenu();
            opcao= int.Parse(Console.ReadLine());
            
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    LoginFormDto user = View.ContaView.MenuLoginForm();
                    Conta nome = new Conta();
                    service.Login(user);
                    Console.Clear();
                    do
                    {
                        View.MenuUsuarioView.MenuUsuario(service._contaLogada.Nome);
                        opcao2 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (opcao2)
                        {
                            case 1:
                                service.Depositar();
                                Console.Clear();
                                break;
                            case 2:
                                service.Tranferir();
                                Console.Clear();

                                break;
                            case 3:
                                service.Sacar();
                                Console.Clear();

                                break;
                            case 4:
                                service.Saldo();
                                Console.Clear();
                                do
                                {
                                    switch (retorno)
                                    {
                                        case 0:
                                            break;
                                    }

                                } while (retorno != 0);

                                break;
                        }

                    } while (opcao2 != 0);
                    break;
                case 2:
                    service.Register();
                    Console.Clear();
                    break;
                case 3:
                   
                   
                    break;
                case 6:
                   
                    break;

               
            }
    
        }while (opcao != 0);
       
    }

}

