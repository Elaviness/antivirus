using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignatureBase;

namespace Scan
{
    public class ScanRegion
    {
        private const int BLOCK_SIZE = 4 * 1024; // 1 кбайт

        public ScanRegion(){}

        public bool Block_read(string path, Signature signature, ref string virus_name, ref string path_to_infected_file) //Метод блочного чтения заданного региона
        {
            // разбить файл на регионы (делим на BLOCK_SIZE)
            // создать список регионов, являющихся экземплярами класса ScanRegion
            // читаем каждый полученный блок и вызываем проверку из SignatureIO

            bool flag = false;
            //Crypting function
            byte[] buffer = new byte[BLOCK_SIZE];

            using (var f = File.OpenRead(path))
            {
                while (true)
                {
                    int readed;
                    int offset;
                    for (offset = 0; offset < BLOCK_SIZE;)
                    {
                        readed = f.Read(buffer, offset, BLOCK_SIZE - offset);
                        if (readed == 0) // End of file
                        {
                            return flag; ;
                        }
                        flag = signature.FindSignature(Encoding.Default.GetString(buffer), ref virus_name);
                        if (flag)
                        {
                            path_to_infected_file = path;
                            return flag;
                        }
                        offset += readed;
                    }
                    
                }
                // return flag;
            }
        }

        public bool blockSplitZip(string path, Signature signature, ref string virus_name, ref string path_to_infected_file) //Метод блочного чтения и проверки Zip-архива
        {
            bool flag;

            using (FileStream zipToOpen = new FileStream(path, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.Name != "" && entry.Name.EndsWith(".exe"))
                        {

                            using (StreamReader buffer = new StreamReader(entry.Open(), Encoding.Default))
                            {
                                string tmp_str;
                                char[] tmp = new char[BLOCK_SIZE];
                                int offset = 0;
                                int readed = buffer.Read(tmp, offset, BLOCK_SIZE);
                                while (readed > 0)
                                {
                                    for (offset = 0; offset < BLOCK_SIZE;)
                                    {
                                        readed = buffer.Read(tmp, offset, BLOCK_SIZE - offset);
                                        if (readed == 0) // End of file
                                        {
                                            return false;
                                        }
                                        tmp_str = new string(tmp);
                                        flag = signature.FindSignature(tmp_str, ref virus_name);
                                        if (flag)
                                        {
                                            path_to_infected_file = path;
                                            return flag;
                                        }
                                        offset += readed;
                                    }
                                }
                            }
                        }
                    }
                    return false;
                }
            }
        }
    }
}
