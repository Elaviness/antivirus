using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan
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

        ScanReport()
        {
            total_checked_file = 0;
            try
            {
                scan_report_list.Clear();
            } catch (Exception) { };
        }

        List<ScanReport> scan_report_list = new List<ScanReport>();

        public void Add_record(bool infecded, string path_to_infected_file, string virus_name)
        {
            if (!infecded)
                total_checked_file++;
            else
            {
                scan_report_list.Add(new ScanReport() { path_to_infected_file = path_to_infected_file,
                    virus_name = virus_name});
                total_checked_file++;
            }
        }


        
    }
}
