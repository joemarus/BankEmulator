using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessAroundConsole
{
    class BankAccount
    {
        public string holder;
        private int balance;

        public BankAccount()
        {
            holder = "-Unkown-";
            balance = 0;
        }
        public BankAccount(string newHolder)
        {
            holder = newHolder;
        }
        public BankAccount(string newHolder, int initialBalance)
        {
            holder = newHolder;
            balance = initialBalance;
        }
        public string PrintBalance()
        {
            string str = String.Format("{0}, your account balance is {1:C}", holder, balance);
            return str;
        }
        public bool Withdraw(int withdrawal)
        {
            if (withdrawal > balance)
            {
                Console.WriteLine();
                Console.WriteLine("YOU HAVE INSUFICIENT FUNDS");
                return false;
            }
            else
            {
                balance = balance - withdrawal;
                Console.WriteLine("WITHDRAW COMPLETE");
                return true;
            }
        }
        public void Deposit(int deposit)
        {
            balance = balance + deposit;
            Console.WriteLine("DEPOSIT COMPLETE");
        }
    }
    /// <summary>
    /// Program designed to emulate a simple bank account system
    /// </summary>
    class Program
    {
        /// <summary>
        /// Our Main section where our program starts and keeps returning to
        /// until the user choses to exit.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            PrintMenu(); // Looks for the function called PrintMenu which is below and runs it
            Console.WriteLine();
            Console.WriteLine("LET'S OPEN AN ACCOUNT.");
            Console.Write("WHO IS THE ACCOUNT HOLDER? ");
            string name = Console.ReadLine();
            Console.Write("HOW MUCH MONEY WOULD YOU LIKE IN YOUR ACCOUNT: ");
            int yourBalance = Int32.Parse(Console.ReadLine()); // Sets our starting balance

            // We are going to create a new object of the BankAccount class that we defined 
            // up above.  We will use one of the constructors to set both the name of the
            // account holder and the balance at the same time.
            BankAccount account = new BankAccount(name, yourBalance); 

            // Here we start our program loop so that it keeps running as it will always 
            // return true. Below we give an option for the user to choose which breaks
            // out of the loop
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("CHECK BALANCE (1)");
                Console.WriteLine("WITHDRAW MONEY (2)");
                Console.WriteLine("DEPOSIT MONEY (3)");
                Console.WriteLine("EXIT (4)");
                Console.WriteLine();
                Console.Write("WHAT WOULD YOU LIKE TO DO (1, 2, 3 or 4): ");
                int yourChoice = Int32.Parse(Console.ReadLine());

                if (yourChoice == 1)
                {
                    CheckBalance(account); // This sends our object which was created 
                    // above to a function called CheckBalance that
                    // is written below
                }

                if (yourChoice == 2)
                {
                    Withdraw(account); // This is slightly different to the one
                    // above as this one sends our object to 
                    // the function called Withdraw that is written below. The function
                    // doesn't return anything.  The balance is updated internally inside
                    // the account object.
                }

                if (yourChoice == 3)
                {
                    Deposit(account); // Does the same thing as documented for
                    // withdraw excepts sends it to a different
                    // function / method
                }

                if (yourChoice == 4)
                {
                    break; // Ends the program
                }

                else
                {
                    continue; // If any other number is selected it restarts
                }

            }

        }


        /// <summary>
        /// Prints a welcome screen. This is only called at the start of the program.
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine("##########################################################");
            Console.WriteLine("##########################################################");
            Console.WriteLine("#######                                            #######");
            Console.WriteLine("#######                    WELCOME                 #######");
            Console.WriteLine("#######                                            #######");
            Console.WriteLine("##########################################################");
            Console.WriteLine("##########################################################");
        }

        /// <summary>
        /// This function / method calls another method on the BankAccount object
        /// that we passed in.  The object holds both the balance and the account
        /// holder's name.  The method on the BankAccount object returns a string
        /// that we print on the console here.
        /// 
        /// </summary>
        /// <param name="acct"></param>
        static void CheckBalance(BankAccount acct)
        {
            Console.WriteLine();
            Console.WriteLine(acct.PrintBalance());
        }

        /// <summary>
        /// This function / method takes the account object that is sent to it,
        /// asks how much the user would like to withdraw, and then calls a method
        /// called Withdraw on the object to do the withdrawal.  The object's method
        /// returns a boolean value, which is either true or false.  We use an "if"
        /// statement to see if it returned false, then we can print an extra message.
        /// We don't have to return anything to the main program because the account
        /// object has the balance inside of it.
        /// </summary>
        /// <param name="acct"></param>
        /// <returns></returns>
        static void Withdraw(BankAccount acct)
        {
            Console.WriteLine();
            Console.Write("HOW MUCH DO YOU WISH TO WITHDRAW: ");
            int withdrawAmnt = Int32.Parse(Console.ReadLine());
            if (!acct.Withdraw(withdrawAmnt))
            {
                Console.WriteLine("THE TRANSACTION FAILED!");
            }
        }

        /// <summary>
        /// This function / method takes the object sent to it from the Main program
        /// (the BankAcount object) and asks how much the user would like to
        /// deposit. It then calls the Deposit method on the object.  That method 
        /// does not return anything, and we don't return anything to the main program.
        /// The balance is stored inside the object.
        /// </summary>
        /// <param name="acct"></param>
        /// <returns></returns>
        static void Deposit(BankAccount acct)
        {
            Console.WriteLine();
            Console.Write("HOW MUCH DO YOU WISH TO DEPOSIT: ");
            int depositAmnt = Int32.Parse(Console.ReadLine());
            acct.Deposit(depositAmnt);
        }



    }
}