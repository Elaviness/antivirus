using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scan;
using SignatureBase;

namespace Scan
{
    public class ScanBuilder
    {
        public Dictionary<string, string> infected_files = new Dictionary<string, string>();
        ScanReport scn_report;
        ScanObject scanObject = new ScanObject();
        string not_a_virus = "";

        public ScanBuilder(ScanReport scn_report)
        {
            this.scn_report = scn_report;
        }

        public bool Object_builder(string path_to_file, Signature sgntr, ref string virus_name, ref string path_to_infected_file)
        {
            CheckFile chck_file = new CheckFile(path_to_file);
           
            if (chck_file.IsFilePE())
            {
                if (scanObject.Block_read(1, path_to_file, sgntr, ref virus_name, ref path_to_infected_file))
                {
                    infected_files.Add(path_to_infected_file, virus_name);
                    return true;
                }
                else
                {
                    scn_report.Add_record(false, not_a_virus, not_a_virus);
                    return false;// flag = 1;
                }
            }
            else
            {
                if (chck_file.IsFileZip())
                {
                    if (scanObject.Block_read(2, path_to_file, sgntr, ref virus_name, ref path_to_infected_file))
                    {
                        infected_files.Add(path_to_infected_file, virus_name);
                        return true;
                    }
                    else
                    {
                        scn_report.Add_record(false, not_a_virus, not_a_virus);
                        return false;
                    }
                }
                else
                {
                    if (chck_file.IsFileDir())
                    {
                        Object_builder_for_dir(path_to_file, sgntr, ref virus_name, ref path_to_infected_file);
                        return false;
                    }
                    else
                    {
                        scn_report.Add_record(false, not_a_virus, not_a_virus);
                        return false;
                    }
                }
            }
        }


        private void Object_builder_for_dir(string path_to_dir, Signature sgntr, ref string virus_name, ref string path_to_infected_file)
        {
            string[] array_path_to_all_file = SearchFileInDirectory.Get_all_file_path_in_directory(path_to_dir);
            for (int i = 0; i < array_path_to_all_file.Length; i++)
            {
                Object_builder(array_path_to_all_file[i], sgntr, ref virus_name, ref path_to_infected_file);
            }
        }
    }
}
