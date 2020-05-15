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

            my_sign.LineSplit("Alesha 6 world jshgdfjsygdvhd 1 10");

            my_sign.LineSplit("Zinaida 6 aloha jshgdfjsygdvhd 1 10");

            foreach (Signature i in my_sign.Signature_list)
            {
                Console.WriteLine("Имя вируса: {0}\t Префикс: {1}", i.name, i.signature_prefix);
            }
            Console.WriteLine();
            Console.WriteLine("После сортировки по префиксу");

            my_sign.Signature_list.Sort();

            foreach (Signature i in my_sign.Signature_list)
            {
                Console.WriteLine("Имя вируса: {0}\t Префикс: {1}", i.name, i.signature_prefix);
            }

            Console.WriteLine();
            Console.WriteLine("Индекс записи с префиксом \"word\": {0}", my_sign.Find_prefix("world"));
          

            Console.ReadKey();
        }
    }
}
