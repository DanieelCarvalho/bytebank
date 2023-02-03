namespace Bytebank.Excepitions;

public class PasswordNotMatchExcepitions : ContaExcepition
{
    public PasswordNotMatchExcepitions() : base("As senhas não coincidem!")
    {
            
    }
    public PasswordNotMatchExcepitions(string msg) : base(msg)
    {

    }
}



