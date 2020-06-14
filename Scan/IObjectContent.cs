using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
{
    public interface IObjectContent
    {

        void Size_object(); //Метод получения размера содержимого


        bool Block_read(int type, string path); //Метод блочного чтения данных с заданной позиции, 
                           //Метод должен возвращать количество реально прочитанных байт
    }
}
