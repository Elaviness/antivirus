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
        int sigment_size, //Размер сегмента
            scan_offset_begin; //Смещение относительно начала контента

        const int BLOCK_SIZE = 8 * 1024; // 1 кбайт

        //IObjectContent IOC = new IObjectContent(); //Объект IObjectContent

        public ScanRegion()
        {

        }

        public bool Block_read(string path, Signature signature, ref string virus_name) //Метод блочного чтения заданного региона
        {
            // разбить файл на регионы (делим на BLOCK_SIZE)
            // создать список регионов, являющихся экземплярами класса ScanRegion
            // читаем каждый полученный блок и вызываем проверку из SignatureIO

            const int blockSize = 4*1024;
            bool flag = false;
            //Crypting function
            byte[] buffer = new byte[blockSize];

            using (var f = File.OpenRead(path))
            {
                while (true)
                {
                    int readed;
                    int offset;
                    for (offset = 0; offset < blockSize;)
                    {
                        readed = f.Read(buffer, offset, blockSize - offset);
                        if (readed == 0) // End of file
                        {
                            return flag; ;
                        }
                        flag = signature.FindSignature(Encoding.Default.GetString(buffer), ref virus_name);
                        if (flag)
                            return flag;
                        offset += readed;
                    }
                    
                }
                // return flag;
            }
        }

        public bool blockSplitZip(string path, Signature signature, ref string virus_name) //Метод блочного чтения и проверки Zip-архива
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
                                // Console.WriteLine(entry.Name);
                                string tmp_str;
                                int blockSize = 4*1024;
                                char[] tmp = new char[blockSize];
                                int offset = 0;
                                int readed = buffer.Read(tmp, offset, blockSize);
                                while (readed > 0)
                                {
                                    for (offset = 0; offset < blockSize;)
                                    {
                                        readed = buffer.Read(tmp, offset, blockSize - offset);
                                        if (readed == 0) // End of file
                                        {
                                            return false;
                                        }
                                        tmp_str = new string(tmp);
                                        flag = signature.FindSignature(tmp_str, ref virus_name);
                                        if (flag)
                                           return flag;
                                        offset += readed;
                                    }
                                    //Console.WriteLine(tmp);
                                    //offset += readed;
                                    //readed = buffer.Read(tmp, offset, blockSize - offset);
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
