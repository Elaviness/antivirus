using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public class SearchFileInDirectory
    {
        public static string[] Get_all_file_path_in_directory(string pathToDirectory)
        {
            string[] array_file_in_path = Search_file(pathToDirectory, "*.*");
            return array_file_in_path;
        }


        private static string[] Search_file(string patch, string pattern)
        {
            try
            {
                string[] reult_search = Directory.GetFiles(patch, pattern, SearchOption.AllDirectories);
                return reult_search;
            }
            catch (Exception e)
            {
                // add messagebox
                string[] reult_search = { "-1" };
                return reult_search;
            }
        }

        
            

    }
}
