using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;
        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            AtualizarCamposDeTexto();
            AtualizarControles();
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        private void AtualizarControles()
        {
            //Syntax suggar, faz a criação dos métodos debaixo dos panos
            //RoutedEventHandler dialogResultTrue = delegate (object o, RoutedEventArgs e)
            //{
            //    DialogResult = true;
            //};

            //RoutedEventHandler dialogResultFalse = delegate (object o, RoutedEventArgs e)
            //{
            //    DialogResult = false;
            //};

            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

            //var okEventHandler = (RoutedEventHandler)btnOk_Click + Fechar;
            //var cancelarEventHandler = (RoutedEventHandler)btnCancelar_Click + Fechar;

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;

            //Compilador faz isso
            //var cancelarEventHandler =
            //    (RoutedEventHandler)Delegate.Combine(
            //        (RoutedEventHandler)btnCancelar_Click,
            //        (RoutedEventHandler)Fechar);

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            txtNumero.TextChanged += ValidarCampoNulo;
            txtNumero.TextChanged += ValidarSomenteNumeros;
            txtNome.TextChanged += ValidarCampoNulo;
            txtDescricao.TextChanged += ValidarCampoNulo;
            txtEndereco.TextChanged += ValidarCampoNulo;
            txtTelefone.TextChanged += ValidarCampoNulo;
        }

        private void ValidarSomenteNumeros(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Modo full
            //Func<char, bool> verificaSeEhDigito = caractere =>
            //{
            //    return Char.IsDigit(caractere);
            //};
            //var todosCaracteresSaoDigito = txtNumero.Text.All(verificaSeEhDigito);

            // Modo simples, eh possivel pois o IsDigit tem a mesma assinatura esperada da função
            var todosCaracteresSaoDigito = txtNumero.Text.All(Char.IsDigit);
            if (String.IsNullOrEmpty(textBox.Text.Trim()))
            {
                todosCaracteresSaoDigito = false;
            }

            if (todosCaracteresSaoDigito)
            {
                textBox.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                textBox.Background = new SolidColorBrush(Colors.OrangeRed);
            }

        }
        private void ValidarCampoNulo(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            var textoEstaVazio = String.IsNullOrEmpty(textBox.Text.Trim());

            if (textoEstaVazio)
            {
                textBox.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                textBox.Background = new SolidColorBrush(Colors.White);
            }

        }

        //private void btnOk_Click(object sender, EventArgs e)
        //{
        //    DialogResult = true;
        //}

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    DialogResult = false;
        //}

        private void Fechar(object sender, EventArgs e)
        {
            Close();
        }
    }
}
