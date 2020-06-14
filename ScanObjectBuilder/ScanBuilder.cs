using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scan;
using SignatureBase;

namespace Scan
{
    public class ScanBuilder
    {
        public bool Object_builder(string path_to_file, Signature sgntr, ref string virus_name)
        {
            CheckFile chck_file = new CheckFile(path_to_file);
            ScanObject scanObject = new ScanObject();
            if (chck_file.IsFilePE())
            {
                return scanObject.Block_read(1, path_to_file, sgntr, ref virus_name);// flag = 1;
            }
            else
            {
                if (chck_file.IsFileZip())
                {
                    return scanObject.Block_read(2, path_to_file, sgntr, ref virus_name);
                }
                else
                {
                    if (chck_file.IsFileDir())
                    {
                        Object_builder_for_dir(path_to_file, sgntr, ref virus_name);
                        return false;
                    }
                    else
                        return false;
                }
            }
        }


        private void Object_builder_for_dir(string path_to_dir, Signature sgntr, ref string virus_name)
        {
            string[] array_path_to_all_file = SearchFileInDirectory.Get_all_file_path_in_directory(path_to_dir);
            for (int i = 0; i < array_path_to_all_file.Length; i++)
            {
                Object_builder(array_path_to_all_file[i], sgntr, ref virus_name);
            }
        }
    }
}
