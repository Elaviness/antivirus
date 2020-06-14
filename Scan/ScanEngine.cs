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

        public void Start_scaning()
        {
            scaning_time = scn_report.Get_time_scaning_and_complite_scaning();
        }

       
    }
}
