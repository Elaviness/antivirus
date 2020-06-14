using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SignatureBase
{
	public class Work_with_data
	{

		public string signature_db_file_name = "SignatureDB.txt", path_to_db_file;
		public List<string> virus_base = new List<string>();
		public Work_with_data()
		{
			path_to_db_file = Path.Combine(Directory.GetCurrentDirectory(), signature_db_file_name);
		}

		public void Write_to_end_file(string virus_name, int signature_length, int signature_prefix, string signature_hash, int offset_bigin, int offset_end)
		{
			string text = virus_name + " " + signature_length.ToString() + " " + signature_prefix.ToString() + " " +
				signature_hash + " " + offset_bigin.ToString() + " " + offset_end.ToString();
			try
			{
				using (StreamWriter writer = new StreamWriter(path_to_db_file, true, System.Text.Encoding.Default))
				{
					writer.WriteLine(text);
				}
			} catch (Exception)
			{ }
			
		}


		public List<string> Read_from_file()
		{

			string line;
			try
			{
				using (StreamReader sr = new StreamReader(path_to_db_file, Encoding.Default))
				{
					while ((line = sr.ReadLine()) != null)
					{
						virus_base.Add(line);
					}
					return virus_base;
				}
			}
			catch (Exception)
			{
				virus_base.Add("-1");
				return virus_base;
			}
		}

	}
}