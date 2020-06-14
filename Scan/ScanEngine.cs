using SignatureBase;

namespace Scan
{
    public class ScanEngine
    {
        string scaning_time {get { return scaning_time; } set { } }
        string path_to_file;

        ScanReport scn_report = new ScanReport();
        ScanRegion scn_region = new ScanRegion();
        Signature sgntr = new Signature();

        public ScanEngine(string path_to_file)
        {
            this.path_to_file = path_to_file;
        }

        public void Start_scaning(string path_to_file, Signature sgntr)
        {

            string virus_name = "",
                   path_to_infected_file = "";



            ScanBuilder scanBuilder = new ScanBuilder();
            scanBuilder.Object_builder(path_to_file, sgntr, ref virus_name, ref path_to_infected_file)
            scaning_time = scn_report.Get_time_scaning_and_complite_scaning();
        }

       
    }
}
