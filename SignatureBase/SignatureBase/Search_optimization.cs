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
            int mid = left + (right - left) / 2; //������� �������� ������� �� ���������� �������� ������ � ���� �� 2
            if (left >= right)//�������� �������, ���� ����� ������� ������ ������, �� ������������ ��������
                return -(1 + left);

            if (d[mid] == key) //���� ���������. ��� �������� ����� �������� �������, �� ������������ ��� ��������, � ����� �����������
               return mid;

           else if (d[mid] > key)//� ��������� ������ ���� �������� ������ �������� ��������, �� ������������ � ����� ����� � ���������� ��� ��������
               return BinarySearch(d, key, left, mid);
           else
               return BinarySearch(d, key, mid + 1, right);// �����, ���� �������� ������ �������� ��������, �� ���������� ����� � ������ �����, ��� �� ���� ������ �� ��� �����

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
                    // ������� ��� �� ���������� �����
                    string fst_hash = "";  // ���������� ��� ���� � ����
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
