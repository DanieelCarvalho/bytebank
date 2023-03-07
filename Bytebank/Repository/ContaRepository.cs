using Bytebank.Model.Entities;
using Bytebank.Service;
using System.Text.Json;

namespace Bytebank.Repository;

public class ContaRepository
{
    public  readonly string arquivoJson = "conta.json";
    
    public static void Deserializer(string arquivoJson)
    {
        if (!File.Exists(arquivoJson))
        {
            File.Create(arquivoJson).Close();
        }
        else
        {
            string jsonString = File.ReadAllText(arquivoJson);
            ContaService._contas = JsonSerializer.Deserialize<List<Conta>>(jsonString);
        }
        ;
    }
    public static void SerializarJson(string arquivoJson)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize( ContaService._contas, options);
        File.WriteAllText(arquivoJson, jsonString);
    }



    
}

