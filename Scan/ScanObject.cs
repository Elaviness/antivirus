using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    class ScanObject
    {
        string file_name, //для файлов имя файла
               file_path; //путь до объекта

        bool start_scan_object = false, //флаги, сигнализирующие о начале и конце файла
             end_scan_object = false,  // ..
             start_object_region = false, //флаги, сигнализирующие о начале и конце блока 
             end_object_region = false; // ..

        List<ScanRegion> region_list = new List<ScanRegion> { }; //Список регионов ScanRegion для сканирования
        //Список подобъектов

        ScanObject(){}


        void Block_read()
        {
            //Cначала метод возвращает регионы для сканирования самого объекта, 
            //затем рекурсивно применяется ко всем дочерним объектам. 
            //Метод должен сигнализировать о начале и конце объекта, о начале и 
            //конце каждого региона, о начале и конце каждого дочернего подобъекта


            // Directory.GetFiles
            // SearchFile
        }
    }
}
