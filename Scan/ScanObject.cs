using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    class ScanObject: IObjectContent
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


        void IObjectContent.Block_read()
        {
            //Cначала метод возвращает регионы для сканирования самого объекта, 
            //затем рекурсивно применяется ко всем дочерним объектам. 
            //Метод должен сигнализировать о начале и конце объекта, о начале и 
            //конце каждого региона, о начале и конце каждого дочернего подобъекта

           
            // Directory.GetFiles
            // SearchFile


            // 1. вызываем scan_region для разбиения на блоки (сигнал о начале и конце объекта, начало и конец региона,
            // начало и конец дочернего подобъекта)
            // ммм рекурсия
            
        }

        void IObjectContent.Size_object()
        {

        }
    }
}
