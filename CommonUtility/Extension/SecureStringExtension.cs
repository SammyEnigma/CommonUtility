using System;
using System.Runtime.InteropServices;
using System.Security;

namespace CommonUtility.Extension
{
    public static class SecureStringExtension
    {
        public static string CreateString(this SecureString secureString)
        {
            IntPtr intPtr = IntPtr.Zero;
            if (secureString == null || secureString.Length == 0)
            {
                return string.Empty;
            }
            string result;
            try
            {
                intPtr = Marshal.SecureStringToBSTR(secureString);
                result = Marshal.PtrToStringBSTR(intPtr);
            }
            finally
            {
                if (intPtr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(intPtr);
                }
            }
            return result;
        }
    }
}
