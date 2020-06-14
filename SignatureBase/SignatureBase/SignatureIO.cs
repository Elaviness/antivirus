using System;
using System.Collections.Generic;
using System.Linq;
using BinarySearchTree;

namespace SignatureBase
{
    public class Signature : IComparable<Signature>
    {
        public string name;
        public int signature_length; // k символов сигнатуры (n<=k)
        public string signature_prefix; // n символов сигнатуры, которые хранятся в базе для поиска вхождения
        public string signature_hash; // SHA256-хэш сигнатуры
        public int offset_begin; //минимальное смещение первого символа сигнатуры относительно начала
        public int offset_end; //максимальное смещение от начала файла
        private Dictionary<string, Signature> signature_dict; //словарь для хранения Ключа-Префикса и Значения-Экземпляра класса
        private Tree tree = new Tree();
        readonly Work_with_data wwd;

        public Signature() { }
        public Signature(int i) // конструктор
        {

            wwd  = new Work_with_data();
            signature_dict = new Dictionary<string, Signature>();
            wwd.Read_from_file();
            if (wwd.virus_base[0] != "-1")
            {
                foreach (string line in wwd.virus_base)
                {
                    LineSplit(line);
                }
            }
            return;
        } 

        //метод класса для разбиения прочитанной строки и создания экземпляра класса
        // с последующим добавлением этого экземпляра с словарь и сохранением префикса в узле бинарного дерева
        public void LineSplit(string line)
        {
            string[] tmp = line.Split(new char[] { ' ' });
            try
            {
                signature_dict.Add(tmp[2], new Signature
                {
                    name = tmp[0],
                    signature_length = Convert.ToInt32(tmp[1]),
                    signature_prefix = tmp[2],
                    signature_hash = tmp[3],
                    offset_begin = Convert.ToInt32(tmp[4]),
                    offset_end = Convert.ToInt32(tmp[5])
                });
                tree.Add(tmp[2]);
            }
            catch (Exception ex) {}
        }


        //Использует алгоритм двоичного поиска для нахождения определенного элемента в отсортированном списке
        private string Find_prefix(string region, Signature signature) 
        {
            string find_signature = "", empty = "";
            Node current = signature.tree.Root;
            for (int i = 0; i < region.Length;)
            {
                if (current.Data.CompareTo(region[i])==0)
                {
                    find_signature += current.Data;
                    if (current.End)
                        return find_signature;
                    i++;
                    current = current.Equal;
                }
                else
                {
                    if (region[i] < current.Data)
                        current = current.Left;
                    else
                        if (region[i] > current.Data)
                        current = current.Right;
                }
                if (current == null)
                    break;
            }
            return empty;
        }

        public bool FindSignature(string tmp, Signature signature,ref string virus_name)
        {
            string buffer = tmp, to_hash_line = ""; 
            string wm_str = Find_prefix(tmp, signature);
            while (wm_str == "" && tmp != "")
            {
                tmp = tmp.Substring(1);
                wm_str = Find_prefix(tmp,signature);
            }
            if (wm_str != "") //добавить сверку хэша найденного фрагмента и сигнатуры
            {
                if (signature_dict.TryGetValue(wm_str, out var value))
                {   
                    if (tmp.Length >= value.signature_length)
                    {
                        for (int i = 0; i < value.signature_length; i++)
                            to_hash_line += tmp[i];

                        Calculating_hash calc_hash = new Calculating_hash();
                        if (calc_hash.Check_hash(to_hash_line, value.signature_hash))
                        {
                            virus_name = value.name;
                            return true;
                        }
                        else
                            return false;                       
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }


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
