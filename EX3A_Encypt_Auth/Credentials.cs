using System.Collections.Generic;

namespace EX3A_Encypt_Auth
{
    class Credentials
    {
        public static string Key { get;  set; }
        public static string Value { get; set; }
        //string key = Key;
        //string value = Value;


        public static Dictionary<string, string> creds = new Dictionary<string, string>()
        {
            // test users and passwords
            { "admin", Hasher.CreateHash("happy") },
            { "user1", Hasher.CreateHash("birthday") },
            { "user2", Hasher.CreateHash("to me") }
        
        };
        
        public static bool authCheck(string key, string value)
        {
            return creds.ContainsKey(key) && creds[key] == value;
        }
    }
}
