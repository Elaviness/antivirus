using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public class ScanRegion
    {
        int sigment_size, //Размер сегмента
            scan_offset_begin; //Смещение относительно начала контента

        IObjectContent IOC = new IObjectContent(); //Объект IObjectContent

        ScanRegion()
        {

        }

        public void Block_split(string path) //Метод блочного чтения заданного региона
        {

        }




    }
}
