using System;
using System.IO;
using System.Threading;

namespace SignatureBase
{
    public class Search_optimization
    {
        Work_with_data WWD = new Work_with_data();
        
        public bool Log_search_signature(string hash)
        {
            WWD.Mutex_WWD.WaitOne();
            int
            int mid = left + (right - left) / 2; //находим середину вычитая из последнего элемента первый и деля на 2
            if (left >= right)//проверка условия, если левая сторона больше правой, то возвращается значение
                return -(1 + left);

            if (d[mid] == key) //если оказалось. что середина равна искомому значнию, то возвращается это значение, и поиск завершается
               return mid;

           else if (d[mid] > key)//в противном случае если середина больше искомого значения, то возвращаемся к левой части и продолжаем там алгоритм
               return BinarySearch(d, key, left, mid);
           else
               return BinarySearch(d, key, mid + 1, right);// иначе, если середина меньше искомого значения, то продолжаем поиск в правой части, так же деля массив на две части

            WWD.Mutex_WWD.ReleaseMutex();
        }

        public void Optimization_base_of_signature()
        {
            int count_line = File.ReadAllLines(WWD.PATH_TO_DB_FILE).Length;
            WWD.Mutex_WWD.WaitOne();
            string fst_line, snd_line, tmp;
            for (int i = 0; i < count_line; i++)
                for (int j = 0; j < count_line - 1; j++)
                {
                    fst_line = WWD.Read_from_file_one_line(j);
                    snd_line = WWD.Read_from_file_one_line(j + 1);
                    // выделям хэш из полученных строк
                    string fst_hash = "";  // записываем его сюда и ниже
                    string snd_hash = "";
                    if (fst_hash.CompareTo(snd_hash) > 0)
                    {
                        tmp = fst_line;
                        Line_changer(snd_line, j);
                        Line_changer(tmp, j + 1);
                    }
                }
            WWD.Mutex_WWD.ReleaseMutex();
        }

        private void Line_changer(string newText, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(WWD.PATH_TO_DB_FILE);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(WWD.PATH_TO_DB_FILE, arrLine);
        }
    }

}
