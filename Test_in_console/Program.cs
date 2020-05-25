using System;

namespace SignatureBase
{
    class Program
    {
        static void Main()
        {
            Signature my_sign = new Signature();
            Console.WriteLine("До сортировки по префиксу");

            my_sign.LineSplit("Petya 6 hello jshgdfjsygdvhd 1 10");

            my_sign.LineSplit("Alesha 6 wo jshgdfjsygdvhd 1 10");

            my_sign.LineSplit("Zinaida 6 aloha jshgdfjsygdvhd 1 10");

            foreach (Signature i in my_sign.signature_list)
            {
                Console.WriteLine("Имя вируса: {0}\t Префикс: {1}", i.name, i.signature_prefix);
            }
            Console.WriteLine();
            Console.WriteLine("После сортировки по префиксу");


            foreach (Signature i in my_sign.signature_list)
            {
                Console.WriteLine("Имя вируса: {0}\t Префикс: {1}", i.name, i.signature_prefix);
            }

            Console.WriteLine();
            Console.WriteLine("Индекс записи с префиксом \"rl\": {0}", my_sign.Find_prefix(""));
            Console.ReadKey();
        }
    }
}
