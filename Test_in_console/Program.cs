using System;

namespace SignatureBase
{
    class Program
    {
        static void Main()
        {
            Signature my_sign = new Signature();
            Console.WriteLine("До сортировки по префиксу");
            string wm_str = "";

            my_sign.LineSplit("Petya 6 hello jshgdfjsygdvhd 1 10");
            my_sign.LineSplit("Alesha 6 wo jshgdfjsygdvhd 1 10");
            my_sign.LineSplit("Zinaida 6 aloha jshgdfjsygdvhd 1 10");
            my_sign.LineSplit("Cactus 6 aut jshgdfjsygdvhd 1 10");

            //foreach (Signature i in my_sign.signature_list)
            //{
            //    Console.WriteLine("Имя вируса: {0}\t Префикс: {1}", i.name, i.signature_prefix);
            //}
            //Console.WriteLine();
            //Console.WriteLine("После сортировки по префиксу");


            //foreach (Signature i in my_sign.signature_list)
            //{
            //    Console.WriteLine("Имя вируса: {0}\t Префикс: {1}", i.name, i.signature_prefix);
            //}

            //Console.WriteLine();
            Console.WriteLine("Результат проверки файла:");
            string tmp = "wehjoniuowowisvuosi jhrgiu";
            bool flag;
            wm_str= my_sign.Find_prefix(tmp);
            while (wm_str == "" && tmp != "")
            {
                tmp = tmp.Substring(1);
                wm_str = my_sign.Find_prefix(tmp);
            }
            if (wm_str != "")
                Console.WriteLine("Префикс сигнатуры: {0}", wm_str);
            else
                Console.WriteLine("Не найдено");
            Console.ReadKey();
        }
    }
}
