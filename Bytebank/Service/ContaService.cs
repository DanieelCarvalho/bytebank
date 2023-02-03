using Bytebank.Excepitions;
using Bytebank.Model.DTO;
using Bytebank.Model.Entities;


namespace Bytebank.Service
{
    public class ContaService
    {
        private List<Conta> _contas;

        private Conta? _contaLogada;
        private bool _isContaLogada{
            get{ return _contaLogada == null; }
        }
       

        public ContaService()
        {
            _contas = new List<Conta>()
            {
            
       
            };
            _contaLogada = null;
            
        }

        public void Depositar()
        {
            if (!_isContaLogada)
                throw new ContaNaoLogadaExcption("Você precisa fazer login ou se registar antes");
            if (_contaLogada.EstaBloquada)
                throw new ContaInativaExcepition("Esta conta não está autorizada.");
            Console.WriteLine("Digite o valor do deposito: ");
            double amount = double.Parse(Console.ReadLine());


            _contaLogada.Depositar(amount);
        }

        public void Tranferir(double amount, string cpfDestino)
        {
            if (!_isContaLogada)
                throw new ContaNaoLogadaExcption("Você precisa fazer login ou se registar antes");
            
            if (!HasContaSufficientSaldo(amount))
                throw new SaldoinsificienteExceptions("Saldo insuficiente!");
      
            Conta contaDestinho = null;
            try
            {

                contaDestinho = ToConta(cpfDestino);
            } catch(ContaInexistenteExceptions e)
            {
                throw;
            }
            _contaLogada.Tranferir(amount, contaDestinho);
        }
        // métodos 
        public void Register()
        {
        
            Console.WriteLine(_contas.Count);
            // TODO apresentar menu de registro 
            Console.WriteLine("Digite seu nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite seu CPF: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            long id = _contas.Count + 1;
            var teste = new Conta(nome, id, cpf, senha);
            _contas.Add(teste);
                Console.WriteLine(_contas.Count);
           
           
        }
        public  void Login(LoginFormDto loginForm)
        {
            if (IsContaExists(loginForm.Cpf))     
              
            if (!IsPasswordMatch(loginForm))
            throw new PasswordNotMatchExcepitions();

                Conta contaTologin = ToConta(loginForm.Cpf);
            if (contaTologin.EstaBloquada)
               throw new ContaInativaExcepition("Está conta não está autorizada");
            _contaLogada = contaTologin;
        }
        public void Logout()
        {

        }
        public bool IsContaExists(string cpf)
        {
            return _contas.Find(c => c.Cpf.Equals(cpf)) != null;
        }
        public bool IsPasswordMatch(LoginFormDto loginForm)
        {
            var conta = _contas.Find(c => c.Cpf.Equals(loginForm.Cpf));
            return conta.Senha.Equals(loginForm.Senha);
        }
        public  Conta ToConta(string cpf)
        {
            
            var conta = _contas.Find(c => c.Cpf.Equals(cpf));
           
            if (conta == null)
                throw new ContaInexistenteExceptions("Conta não identificada.");
            
            return conta;
        }

        public bool HasContaSufficientSaldo(double amount)
        {
            return _contaLogada.Saldo >= amount;
        }

      
    }
}
