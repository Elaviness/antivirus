using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanObjectBuilder
{
    public class ScanBuilder
    {
        public bool Object_builder(string path_to_file)
        {
            CheckFile chck_file = new CheckFile(path_to_file);
            int flag;
            if (chck_file.IsFilePE())
                flag = 1;
            else
            {
                if (chck_file.IsFileZip())
                    flag = 2;
                else
                    flag = 3;
            }
            
            
        }

     
    }
}
