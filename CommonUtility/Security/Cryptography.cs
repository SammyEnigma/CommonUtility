using CommonUtility.Extension;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CommonUtility.Security
{
    public class Cryptography
    {
        private HashAlgorithm hashAlgorithm;
        public HashAlgorithm HashAlgorithm
        {
            get
            {
                if (hashAlgorithm == null)
                {
                    hashAlgorithm = MD5.Create();
                }
                return hashAlgorithm;
            }
            set { hashAlgorithm = value; }
        }

        private Encoding encoding;
        public Encoding Encoding
        {
            get
            {
                if (encoding == null)
                {
                    encoding = Encoding.UTF8;
                }
                return encoding;
            }
            set { encoding = value; }
        }

        public byte[] ComputeHash(string value)
        {
            return HashAlgorithm.ComputeHash(Encoding.GetBytes(value));
        }

        public byte[] ComputeHash(Stream stream)
        {
            return HashAlgorithm.ComputeHash(stream);
        }

        public string ToBase64String(string value)
        {
            return value.ToBase64String(Encoding);
        }

        public string ToBase64UrlString(string value)
        {
            return value.ToBase64UrlString(Encoding);
        }

        public string UrlEncode(string value)
        {
            return value.UrlEncode(Encoding);
        }

        public string UrlDecode(string value)
        {
            return value.UrlDecode(Encoding);
        }

    }
}
