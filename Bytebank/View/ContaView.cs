using Bytebank.Model.DTO;
using Bytebank.Service;

namespace Bytebank.View;
public  class ContaView
{
    public static LoginFormDto MenuLoginForm()
    {

        Console.WriteLine("Faça seu login ");
        Console.Write("Cpf: ");
        string cpf = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();
        return new LoginFormDto
        {
            Cpf = cpf,
            Senha = senha,
            
        };
       
    }

}

