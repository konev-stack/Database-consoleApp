using System;
using System.Data.SqlClient;


namespace Database
{
    class Register : Program
    {
        public static void RegisterMethod()
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            Console.Clear();
            //connecting to database
            //----------------------------------------------------------------
            cn = new SqlConnection(@"Data Source=DESKTOP-S9IOSM5\KONEVSQLSERVER;Initial Catalog=KonevSQL;Integrated Security=True");
            cn.Open();
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
            //confirming password
            //----------------------------------------------------------------
            Console.Write("Confirm password:");
            string conPassword = Console.ReadLine();
            if (String.IsNullOrEmpty(conPassword))
            {
                Console.Clear();
                Console.WriteLine("Please enter a value");
                Console.WriteLine(" ");
                goto username;
            }
            //----------------------------------------------------------------
            if (conPassword == password)
            {
                cmd = new SqlCommand("select * from LoginTable where username='" + username + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    Console.WriteLine("Account with that username already exists");
                    Thread.Sleep(1500);
                    Console.Clear();
                    goto username;
                }

                else
                {
                    dr.Close();
                    cmd = new SqlCommand("insert into LoginTable values(@username,@password)", cn);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);
                    cmd.ExecuteNonQuery();
                    Console.Clear();
                    Console.WriteLine("Your account was created.");
                    Thread.Sleep(1500);
                    Console.Clear();

                    Program.Main();
                }

            }
            else
            {
                Console.WriteLine("Please enter both passwords same");
                Thread.Sleep(1500);
                Console.Clear();
                Program.Main();
            }
        }

    }
}
