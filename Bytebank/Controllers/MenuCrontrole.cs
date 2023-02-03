using Bytebank.Model.DTO;
using Bytebank.Service;
namespace Bytebank.Controllers;


public class MenuCrontrole
{
    
    public static void MenuControle()
    {
        int opcao = 0;
        int opcao2 = 0;
        ContaService contaService = new ContaService();

        do
        {
          

            View.MenuView.ShowMenu();
            opcao= int.Parse(Console.ReadLine());
            
            Console.Clear();
            
            
            switch (opcao)
            {
                case 1:

                    contaService.Register();
                    Console.Clear();
                    break;
                case 6:
                    do
                    {
                        LoginFormDto user = View.ContaView.MenuLoginForm();
                        contaService.Login(user);
                        Console.Clear();
                        View.MenuUsuarioView.MenuUsuario();
                        opcao2 = int.Parse(Console.ReadLine());
                        
                        switch (opcao2)
                        {
                            case 1:
                                contaService.Depositar();
                                break;

                        }
                        

                    } while (opcao2 != 0);
                    break;
            }
    
        }while (opcao != 0);
       
    }

}

