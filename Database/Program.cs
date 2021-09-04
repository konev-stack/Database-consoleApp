using System;
using System.Data.SqlClient;


namespace Database
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("press 1 for login");
            Console.WriteLine("press 2 for register");
            char inputChar = Console.ReadKey().KeyChar;
            if (inputChar == '1')
            {
                Login.LoginMethod();
            }
            else if (inputChar == '2')
            {
                Register.RegisterMethod();
            }
        }
    }
}