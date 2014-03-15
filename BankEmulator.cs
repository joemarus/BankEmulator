using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessAroundConsole
{
    class BankAccount
    {
        // This is a simple definition of a type, or class, of object
        // that represents a bank account.  You can think of an object
        // as a collection of related functions and data.

        // These are the data members of the class.  They are called
        // "fields".  One is public, and it is for storing the name of
        // the account holder.  The other is private, and that is for
        // storing the current balance of the account.
        public string holder;
        private int balance;


        // Now here are the function members of the class, and they
        // are called "methods".
        public BankAccount()
        {
            // This method that has the same name as the class
            // is a special function called the "constructor".  It
            // is called whenever a new object of this type or class
            // is created.  It is a good place to initialize the fields.
            holder = "-Unkown-";
            balance = 0;
        }
        public BankAccount(string newHolder)
        {
            // Wait a second, didn't I just create a method with
            // this same name?  This is an example of one of the
            // neat things you can do with a class called "overloading".
            // You can define more than one method with the same name
            // but as long as they have different parameters, it is ok
            // because the compiler can tell the difference.
            holder = newHolder;
            balance = 0;
        }
        public BankAccount(string newHolder, int initialBalance)
        {
            // Wow, yet another constructor method!  Having multiple
            // constructors allows the programmer freedom to create objects
            // in different ways.  In this one, I allow both the name
            // of the account holder and the initial balance to be set.
            holder = newHolder;
            balance = initialBalance;
        }
        public string PrintBalance()
        {
            // This method returns a string with a message that tells the
            // user their current balance.  The calling program cannot
            // see the balance directly because it is a private field,
            // but this method can since it is part of the class.
            string str = String.Format("{0}, your account balance is {1:C}", holder, balance);
            return str;
        }
        public bool Withdraw(int withdrawal)
        {
            // This method does a withdrawal, and it returns a bool value
            // which is simply either true or false to indicate if the
            // withdrawal was successful or not.
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
            // This method just does a simple deposit and it
            // does not return any value.
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
            int currentAcct = 0;
            BankAccount[] accounts = new BankAccount[10];
            accounts[currentAcct] = new BankAccount(name, yourBalance);

            // Here we start our program loop so that it keeps running as it will always 
            // return true. Below we give an option for the user to choose which breaks
            // out of the loop
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("HELLO, {0}", accounts[currentAcct].holder);
                Console.WriteLine();
                Console.WriteLine("CHECK BALANCE (1)");
                Console.WriteLine("WITHDRAW MONEY (2)");
                Console.WriteLine("DEPOSIT MONEY (3)");
                Console.WriteLine("USE ANOTHER ACCOUNT (4)");
                Console.WriteLine("CREATE NEW ACCOUNT (5)");
                Console.WriteLine("EXIT (0)");
                Console.WriteLine();
                Console.Write("WHAT WOULD YOU LIKE TO DO (1, 2, 3, 4, 5, or 0): ");
                int yourChoice = Int32.Parse(Console.ReadLine());

                if (yourChoice == 1)
                {
                    CheckBalance(accounts[currentAcct]); // This sends our object which was created 
                    // above to a function called CheckBalance that
                    // is written below
                }

                if (yourChoice == 2)
                {
                    Withdraw(accounts[currentAcct]); // This is slightly different to the one
                    // above as this one sends our object to 
                    // the function called Withdraw that is written below. The function
                    // doesn't return anything.  The balance is updated internally inside
                    // the account object.
                }

                if (yourChoice == 3)
                {
                    Deposit(accounts[currentAcct]); // Does the same thing as documented for
                    // withdraw excepts sends it to a different
                    // function / method
                }

                if(yourChoice == 4)
                {
                    currentAcct = ChooseAccount(accounts);
                }

                if(yourChoice == 5)
                {
                    int temp = CreateAccount(accounts);
                    if (temp >= 0)
                    {
                        currentAcct = temp;
                    }
                }

                if (yourChoice == 0)
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

        static int ChooseAccount(BankAccount[] accounts)
        {
            Console.WriteLine();
            for (int i = 0; i<10; i++)
            {
                if (accounts[i] != null)
                {
                    Console.WriteLine("{0} - {1}", i, accounts[i].holder);
                }
            }
            Console.Write("\nChoose an account to use: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static int CreateAccount(BankAccount[] accounts)
        {
            bool IsEmpty = false;
            int i;
            for ( i = 0; i < 10; i++)
            {
                if (accounts[i] == null)
                {
                    IsEmpty = true;
                    break;
                }
            }
            if (IsEmpty )
            {
                Console.Write("WHO IS THE ACCOUNT HOLDER? ");
                string name = Console.ReadLine();
                Console.Write("HOW MUCH MONEY WOULD YOU LIKE IN YOUR ACCOUNT: ");
                int yourBalance = Int32.Parse(Console.ReadLine()); // Sets our starting balance
                accounts[i] = new BankAccount(name, yourBalance);
                return i;
            }
            else
            {
                Console.WriteLine("\nSorry, there is no more room left in the bank.");
                return -1;
            }
        }

    }
}