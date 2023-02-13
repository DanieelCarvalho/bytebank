using Bytebank.Model.DTO;
using Bytebank.Service;
namespace Bytebank.Controllers;

public class MenuCrontrole
{
    
    public static void MenuControle()
    {
        int opcao = 0;
        int opcao2 = 0;
        int retorno = 0;
        ContaService contaService = new ContaService();

        do
        {
           
            View.MenuView.ShowMenu();
            opcao= int.Parse(Console.ReadLine());
            
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    LoginFormDto user = View.ContaView.MenuLoginForm();
                    contaService.Login(user);
                    Console.Clear();
                    do
                    {

                        View.MenuUsuarioView.MenuUsuario();
                        opcao2 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (opcao2)
                        {
                            case 1:
                                contaService.Depositar();
                                Console.Clear();
                                break;
                            case 2:
                                contaService.Tranferir();
                                Console.Clear();

                                break;
                            case 3:
                                contaService.Sacar();
                                Console.Clear();

                                break;
                            case 4:
                                contaService.Saldo();
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
                    contaService.Register();
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

