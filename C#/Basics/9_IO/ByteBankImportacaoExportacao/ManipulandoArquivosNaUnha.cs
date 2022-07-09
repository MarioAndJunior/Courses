using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        private static void ManipulandoBufferNaMao()
        {
            var caminhoDoArquivo = "C:\\Temp\\contas.txt";
            using (var fluxoDoArquivo = new FileStream(caminhoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024];
                var tamanhoLido = -1;

                while (tamanhoLido != 0)
                {
                    tamanhoLido = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, tamanhoLido);
                }
            }
        }

        static void EscreverBuffer(byte[] buffer, int tamanhoLido)
        {
            var encoding = Encoding.UTF8;
            Console.Write(encoding.GetString(buffer, 0, tamanhoLido));

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }
}