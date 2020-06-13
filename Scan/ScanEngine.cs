using SignatureBase;
using ScanObjectBuilder;

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
            string[] path_to_all_file = SearchFileInDirectory.Get_all_file_path_in_directory(this.path_to_file);
            if (path_to_all_file[0] == "-1") // нам передали ссылку на файл
            {
                Scaning(path_to_file);
            }
            else    // передан путь к папке
            {
                for (int i = 0; i < path_to_all_file.Length; i++)
                {
                    Scaning(path_to_all_file[i]);
                }
            }
            scaning_time = scn_report.Get_time_scaning();
        }

        private void Scaning(string path_to_file)
        {
            CheckFile my_path = new CheckFile(path_to_file);
            bool result = my_path.IsFilePE();
            if (result)   // PE
            {
                result = scn_region.Block_split(path_to_file, sgntr);
                if (result) // файл заражен
                {
                    scn_report.Add_record(result, path_to_file, "");  //!!!!!! добавить имя вируса !!!!!!!
                }
                else
                {
                    scn_report.Add_record(result, "", "");
                }
            }
            else     // not PE
            {
                scn_report.Add_record(result, "", "");
            }
        }
    }
}
