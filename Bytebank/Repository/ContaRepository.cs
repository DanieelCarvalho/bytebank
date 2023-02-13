using Bytebank.Model.Entities;
using Bytebank.Service;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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

    

    //    public List<Conta> LerTodos()
    //    {
    //        var options = new JsonSerializerOptions { WriteIndented = true };
    //        string jsonLines = File.ReadAllText(arquivoJson);
    //        List<Conta> contaList = new List<Conta>();
    //        List<Conta>? leitura = JsonSerializer.Deserialize<List<Conta?>>(jsonLines, options);

    //        if (leitura != null)
    //        {
    //            contaList.AddRange(leitura);
    //        }

    //        return contaList;
    //    }


    //public bool SalvarTodos(List<Conta> _contas)
    //{
    //    var options = new JsonSerializerOptions { WriteIndented = true };
    //    string contajson = JsonSerializer.Serialize(_contas, options);
  
    //     File.WriteAllText(arquivoJson, contajson);
    //    return true;
     

        
    //}


    
}

