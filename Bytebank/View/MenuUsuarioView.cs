using Bytebank.Controllers;
using Bytebank.Model.Entities;
using Bytebank.Service;

namespace Bytebank.View;
public class MenuUsuarioView
{
    public static void MenuUsuario(string service)
    {
        
        Console.Write("  ");
        Console.WriteLine(MenuView.areaDoCliente);
        Console.WriteLine($"Olá,{service}");
        Console.WriteLine("1 - Depositar");
        Console.WriteLine("2 - Transferir");
        Console.WriteLine("3 - Saque");
        Console.WriteLine("4 - Saldo");
        Console.WriteLine("0 - Sair da conta");
        Console.Write("Digite a opção desejada: ");

    }
}

