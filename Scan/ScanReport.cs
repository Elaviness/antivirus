using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanObjectBuilder
{
    class ScanReport
    {
        string path_to_infected_file,
               virus_name;
        int total_checked_file
        {
            get{return total_checked_file;}
            set {}
        }

        Stopwatch stop_watch = new Stopwatch();

        public ScanReport()
        {
            total_checked_file = 0;
            stop_watch.Start();
            try
            {
                scan_report_list.Clear();
            }
            catch (Exception) { };
        }

        public List<ScanReport> scan_report_list = new List<ScanReport>();

        public void Add_record(bool infecded, string path_to_infected_file, string virus_name)
        {
            if (!infecded)
                total_checked_file++;
            else
            {
                scan_report_list.Add(new ScanReport()
                {
                    path_to_infected_file = path_to_infected_file,
                    virus_name = virus_name
                });
                total_checked_file++;
            }
        }

        public string Get_time_scaning_and_complite_scaning()
        {
            stop_watch.Stop();
            TimeSpan ts = stop_watch.Elapsed;
            string elapsed_time = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Write_report_to_file(elapsed_time);
            return elapsed_time;
        }

        private void Write_report_to_file(string elapsed_time)
        {
            const string PATH_TO_REPORT_FILE = "C:\\Temp\\AntivirusReportFile.txt";
            DateTime this_day = DateTime.Today;
            try 
            { 
                using (StreamWriter sw = new StreamWriter(PATH_TO_REPORT_FILE, true, Encoding.Default))
                {
                    sw.WriteLine("Дата и время сканирования: {0}", this_day.ToString());
                    sw.WriteLine("Продолжительность сканирования: {0} Файлов просканировано: {1}, из них зараженных: {2}",
                       elapsed_time, total_checked_file, (scan_report_list.Count).ToString());
                    if (scan_report_list.Count != 0)
                    {
                        sw.WriteLine("Зараженные файлы:");
                        for (int i = 0; i < scan_report_list.Count; i++)
                        {
                            sw.WriteLine("Путь к файлу: {0} Название вируса: {1}", scan_report_list[i].path_to_infected_file, scan_report_list[i].virus_name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // добавить месседжбокс
            }
        }
    }
    
}
