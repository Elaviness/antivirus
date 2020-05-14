using System;
using System.IO;
using System.Threading;

namespace SignatureBase
{
    public class Search_optimization
    {
        Work_with_data WWD = new Work_with_data();
        Mutex Mutex_WWD = new Mutex(false, "Mutex_WWD");
        public void Log_search_signature(string hash)
        {

        }

        public void Optimization_base_of_signature()
        {
            int count_line = File.ReadAllLines(WWD.PATH_TO_DB_FILE).Length;
            Mutex_WWD.WaitOne();
            string fst_line, snd_line, tmp;
            for (int i = 0; i < count_line; i++)
                for (int j = 0; j < count_line - 1; j++)
                {
                    fst_line = WWD.Read_from_file_one_line(j);
                    snd_line = WWD.Read_from_file_one_line(j + 1);

                    // ������� ��� �� ���������� �����
                    string fst_hash = "";
                    string snd_hash = "";

                    if (fst_hash.CompareTo(snd_hash) > 0)
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;


                        tmp = snd_line;
                        Line_changer()

                    }
                }
            Mutex_WWD.ReleaseMutex();
        }

        void Line_changer(string newText, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(WWD.PATH_TO_DB_FILE);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }

}
