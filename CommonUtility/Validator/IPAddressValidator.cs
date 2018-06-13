using System.Text.RegularExpressions;

namespace CommonUtility.Validator
{
    public class IPAddressValidator
    {
        public static bool IsValidIPv4(string ip)
        {
            const string ipPattern =
                "^((?:(?:25[0-5]|2[0-4]\\d|[01]?\\d?\\d)\\.){3}(?:25[0-5]|2[0-4]\\d|[01]?\\d?\\d))$";
            return Regex.IsMatch(ip, ipPattern);
        }

        public static bool IsValidPort(string port)
        {
            return ushort.TryParse(port, out _);
        }
    }
}