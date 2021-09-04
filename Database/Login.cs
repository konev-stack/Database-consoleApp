using System;
using System.Data.SqlClient;


namespace Database
{
    class Login
    {
        public static void LoginMethod()
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            Console.Clear();
        //entering username    
        //----------------------------------------------------------------
        username:
            Console.Write("Enter username:");
            string username = Console.ReadLine();
            if (String.IsNullOrEmpty(username))
            {
                Console.Clear();
                Console.WriteLine("Please enter a value");
                Console.WriteLine(" ");
                goto username;
            }
            //entering password
            //----------------------------------------------------------------
            Console.Write("Enter password:");
            string password = Console.ReadLine();
            if (String.IsNullOrEmpty(password))
            {
                Console.Clear();
                Console.WriteLine("Please enter a value");
                Console.WriteLine(" ");
                goto username;
            }
            cn = new SqlConnection(@"Data Source=DESKTOP-S9IOSM5\KONEVSQLSERVER;Initial Catalog=KonevSQL;Integrated Security=True");
            cn.Open();
            cmd = new SqlCommand("select * from LoginTable where username='" + username + "' and password='" + password + "'", cn);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                Console.Clear();
                Console.WriteLine("Great job! You logged in.");
            }
            else
            {
                dr.Close();
                Console.Clear();
                Console.WriteLine("Wrong credentials");
                Console.WriteLine(" ");
                Program.Main();
            }
        }
    }
}
