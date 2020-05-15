using System;

namespace SignatureBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Signature my_sign = new Signature();
            my_sign.LineSplit("Petya 6 hello jshgdfjsygdvhd 1 10");

            my_sign.LineSplit("Vasya 6 world jshgdfjsygdvhd 1 10");

            my_sign.LineSplit("Alesha 6 aloha jshgdfjsygdvhd 1 10");

            my_sign.Signature_list.Sort();
            Console.WriteLine(my_sign.Find_prefix("world"));

            Console.ReadKey();
        }
    }
}
