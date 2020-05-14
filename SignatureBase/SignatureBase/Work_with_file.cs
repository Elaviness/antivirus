using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SignatureBase
{
	public class Work_with_data
	{
		public Mutex Mutex_WWD = new Mutex(false, "Mutex_WWD");
		public string SIGNATURE_DB_FILE_NAME = "SignatureDB.txt", PATH_TO_DB_FILE;



		public Work_with_data()
		{
			PATH_TO_DB_FILE = Path.Combine(Directory.GetCurrentDirectory(), SIGNATURE_DB_FILE_NAME);
		}

		public void Write_to_end_file(string virus_name, int signature_length, int signature_prefix, string signature_hash, int offset_bigin, int offset_end)
        {

			string text = virus_name + " " + signature_length.ToString()+ " " + signature_prefix.ToString() + " " +
				signature_hash + " " + offset_bigin.ToString() + " " + offset_end.ToString();
			using (StreamWriter writer = new StreamWriter(PATH_TO_DB_FILE, true, System.Text.Encoding.Default))
			{
				writer.WriteLine(text);
			}
		}


		public string Read_from_file_one_line(int number_line)
        {
			try
			{ 
				return File.ReadLines(PATH_TO_DB_FILE).ElementAt(number_line); ;
			} 
			catch (Exception)
            {
				return "-1";
            }
        }


		public void Write_in_file_in_line()
		{
			
		}
	}
}