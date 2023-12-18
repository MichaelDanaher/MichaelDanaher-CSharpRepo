using System;

namespace Program
{
    class Login
    {
        static string UsrName = "a";
        static string UsrPass = "a";

        static void Main()
            {
                
            while (UsrName != "Admin" || UsrPass != "Password")
            {
                Console.Write("Enter your username: ");
                UsrName = Console.ReadLine();
                Console.Write("Enter your password: ");
                UsrPass = Console.ReadLine();
                if (UsrName != "Admin" || UsrPass != "Password")
                {
                    Console.WriteLine("Failed, try again");
                }
            }
            if (UsrName == "Admin" && UsrPass == "Password")
            {
                Console.WriteLine("Success!");
            }
        }
    }
}
