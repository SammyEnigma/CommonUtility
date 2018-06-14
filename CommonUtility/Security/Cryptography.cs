using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CommonUtility.Extension;

namespace CommonUtility.Security
{
    public class Cryptography : IDisposable
    {
        private Encoding _encoding;
        private HashAlgorithm _hashAlgorithm;

        private Cryptography(HashAlgorithm hashAlgorithm, Encoding encoding)
        {
            _hashAlgorithm = hashAlgorithm;
            _encoding = encoding;
        }

        public static Cryptography Create()
        {
            return Create(MD5.Create(), Encoding.UTF8);
        }

        public static Cryptography Create(HashAlgorithm hashAlgorithm, Encoding encoding)
        {
            return new Cryptography(hashAlgorithm, encoding);
        }

        public HashAlgorithm HashAlgorithm
        {
            get => _hashAlgorithm ?? (_hashAlgorithm = MD5.Create());
            set => _hashAlgorithm = value;
        }

        public Encoding Encoding
        {
            get => _encoding ?? (_encoding = Encoding.UTF8);
            set => _encoding = value;
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

        public void Dispose()
        {
            _hashAlgorithm?.Dispose();
        }
    }
}