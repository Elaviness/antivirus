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
            Work_with_data WWD = new Work_with_data();

            WWD.Write_to_file("wef", 5, 5, "regewrgerge", 5, 5);
        }
    }
}
