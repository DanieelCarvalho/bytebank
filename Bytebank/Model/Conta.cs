namespace Bytebank.Model.Entities;

public  class  Conta
{
    public string Nome { get; set; }
    public  long Id { get; private set; }
    public string Cpf { get; private set; } = null!;
    public string Senha { get; private set; } = null!;
    public double Saldo { get; private set; }
    public bool EstaBloquada { get; protected set; }

    public Conta( string nome, long id, string cpf, string senha)
    {
        Nome = nome;
        Id =  id;
        Cpf = cpf;
        Senha = senha;
        Saldo = 0.0;
        EstaBloquada = false;
    }
    public Conta()
    {

    }



    public void Depositar(double quantia, Conta contaDestinhoDeposito)
    {
         contaDestinhoDeposito.Saldo += quantia;
        
 
    }
    public void  Sacar(double quantia)
    {
       Saldo -= quantia;
    }
    public void Tranferir(double quantia , Conta contaDestino)
    {

        Sacar(quantia);

       contaDestino.Depositar(quantia, contaDestino);
    }




}
