using Bytebank.Excepitions;
using Bytebank.Model.DTO;
using Bytebank.Model.Entities;


namespace Bytebank.Service
{
    public class ContaService
    {
        private List<Conta> _contas;

        private Conta? _contaLogada;
        public bool _isContaLogada{
            get{ return _contaLogada != null; }
        }
       

        public ContaService()
        {
            _contas = new List<Conta>()
            {
                new Conta("Daniel", 1L, "123", "123"),
                new Conta("Thami", 2L, "1234", "1234")


            };
            _contaLogada = null;
            
        }

        public void Depositar()
        {
           
             if (!_isContaLogada)
               throw new ContaNaoLogadaExcption("Você precisa fazer login ou se registar antes");
         
            if (_contaLogada.EstaBloquada)
                throw new ContaInativaExcepition("Esta conta não está autorizada.");
            Console.Write("Digite o CPF para qual você quer depositar:");

            string cpfDestino = Console.ReadLine();
            Conta contaDestinhoDeposito = null;

            contaDestinhoDeposito = ToConta(cpfDestino);

            Console.Write("Digite o valor do depósito: R$");
            double amount = double.Parse(Console.ReadLine());


            _contaLogada.Depositar(amount, contaDestinhoDeposito);
        }

        public void Tranferir()
        {
            if (!_isContaLogada)
                throw new ContaNaoLogadaExcption("Você precisa fazer login ou se registar antes");

            Console.Write("Digite o CPF para qual você quer tranferir:");
            string cpfDestino = Console.ReadLine();

            Console.Write("Digite o valor da tranferência: R$ ");
            double amount = double.Parse(Console.ReadLine());

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
            _contaLogada.Tranferir(amount, contaDestinho );
        }
        public void Sacar()
        {
            if (!_isContaLogada)
                throw new ContaNaoLogadaExcption("Você precisa fazer login ou se registar antes");

            Console.Write("Digite o valor do saque: R$ ");
            double amount = double.Parse(Console.ReadLine());

            if (!HasContaSufficientSaldo(amount))
                throw new SaldoinsificienteExceptions("Saldo insuficiente!");

            _contaLogada.Sacar(amount);

        }
        public void Saldo()
        {
            if (!_isContaLogada)
                throw new ContaNaoLogadaExcption("Você precisa fazer login ou se registar antes");

            Console.WriteLine($"Olá, {_contaLogada.Nome} seu saldo é de {_contaLogada.Saldo:F2}");
            Console.WriteLine("Digite uma tecla para retornar: ");
            string retornarMenu = Console.ReadLine();

           
        }

        public void Register()
        {
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
            Console.WriteLine(conta.Saldo);
            return conta;
        }

        public bool HasContaSufficientSaldo(double amount)
        {
            return _contaLogada.Saldo >= amount;
        }

      
    }
}
