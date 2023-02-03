using Bytebank.Controllers;
using Bytebank.Excepitions;
using Bytebank.Model.Entities;
using Bytebank.Service;
using Bytebank.View;

namespace ByteBank;

public class Program
    
{
    public static void Main(string[] args)
    {
        ContaService service = new ContaService();
        //new Conta { Id = 1L, Cpf = "123", Senha = "123pass" },
       // new Conta { Id = 2L, Cpf = "1234", Senha = "1234pass" }
        try
        {
            MenuCrontrole.MenuControle();
            //var loginForm = ContaView.MenuLoginForm();
            // service.Login(loginForm);
            // service.Tranferir(20, "");



        }
        catch (PasswordNotMatchExcepitions passwordException)
        {
            Console.WriteLine(passwordException.Message);
        }
    }
}

 

