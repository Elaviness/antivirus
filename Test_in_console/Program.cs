using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Signature my_sign = new Signature();
            my_sign.LineSplit("virus 5 hello jshgdfjsygdvhd 1 10");
            string fst = "zxc";
            string snd = "abc";

            Console.WriteLine(fst.CompareTo(snd));
            foreach (var itm in my_sign.Signature_list)
            {
                Console.WriteLine(itm.name);
            }
            Console.ReadKey();
        }
    }
}
