using Bytebank.Model.DTO;
using Bytebank.Service;

namespace Bytebank.View;
public  class ContaView
{
    public static LoginFormDto MenuLoginForm()
    {

        Console.WriteLine(Login);
        Console.Write("Digite seu Cpf: ");
        string cpf = Console.ReadLine();
        Console.Write("Digite sua Senha: ");
        string senha = Console.ReadLine();
        return new LoginFormDto
        {
            Cpf = cpf,
            Senha = senha,
            
        };
       
    }
    public static string Login = @"
  ______                        _             _           
 |  ____|                      | |           (_)        _ 
 | |__ __ _  ___ __ _    ___   | | ___   __ _ _ _ __   (_)
 |  __/ _` |/ __/ _` |  / _ \  | |/ _ \ / _` | | '_ \     
 | | | (_| | (_| (_| | | (_) | | | (_) | (_| | | | | |  _ 
 |_|  \__,_|\___\__,_|  \___/  |_|\___/ \__, |_|_| |_| (_)
             )_)                         __/ |            
                                        |___/             
";

}

