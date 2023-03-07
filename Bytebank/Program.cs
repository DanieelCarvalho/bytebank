using Bytebank.Controllers;
using Bytebank.Excepitions;
using Bytebank.Model.Entities;
using Bytebank.Repository;
using Bytebank.Service;
using Bytebank.View;
using System.Text.Json;

namespace ByteBank;

public class Program
    
{
    public static void Main(string[] args)
    {
        ContaRepository Deserializaando = new ContaRepository();
            ContaService service = new ContaService();

        ContaRepository.Deserializer(Deserializaando.arquivoJson);

       

        try
        {
          
            MenuCrontrole.MenuControle(service);
            
          



        }
        catch (PasswordNotMatchExcepitions passwordException)
        {
            Console.WriteLine(passwordException.Message);
        }
    }
}

 

