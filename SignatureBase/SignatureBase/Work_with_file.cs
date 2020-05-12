using System;
using System.IO;

namespace SignatureBase
{
	public class Work_with_data
	{
		public string SIGNATURE_DB_FILE_NAME = "SignatureDB.txt",
			PATH_TO_DB_FILE;

		public Work_with_data()
		{
			this.PATH_TO_DB_FILE = Path.Combine(Directory.GetCurrentDirectory(), SIGNATURE_DB_FILE_NAME);
		}

		public void Write_to_file(string virus_name, int signature_length, int signature_prefix, string signature_hash, int offset_bigin, int offset_end)
        {
			string text = virus_name + signature_length.ToString() + signature_prefix.ToString() + signature_hash + offset_bigin.ToString() + offset_end.ToString();
			using (BinaryWriter writer = new BinaryWriter(File.Open(PATH_TO_DB_FILE, FileMode.OpenOrCreate)))
            {                 
				writer.Write(text);
            }
        }

		public string Read_from_file_one_line(int number_line)
        {
			try
			{
				return File.ReadLines(SIGNATURE_DB_FILE_NAME).Skip(number_line).Take(1);

			} catch (FileNotFoundException)
            {
				return "-1";
            }
        }
	}
}