using CommonUtility.Security;
using System.Security.Cryptography;
using System.Text;

namespace CommonUtility.Extension
{
    /// <summary>
    /// <see cref="CommonUtility.Security.Cryptography"/>
    /// </summary>
    public static class CryptographyExtension
    {
        public static Cryptography SetHashAlgorithm(this Cryptography cryptography, CryptoServiceProviderType providerType)
        {
            if (cryptography.HashAlgorithm != null)
            {
                cryptography.HashAlgorithm.Clear();
            }

            switch (providerType)
            {
                default:
                case CryptoServiceProviderType.MD5:
                    cryptography.HashAlgorithm = MD5.Create();
                    break;
                case CryptoServiceProviderType.SHA1:
                    cryptography.HashAlgorithm = SHA1.Create();
                    break;
                case CryptoServiceProviderType.SHA256:
                    cryptography.HashAlgorithm = SHA256.Create();
                    break;
                case CryptoServiceProviderType.SHA384:
                    cryptography.HashAlgorithm = SHA384.Create();
                    break;
                case CryptoServiceProviderType.SHA512:
                    cryptography.HashAlgorithm = SHA512.Create();
                    break;
                case CryptoServiceProviderType.HMACMD5:
                    cryptography.HashAlgorithm = HMACMD5.Create();
                    break;
                case CryptoServiceProviderType.HMACSHA1:
                    cryptography.HashAlgorithm = HMACSHA1.Create();
                    break;
                case CryptoServiceProviderType.HMACSHA256:
                    cryptography.HashAlgorithm = HMACSHA256.Create();
                    break;
                case CryptoServiceProviderType.HMACSHA384:
                    cryptography.HashAlgorithm = HMACSHA384.Create();
                    break;
                case CryptoServiceProviderType.HMACSHA512:
                    cryptography.HashAlgorithm = HMACSHA512.Create();
                    break;
            }

            return cryptography;
        }

        public static Cryptography SetEncoding(this Cryptography cryptography, Encoding encoding)
        {
            cryptography.Encoding = encoding;
            return cryptography;
        }
    }
}
