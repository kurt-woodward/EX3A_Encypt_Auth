using System;

namespace EX3A_Encypt_Auth
{
    class Input //: SHA256
    {
        private static string UserSelection { get; set; }
        public static string Username { get; set; }
        public static string HashedPassword { get; set; }
        
        public static void Menu()
        {
            Console.WriteLine("MENU:\n\nPlease make a selection:\n1) Change password\n2) Authenticate User\n3) Exit application");

            try
            {
                UserSelection = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(UserSelection)) 
                {
                    throw new FormatException();
                }


            int userSelection = int.Parse(UserSelection);

            if (userSelection == 1)
            {
                Console.WriteLine("Enter username:");
                Username = Entries(Console.ReadLine());

                Console.WriteLine("Enter new password:");
                string plainText = Entries(Console.ReadLine());

                HashedPassword = Hasher.CreateHash(plainText);

                if (!Credentials.creds.ContainsKey(Username))
                {
                    Credentials.creds.TryAdd(Username, HashedPassword);
                    Console.WriteLine("New user account created");
                }
                else
                {
                    Credentials.creds[Username] = HashedPassword;

                    if (Credentials.creds[Username] == HashedPassword)
                    {
                        Console.WriteLine("Password successfully changed");
                    }
                }

                Menu();
            }
            else if (userSelection == 2)
            {
                Console.WriteLine("Enter username:");
                Username = Entries(Console.ReadLine());
                
                Console.WriteLine("Enter password:");
                string plainText = Entries(Console.ReadLine());

                HashedPassword = Hasher.CreateHash(plainText);

                if (Credentials.creds.ContainsKey(Username) && Credentials.authCheck(Username, HashedPassword))
                {
                    Console.WriteLine($"Welcome, {Username}");
                }
                else
                {
                    Console.WriteLine($"Username and password combination could not be found. Please try again.");
                    Menu();

                }

                Program.Terminate();
            }
            else if (userSelection == 3)
            {
                Program.Terminate();
            }
            else
            {
                throw new FormatException();
            }

            }
            catch (FormatException)
            {
                Console.WriteLine("Selection was not valid, please try again");
                Menu();
            }
        }

        public static string Entries(string userInput)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userInput) == false)
                {
                    return userInput;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Input not valid. Please try again.");
                userInput = Console.ReadLine();
                Menu();
            }
            return userInput;
        }
    }
}
