using System;
using System.Collections.Generic;

namespace SignatureBase
{
    public class Signature : IComparable<Signature>/*, IComparer<Signature>*/
    {
        public string name;
        public int signature_length; // k символов сигнатуры (n<=k)
        public string signature_prefix; // n символов сигнатуры, которые хранятся в базе для поиска вхождения
        public string signature_hash; // SHA256-хэш сигнатуры
        public int offset_begin; //минимальное смещение первого символа сигнатуры относительно начала
        public int offset_end; //максимальное смещение от начала файла
        public List<Signature> Signature_list = new List<Signature>();
        readonly Work_with_data WWD = new Work_with_data();
        public Signature() { } // конструктор

        // конструктор класса по атрибутам
        public Signature(string name, int signature_length, string signature_prefix, string signature_hash, int offset_begin, int offset_end)
        {
            this.name = name;
            this.signature_length = signature_length;
            this.signature_prefix = signature_prefix;
            this.signature_hash = signature_hash;
            this.offset_begin = offset_begin;
            this.offset_end = offset_end;

        }

        //метод класса для разбиения прочитанной строки и создания экземпляра класса
        // с последующим добавлением этого экземпляра с список 
        public void LineSplit(string line)
        {
            string[] tmp = line.Split(new char[] { ' ' });
            try
            {
                Signature_list.Add(new Signature
                {
                    name = tmp[0],
                    signature_length = Convert.ToInt16(tmp[1]),
                    signature_prefix = tmp[2],
                    signature_hash = tmp[3],
                    offset_begin = Convert.ToInt16(tmp[4]),
                    offset_end = Convert.ToInt16(tmp[5])
                });
            }
            catch (Exception) { }
        }

        //загрузка всех записей из файла в список
        public void Load_all_line_in_base()
        {
            for (int i = 0; i < System.IO.File.ReadAllLines(WWD.PATH_TO_DB_FILE).Length; i++)
            {
                LineSplit(WWD.Read_from_file_one_line(i));
            }
        }

        //Использует алгоритм двоичного поиска для нахождения определенного элемента в отсортированном списке
        public int Find_prefix(string region) 
        {
            int size = Signature_list.Count,
                low = 0,
                high = size - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (region.Contains(Signature_list[mid].signature_prefix.ToString()))
                    return mid;
                else
                    if (region.CompareTo(Signature_list[mid].signature_prefix) < 0)
                {
                    low = mid + 1;
                }
                    else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        //метод для сортировки списка бд (.Sort())
        public int CompareTo(Signature other)                                    //   Этот метод использует Array.Sort, который применяет сортировку гибридности следующим образом:
        {                                                                        //   Если размер секции меньше 16 элементов или равен ему, он использует алгоритм сортировки вставки.
            return signature_prefix.CompareTo(other.signature_prefix);           //   Если количество секций превышает 2 log n, где n — диапазон входного массива, используется алгоритм хеапсорт.
        }                                                                        //   В противном случае используется алгоритм QuickSort.

        ////доп. метод по сравнению элементов для бинарного поиска
        //public int Compare(Signature x, Signature y)
        //{
        //    return x.signature_prefix.CompareTo(y.signature_prefix);
        //}
    }
}
