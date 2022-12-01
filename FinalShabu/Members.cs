using System;
using System.Collections;
using System.Collections.Generic;
class Members
    {
        Hashtable member_list = new Hashtable();
        int status = 0 ;
        public void add_member()
        {
            bool flag = true ;
            while(flag) //register method
            {
                Console.Clear();
                Console.Write("Enter your name : ");
                string name = Console.ReadLine();
                Console.Write("Enter your Password : ");
                string pass = Console.ReadLine();

                try
                {
                    member_list.Add(name , pass);
                    Console.WriteLine("\nRegister successful, please login again to enter the system\nPress any key to main menu.");
                    string exitCase = Console.ReadLine();
                    flag = false;
                }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error plese try again!");
                        Console.WriteLine("\nPress 0 to cancel register.\nPress Enter to register again.");
                        string exit = Console.ReadLine(); //test
                        if (exit == "0")
                        {
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                        }
                    
                    }
            }
        }
        public void show_member() //case 2 show members
        {
            Console.Clear();
            Console.Write("\nAre you admin ? \n(1) Yes \n(2) No\n");
            string input_admin = Console.ReadLine();
            int admin;
            int.TryParse(input_admin , out admin);
            
            switch (admin)
            {
                case 1 : 
                {
                    foreach (string key in member_list.Keys)
                        {
                            Console.WriteLine("(Name : "+key+" , Pass : "+member_list[key]+")");
                        }
                        break;
                }
                case 2 :
                {
                    Console.Clear();
                    Console.WriteLine("\nYou must be an admin to view member list.");
                    break;
                }
            }
            
        
        }
        public void login() //login case 3
        {
            bool login_check = true;
            while (login_check)
            {

                Console.Write("Enter your name (press 0 to cancel): ");
                string login_name = Console.ReadLine();
                Console.Write("Enter your Password : ");
                string login_password = Console.ReadLine();
                string pass_check ;
                pass_check = Convert.ToString(member_list[login_name]);
                if (member_list.ContainsKey(login_name))
                    {
                    if ( login_password == pass_check ) 
                        {
                            Console.WriteLine("================\nLog in successful.\n================");
                            status = 1;
                            login_check = false;
                            Console.WriteLine("\nPress any key to continue.");
                            string exitCase = Console.ReadLine();
                        }
                        else 
                        {
                            Console.WriteLine("Your password is incorrect.");
                            Console.WriteLine("\nPress any key to continue.");
                            string exitCase = Console.ReadLine();
                        }
                    }
                    else if (login_name == "0")
                        {
                            login_check = false;
                        }
                        else
                        {
                            Console.WriteLine("Your username is not found.");
                            Console.WriteLine("\nPress any key to continue.");
                            string exitCase = Console.ReadLine();
                    }
            }
        }
        public int is_login()
        {
            return status;
        }
        public void logout()
        {
            status = 0;
            Console.Clear();
            Console.WriteLine("Logout successful.");
        }
    }