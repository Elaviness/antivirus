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
        public List<ScanRegion> region_list = new List<ScanRegion> { }; //Список регионов ScanRegion для сканирования
        //Список подобъектов

        public ScanObject() { }


        public bool Block_read(int type, string path, Signature sgntr, ref string virus_name, ref string path_to_infected_file)
        {
            bool result = false;
            ScanRegion scanRegion = new ScanRegion();
            List<string> zip_list = new List<string> { };
            switch (type)
            {
                case 1:
                    result = scanRegion.Block_read(path, sgntr, ref virus_name, ref path_to_infected_file);
                    return result;
                case 2: // сохраняет список всех элементов в архиве и для каждого вызывает блочное чтение
                    return scanRegion.blockSplitZip(path, sgntr, ref virus_name, ref path_to_infected_file);
            }
            return false;
        }

    }
}
