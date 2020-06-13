using System;
using System.IO;
using SignatureBase;


namespace SignatureBase
{
    class Program
    {
        static void Main()
        {
            Signature my_sign = new Signature();
            // Console.WriteLine("До сортировки по префиксу");
            // string wm_str = "";

            my_sign.LineSplit("Petya 6 hello jshgdfjsygdvhd 1 10");
            my_sign.LineSplit("Alesha 6 wo jshgdfjsygdvhd 1 10");
            my_sign.LineSplit("Zinaida 6 aloha jshgdfjsygdvhd 1 10");
            my_sign.LineSplit("Cactus 6 aut jshgdfjsygdvhd 1 10");
            my_sign.LineSplit("AMware 15 Pugacheva bd075f82293b04a2061c925220dde350b16b43e9d01198f8d692266fd8040c33 40000 48576");


            //Console.WriteLine("Результат проверки файла:");
            //string tmp = "wehjoniuowowisvuosi jhrgiu";
            //bool flag;

            //// циклический посимвольный поиск
            //wm_str= my_sign.Find_prefix(tmp);
            //while (wm_str == "" && tmp != "")
            //{
            //    tmp = tmp.Substring(1);
            //    wm_str = my_sign.Find_prefix(tmp);
            //}
            //if (wm_str != "")
            //    Console.WriteLine("Префикс сигнатуры: {0}", wm_str);
            //else
            //    Console.WriteLine("Не найдено");

            Scan.ScanRegion my = new Scan.ScanRegion();
            string path = @"C:\Users\Masha\Desktop\test.zip";
            Scan.CheckFile my_path = new Scan.CheckFile(path);
            bool result = my_path.IsFileZip();

            if (result)
            {
                result = my.blockSplitZip(path, my_sign); // 

                if (result)
                {
                    Console.WriteLine("Файл заражен");
                }
                else
                    Console.WriteLine("Вредоносные сигнатуры не обнаружены");
            }
            else
                Console.WriteLine("Not execute file");

            Console.ReadKey();


        }
 
    }
}
