using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private async void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            //var taskSchedulerUI = TaskScheduler.FromCurrentSynchronizationContext();
            var contas = r_Repositorio.GetContaClientes();
            BtnProcessar.IsEnabled = false;

            //Multi-thread com muitas responsabilidades para o dev rs
            //var contasQuantidadePorThread = contas.Count() / 4;
            //var contas_parte1 = contas.Take(contasQuantidadePorThread);
            //var contas_parte2 = contas.Skip(contasQuantidadePorThread).Take(contasQuantidadePorThread);
            //var contas_parte3 = contas.Skip(contasQuantidadePorThread * 2).Take(contasQuantidadePorThread);
            //var contas_parte4 = contas.Skip(contasQuantidadePorThread * 3);

            //var resultado = ConsolidarContas(contas);

            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            var resultado = await ConsolidarContas(contas);
            var fim = DateTime.Now;
            AtualizarView(resultado, fim - inicio);
            BtnProcessar.IsEnabled = true;

            //Fazendo o async await de forma manual
            //ConsolidarContas(contas)
            //    .ContinueWith(task =>
            //    {
            //        var fim = DateTime.Now;
            //        var resultado = task.Result;
            //        AtualizarView(resultado, fim - inicio);
            //    }, taskSchedulerUI)
            //    .ContinueWith(task =>
            //    {
            //        BtnProcessar.IsEnabled = true;
            //    }, taskSchedulerUI);

            //var contasTarefas = contas.Select(conta =>
            //{
            //    //Gerenciado pelo TaskScheduler
            //    return Task.Factory.StartNew(() =>
            //    {
            //        var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
            //        resultado.Add(resultadoConta);
            //    });
            //}).ToArray(); //Esse ToArray para forçar a execução do Linq

            //Task.WhenAll(contasTarefas)
            //    .ContinueWith(task =>
            //    {
            //        var fim = DateTime.Now;
            //        AtualizarView(resultado, fim - inicio);
            //    }, taskSchedulerUI)
            //    .ContinueWith(task =>
            //    {
            //        BtnProcessar.IsEnabled = true;
            //    }, taskSchedulerUI);

            //Thread thread_parte1 = new Thread(() =>
            //{
            //    foreach (var conta in contas_parte1)
            //    {
            //        var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
            //        resultado.Add(resultadoProcessamento);
            //    }
            //});
            //Thread thread_parte2 = new Thread(() =>
            //{
            //    foreach (var conta in contas_parte2)
            //    {
            //        var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
            //        resultado.Add(resultadoProcessamento);
            //    }
            //});
            //Thread thread_parte3 = new Thread(() =>
            //{
            //    foreach (var conta in contas_parte3)
            //    {
            //        var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
            //        resultado.Add(resultadoProcessamento);
            //    }
            //});
            //Thread thread_parte4 = new Thread(() =>
            //{
            //    foreach (var conta in contas_parte4)
            //    {
            //        var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
            //        resultado.Add(resultadoProcessamento);
            //    }
            //});

            //thread_parte1.Start();
            //thread_parte2.Start();
            //thread_parte3.Start();
            //thread_parte4.Start();

            //while (thread_parte1.IsAlive || thread_parte2.IsAlive
            //    || thread_parte3.IsAlive || thread_parte4.IsAlive)
            //{
            //    Thread.Sleep(250);
            //    //Não vou fazer nada
            //}

            //Mono thread
            //foreach (var conta in contas)
            //{
            //    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
            //    resultado.Add(resultadoProcessamento);
            //}

            //var fim = DateTime.Now;
            //AtualizarView(resultado, fim - inicio);
        }

        //Aqui de forma manual
        //private Task<List<string>> ConsolidarContas(IEnumerable<ContaCliente> contas)
        //{
        //    var resultado = new List<string>();

        //    var tasks = contas.Select(conta =>
        //    {
        //        return Task.Factory.StartNew(() =>
        //        {
        //            var contaResultado = r_Servico.ConsolidarMovimentacao(conta);
        //            resultado.Add(contaResultado);
        //        });
        //    });

        //    return Task.WhenAll(tasks).ContinueWith(task =>
        //    {
        //        return resultado;
        //    });
        //}

        private async Task<string[]> ConsolidarContas(IEnumerable<ContaCliente> contas)
        {
            var tasks = contas.Select(conta => 
                Task.Factory.StartNew(() => r_Servico.ConsolidarMovimentacao(conta))
            );

            return await Task.WhenAll(tasks);
        }

        private void AtualizarView(IEnumerable<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count()} clientes em {tempoDecorrido}";
            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }
    }
}
