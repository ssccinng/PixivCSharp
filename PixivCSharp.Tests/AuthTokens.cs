using System.IO;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        //Temporary methods for storing tokens for testing, not to be used in actual applications.
        
        public static void StoreTokens(string tokens)
        {
            using (StreamWriter sw = File.CreateText("tokens.txt"))
            {
                sw.Write(tokens);
            }
        }

        public static void ReadTokens()
        {
            string tokenString;
            using (StreamReader sr = File.OpenText("tokens.txt"))
            {
                tokenString = sr.ReadToEnd();
            }

            string[] tokens = tokenString.Split(",");
            Client.SetTokens(tokens[0], tokens[1], tokens[2]);
        }
    }
}