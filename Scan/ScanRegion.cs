using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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

        public bool Block_split(string path) //Метод блочного чтения заданного региона
        {
            // разбить файл на регионы (делим на BLOCK_SIZE)
            // создать список регионов, являющихся экземплярами класса ScanRegion
            // читаем каждый полученный блок и вызываем проверку из SignatureIO

            const int blockSize = 1024;
            bool flag = false;
            Signature tmp = new Signature();
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
                            break;
                        }
                        flag = tmp.FindSignature(Encoding.Default.GetString(buffer));
                        if (flag)
                            return flag;
                        offset += readed;
                    }
                    return flag;
                }
                
            }
        }
    }
}
