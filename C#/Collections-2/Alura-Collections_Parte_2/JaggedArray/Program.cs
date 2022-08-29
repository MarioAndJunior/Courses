using System;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // família 1: Família Flintstones
            // família 2: Família Simpsons
            // família 3: Família Dona Florinda


            // Jagged Array (array serrilhado)
            string[][] familias = new string[3][];
            //{
            //    { "Fred", "Wilma", "Pedrita" }.
            //    { "Homer", "Marge", "Lisa", "Bart", "Maggie" },
            //    { "Florina", "Kiko" }
            //};

            familias[0] = new string[] { "Fred", "Wilma", "Pedrita" };
            familias[1] = new string[] { "Homer", "Marge", "Lisa", "Bart", "Maggie" };
            familias[2] = new string[] { "Florina", "Kiko" };

            foreach (var familia in familias)
            {
                Console.WriteLine(string.Join(',', familia));
            }
        }
    }
}
