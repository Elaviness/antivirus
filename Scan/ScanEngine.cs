using SignatureBase;
using System.Collections.Generic;

namespace Scan
{
    public class ScanEngine
    {
        string scaning_time {get { return scaning_time; } set { } }
        string path_to_file;

        int count_infected_file { get; set; }
        int count_scaning_file { get; set; }

        public ScanEngine(string path_to_file)
        {
            this.path_to_file = path_to_file;
            count_infected_file = 0;
            count_scaning_file = 0;
        }

        public void Start_scaning(Signature sgntr)
        {
            string virus_name = "",
                   path_to_infected_file = "";
            ScanReport scn_report = new ScanReport();
            ScanBuilder scanBuilder = new ScanBuilder(scn_report);

            scanBuilder.Object_builder(this.path_to_file, sgntr, ref virus_name, ref path_to_infected_file);
            Add_infected_file_to_report(scanBuilder, scn_report);
            scaning_time = scn_report.Get_time_scaning_and_complite_scaning();
            count_infected_file = scanBuilder.infected_files.Count;
            count_scaning_file = scn_report.total_checked_file;
        }

        private void Add_infected_file_to_report(ScanBuilder scanBuilder, ScanReport scn_report)
        {
            foreach (KeyValuePair<string, string> record in scanBuilder.infected_files)
            {
                scn_report.Add_record(true, record.Key, record.Value);
            }
        }       
    }
}
