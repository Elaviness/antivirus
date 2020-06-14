using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignatureBase;

namespace Scan
{
    public class ScanObject
    {
        string file_name, //для файлов имя файла
               file_path; //путь до объекта

        bool start_scan_object = false, //флаги, сигнализирующие о начале и конце файла
             end_scan_object = false,  // ..
             start_object_region = false, //флаги, сигнализирующие о начале и конце блока 
             end_object_region = false; // ..


        List<ScanRegion> region_list = new List<ScanRegion> { }; //Список регионов ScanRegion для сканирования
        //Список подобъектов

        public ScanObject() { }


        public bool Block_read(int type, string path, Signature sgntr, ref string virus_name)
        {
            bool result = false;
            ScanRegion scanRegion = new ScanRegion();
            List<string> zip_list = new List<string> { };
            switch (type)
            {
                case 1:
                    result = scanRegion.Block_read(path, sgntr, ref virus_name);
                    return result;
                case 2: // сохраняет список всех элементов в архиве и для каждого вызывает блочное чтение
                    return scanRegion.blockSplitZip(path, sgntr, ref virus_name);
            }
            return false;
        }

            void IObjectContent.Size_object()
        {

        }
    }
}
