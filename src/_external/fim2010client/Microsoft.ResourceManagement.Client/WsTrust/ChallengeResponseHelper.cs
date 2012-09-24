using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    public static class ChallengeResponseHelper
    {
        public static string ConvertBase64StringToString(string base64String)
        {
            byte[] encodedHash = Convert.FromBase64String(base64String);
            return System.Text.UnicodeEncoding.Unicode.GetString(encodedHash);
        }
        public static string BuildResponseData(Dictionary<int, String> answers)
        {
            List<byte> response = new List<byte>();
            String responseStringEncoded = String.Empty;
            foreach (KeyValuePair<int, String> answer in answers)
            {
                response.AddRange(StringToByte(answer.Key.ToString()));
                response.AddRange(StringToByte("\n"));
                response.AddRange(sha256encrypt(Normalize(answer.Value)+ "\0"));
                response.AddRange(StringToByte("\n"));
            }
            return Convert.ToBase64String(response.ToArray());
        }

        public static string Normalize(string answer)
        {
            return answer.Replace(" ", "").ToLowerInvariant();
        }

        public static byte[] StringToByte(string s)
        {
            return System.Text.UnicodeEncoding.Unicode.GetBytes(s);
        }


        public static byte[] sha256encrypt(string phrase)
        {

            SHA256Managed sha256hasher = new SHA256Managed();

            byte[] hashedDataBytes = sha256hasher.ComputeHash(StringToByte(phrase));
            return hashedDataBytes;
        }
    }
}
