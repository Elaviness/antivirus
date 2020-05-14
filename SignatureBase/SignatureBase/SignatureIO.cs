using System;
using System.Collections.Generic;

namespace SignatureBase
{
    public class Signature
    {
        public string name;
        public int signature_length; // k символов сигнатуры (n<=k)
        public string signature_prefix; // n символов сигнатуры, которые хранятся в базе для поиска вхождения
        public string signature_hash; // SHA256-хэш сигнатуры
        public int offset_begin; //минимальное смещение первого символа сигнатуры относительно начала
        public int offset_end; //максимальное смещение от начала файла
        public List<Signature> Signature_list = new List<Signature>();

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
        public void  LineSplit(string line)
        {
            string[] tmp = line.Split(new char[] {' '});
            try
            {
                Signature_list.Add(new Signature { name=tmp[0], signature_length = Convert.ToInt16(tmp[1]), signature_prefix = tmp[2], signature_hash = tmp[3], offset_begin = Convert.ToInt16(tmp[4]), offset_end = Convert.ToInt16(tmp[5]) } );
            }
            catch (Exception) {}
        }
    }
}
