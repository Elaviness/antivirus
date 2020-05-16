using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    class ScanObject
    {
        string FILE_NAME; //для файлов имя файла
        string FILE_PATH; //путь до объекта
        List<ScanRegion> Region_list = new List<ScanRegion> { }; //Список регионов ScanRegion для сканирования
        //Список подобъектов

        ScanObject()
        {

        }

        void Block_read()
        {
            //Cначала метод возвращает регионы для сканирования самого объекта, 
            //затем рекурсивно применяется ко всем дочерним объектам. 
            //Метод должен сигнализировать о начале и конце объекта, о начале и 
            //конце каждого региона, о начале и конце каждого дочернего подобъекта

        }
    }
}
