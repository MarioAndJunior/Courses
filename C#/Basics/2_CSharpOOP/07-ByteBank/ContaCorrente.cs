namespace _07_ByteBank
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }
        public Cliente Titular { get; set; }
        private int _agencia;
        public int Agencia 
        { 
            get
            {
                return this._agencia;
            }
            set
            {
                if(value <= 0)
                {    
                    return;
                }

                this._agencia = value;
            } 
        }
        private int _numero;
        public int Numero
        {
            get
            {
                return this._numero;
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }

                this._numero = value;
            }
        }
        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return this._saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                this._saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numero)
        {
            this.Agencia = agencia;
            this.Numero = numero;
            ContaCorrente.TotalDeContasCriadas++;
        }


        public bool Sacar(double valor)
        {
            if(this._saldo < valor)
            {
                return false;
            }
        
            this._saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if(this._saldo < valor)
            {
                return false;
            }
        
            this._saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}

