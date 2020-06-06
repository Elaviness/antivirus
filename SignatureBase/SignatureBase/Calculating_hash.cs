using System.Text;

namespace SignatureBase
{
    class Calculating_hash
    {
        public bool Check_hash(string line, string hash_record)
        {
            var msgBytes = Encoding.ASCII.GetBytes(line);

            var sha = new System.Security.Cryptography.SHA256Managed();
            var hash = sha.ComputeHash(msgBytes);

            string hash_in_hex = "";
            foreach (byte b in hash)
            {
                hash_in_hex += b.ToString("x2");
            }
            if (string.Compare(hash_in_hex, hash_record) == 0)
                return true;
            else
                return false;

        }
    }
}
