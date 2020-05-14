using System;

namespace SignatureBase
{
    public class Signature
    {
        string name;
        int signature_length; // k символов сигнатуры (n<=k)
        int signature_prefix; // n символов сигнатуры, которые хранятся в базе для поиска вхождения
        string signature_hash; // SHA256-хэш сигнатуры
        int offset_begin; //минимальное смещение первого символа сигнатуры относительно начала
        int offset_end; //максимальное смещение оь начала файла
    }
}
