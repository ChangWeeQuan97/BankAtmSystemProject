using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAtmSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            float balance = 10000, require_balance = 20, Login_Attempt = 3, withdraw_limit = 9980, withdraw, deposit;
            float[] Quick_Option = { 100, 200, 300, 500, 1000, 2000, 5000 };
            string pin = "333666";
            
            while (true)
            {
                Bank();
                Console.Write("Enter Your Card No: ");
                bool check = int.TryParse(Console.ReadLine(), out int cardno);

                if (check == false)
                {
                    OnlyNumber();
                }
                else
                {
                    Console.Write("Enter Your 6 Digit Pin No: ");
                    string old_pin = Console.ReadLine(); 
                    bool checking = int.TryParse(old_pin, out int oldpin);

                    if (checking == false)
                    {
                        OnlyNumber();
                    }
                    else
                    {
                        if (cardno != 123456789 || old_pin != pin)
                        {
                            Login_Attempt--; 

                            if (Login_Attempt == 0 )
                            {
                                Console.WriteLine($"\nInvalid Card No or Pin No.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Login failure, Please try again later");
                                Console.ResetColor();
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine($"\nInvalid Card No or Pin No.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"<-Login UnSuccessful->");
                                Console.WriteLine($"Attempt Available: {Login_Attempt}");
                                Console.ResetColor();
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            if (cardno == 123456789 && old_pin == pin)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("<-Login Successful->");
                                Login_Attempt = 3;
                                while (true)
                                {
                                    Bank();
                                    Console.WriteLine("1. Balance Inquiry");
                                    Console.WriteLine("2. Withdrawal ");
                                    Console.WriteLine("3. Fast Cash Withdrawal ");
                                    Console.WriteLine("4. Deposit ");
                                    Console.WriteLine("5. Change Pin ");
                                    Console.WriteLine("6. Cancel ");
                                    Console.Write("Enter Your Option:");

                                    string menu = Console.ReadLine();
                                    Console.Clear();

                                    if (menu == "1")
                                    {
                                        Balance_Inquiry();
                                        Console.WriteLine("\nCurrent Balance is RM " + balance);
                                        PrintforUser();
                                    }
                                    else if (menu == "2")
                                    {
                                        while (true)
                                        {
                                            Withdraw();
                                            Console.WriteLine("\nPlease enter the Withdrawal Amount: \t  Back (press 1 to back) ");
                                            check = float.TryParse(Console.ReadLine(), out withdraw);

                                            if (check == false)
                                            {
                                                OnlyNumber();
                                            }
                                            else
                                            {
                                                if (withdraw > balance)
                                                {
                                                    Console.WriteLine($"\nYour available balance is RM {balance}.");
                                                    Insufficient_Balance();
                                                    break;
                                                }
                                                else
                                                {
                                                    if (balance <= require_balance || withdraw > withdraw_limit)
                                                    {
                                                        Console.WriteLine($"\nCan't Withdraw {withdraw}, your available balance is RM {balance}.");
                                                        Require_balance();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        if (withdraw > 1 && withdraw < 10)
                                                        {
                                                            Min_Withdraw();
                                                        }
                                                        else if (withdraw == 1)
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                        else if (withdraw < 1)
                                                        {
                                                            Negative_No();
                                                        }
                                                        else
                                                        {
                                                            Continue();
                                                            if (Console.ReadLine() == "1")
                                                            {
                                                                balance = balance - withdraw;
                                                                withdraw_limit = withdraw_limit - withdraw;
                                                                AfterProcess();
                                                                Console.WriteLine("Current Balance is RM " + balance);
                                                                Print();

                                                                if (Console.ReadLine() == "1")
                                                                {
                                                                    Print_Receipt();
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    Console.Clear();
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (menu == "3")
                                    {
                                        while (true)
                                        {
                                            Fast_Cash();
                                            string FastWithdraw = Console.ReadLine();
                                            Console.Clear();

                                            if (FastWithdraw == "1")
                                            {
                                                if (Quick_Option[0] > balance)
                                                {
                                                    Console.WriteLine($"Can't Withdraw {Quick_Option[0]}, your available balance is RM {balance}.");
                                                    Insufficient_Balance();
                                                }
                                                else
                                                {
                                                    if (balance < 120 || Quick_Option[0] > withdraw_limit)
                                                    {
                                                        Console.WriteLine($"Can't Withdraw {Quick_Option[0]}, your available balance is RM {balance}.");
                                                        Require_balance();
                                                    }
                                                    else
                                                    {
                                                        balance = balance - Quick_Option[0];
                                                        withdraw_limit = withdraw_limit - Quick_Option[0];
                                                        Console.WriteLine($"You have select the Option 1 to withdraw RM {Quick_Option[0]}. ");
                                                        AfterProcess();
                                                        Console.WriteLine("Current Balance is RM " + balance);
                                                        Print();

                                                        if (Console.ReadLine() == "1")
                                                        {
                                                            Print_Receipt();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (FastWithdraw == "2")
                                            {
                                                if (Quick_Option[1] > balance)
                                                {
                                                    Console.WriteLine($"Can't Withdraw {Quick_Option[1]}, your available balance is RM {balance}.");
                                                    Insufficient_Balance();
                                                }
                                                else
                                                {
                                                    if (balance < 220 || Quick_Option[1] > withdraw_limit)
                                                    {
                                                        Console.WriteLine($"Can't Withdraw {Quick_Option[1]}, your available balance is RM {balance}.");
                                                        Require_balance();
                                                    }
                                                    else
                                                    {
                                                        balance = balance - Quick_Option[1];
                                                        withdraw_limit = withdraw_limit - Quick_Option[1];
                                                        Console.WriteLine($"You have select the Option 2 to withdraw RM {Quick_Option[1]}. ");
                                                        AfterProcess();
                                                        Console.WriteLine("Current Balance is RM " + balance);
                                                        Print();

                                                        if (Console.ReadLine() == "1")
                                                        {
                                                            Print_Receipt();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (FastWithdraw == "3")
                                            {
                                                if (Quick_Option[2] > balance)
                                                {
                                                    Console.WriteLine($"Can't Withdraw {Quick_Option[2]}, your available balance is RM {balance}.");
                                                    Insufficient_Balance();
                                                }
                                                else
                                                {
                                                    if (balance < 320 || Quick_Option[2] > withdraw_limit)
                                                    {
                                                        Console.WriteLine($"Can't Withdraw {Quick_Option[2]}, your available balance is RM {balance}.");
                                                        Require_balance();
                                                    }
                                                    else
                                                    {
                                                        balance = balance - Quick_Option[2];
                                                        withdraw_limit = withdraw_limit - Quick_Option[2];
                                                        Console.WriteLine($"You have select the Option 3 to withdraw RM {Quick_Option[2]}. ");
                                                        AfterProcess();
                                                        Console.WriteLine("Current Balance is RM " + balance);
                                                        Print();

                                                        if (Console.ReadLine() == "1")
                                                        {
                                                            Print_Receipt();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (FastWithdraw == "4")
                                            {
                                                if (Quick_Option[3] > balance)
                                                {
                                                    Console.WriteLine($"Can't Withdraw {Quick_Option[3]}, your available balance is RM {balance}.");
                                                    Insufficient_Balance();
                                                }
                                                else
                                                {
                                                    if (balance < 520 || Quick_Option[3] > withdraw_limit)
                                                    {
                                                        Console.WriteLine($"Can't Withdraw {Quick_Option[3]}, your available balance is RM {balance}.");
                                                        Require_balance();
                                                    }
                                                    else
                                                    {
                                                        balance = balance - Quick_Option[3];
                                                        withdraw_limit = withdraw_limit - Quick_Option[3];
                                                        Console.WriteLine($"You have select the Option 4 to withdraw RM {Quick_Option[3]}. ");
                                                        AfterProcess();
                                                        Console.WriteLine("Current Balance is RM " + balance);
                                                        Print();

                                                        if (Console.ReadLine() == "1")
                                                        {
                                                            Print_Receipt();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (FastWithdraw == "5")
                                            {
                                                if (Quick_Option[4] > balance)
                                                {
                                                    Console.WriteLine($"Can't Withdraw {Quick_Option[4]}, your available balance is RM {balance}.");
                                                    Insufficient_Balance();
                                                }
                                                else
                                                {
                                                    if (balance < 1020 || Quick_Option[4] > withdraw_limit)
                                                    {
                                                        Console.WriteLine($"Can't Withdraw {Quick_Option[4]}, your available balance is RM {balance}.");
                                                        Require_balance();
                                                    }
                                                    else
                                                    {
                                                        balance = balance - Quick_Option[4];
                                                        withdraw_limit = withdraw_limit - Quick_Option[4];
                                                        Console.WriteLine($"You have select the Option 5 to withdraw RM {Quick_Option[4]}. ");
                                                        AfterProcess();
                                                        Console.WriteLine("Current Balance is RM " + balance);
                                                        Print();

                                                        if (Console.ReadLine() == "1")
                                                        {
                                                            Print_Receipt();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (FastWithdraw == "6")
                                            {
                                                if (Quick_Option[5] > balance)
                                                {
                                                    Console.WriteLine($"Can't Withdraw {Quick_Option[5]}, your available balance is RM {balance}.");
                                                    Insufficient_Balance();
                                                }
                                                else
                                                {
                                                    if (balance < 2020 || Quick_Option[5] > withdraw_limit)
                                                    {
                                                        Console.WriteLine($"Can't Withdraw {Quick_Option[5]}, your available balance is RM {balance}.");
                                                        Require_balance();
                                                    }
                                                    else
                                                    {
                                                        balance = balance - Quick_Option[5];
                                                        withdraw_limit = withdraw_limit - Quick_Option[5];
                                                        Console.WriteLine($"You have select the Option 6 to withdraw RM {Quick_Option[5]}. ");
                                                        AfterProcess();
                                                        Console.WriteLine("Current Balance is RM " + balance);
                                                        Print();

                                                        if (Console.ReadLine() == "1")
                                                        {
                                                            Print_Receipt();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (FastWithdraw == "7")
                                            {
                                                if (Quick_Option[6] > balance)
                                                {
                                                    Console.WriteLine($"Can't Withdraw {Quick_Option[6]}, your available balance is RM {balance}.");
                                                    Insufficient_Balance();
                                                }
                                                else
                                                {
                                                    if (balance < 5020 || Quick_Option[6] > withdraw_limit)
                                                    {
                                                        Console.WriteLine($"Can't Withdraw {Quick_Option[6]}, your available balance is RM {balance}.");
                                                        Require_balance();
                                                    }
                                                    else
                                                    {
                                                        balance = balance - Quick_Option[6];
                                                        withdraw_limit = withdraw_limit - Quick_Option[6];
                                                        Console.WriteLine($"You have select the Option 7 to withdraw RM {Quick_Option[6]}. ");
                                                        AfterProcess();
                                                        Console.WriteLine("Current Balance is RM " + balance);
                                                        Print();

                                                        if (Console.ReadLine() == "1")
                                                        {
                                                            Print_Receipt();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (FastWithdraw == "8")
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Invalid_Option();
                                            }
                                        }
                                    }
                                    else if (menu == "4")
                                    {
                                        while (true)
                                        {
                                            Deposit();
                                            Console.WriteLine("\nPlease enter the Deposit Amount: \t  Back (press 1 to back)");
                                            check = float.TryParse(Console.ReadLine(), out deposit);

                                            if (check == false)
                                            {
                                                OnlyNumber();
                                            }
                                            else
                                            {
                                                if (deposit>1 && deposit < 10)
                                                {
                                                    Min_Deposit();
                                                }
                                                else if (deposit==1)
                                                {
                                                    Console.Clear(); 
                                                    break;
                                                }
                                                else if (deposit < 1)
                                                {
                                                    Negative_No();
                                                }
                                                else
                                                {
                                                    Continue();
                                                    if (Console.ReadLine() == "1")
                                                    {
                                                        balance = balance + deposit;
                                                        withdraw_limit = withdraw_limit + deposit;
                                                        AfterProcess_Deposit();
                                                        Console.WriteLine("Current Balance is RM " + balance);
                                                        Print();

                                                        if (Console.ReadLine() == "1")
                                                        {
                                                            Print_Receipt();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (menu == "5")
                                    {
                                        while (true)
                                        {
                                            Renew_Pin();
                                            Console.WriteLine("\nEnter Your old Pin No: \t  Back (press 1 to back)");
                                            string currentpin = Console.ReadLine();
                                            check = int.TryParse(currentpin, out int current_pin);

                                            if (check == false)
                                            {
                                                OnlyNumber();
                                            }
                                            else if (current_pin == 1)
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                if (currentpin != pin)
                                                {
                                                    Incorrect_Pin();
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Enter Your New Pin No: ");
                                                    string newpin = Console.ReadLine();
                                                    check = int.TryParse(newpin, out int new_pin);

                                                    if (check == false)
                                                    {
                                                        OnlyNumber();
                                                    }
                                                    else if (new_pin<0)
                                                    {
                                                        Negative_No();
                                                    }
                                                    else if (newpin == pin)
                                                    {
                                                        Console.WriteLine("\nCan't change to the old pin no.  ");
                                                        PrintforUser();
                                                    }
                                                    else
                                                    {
                                                        if (newpin == "1")
                                                        {
                                                            Console.WriteLine("\nPin No can't be 1 digit");
                                                            PrintforUser();
                                                        }
                                                        else
                                                        {
                                                            pin = newpin;
                                                            Change_Pin();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (menu == "6")
                                    {
                                        Console.Write("Hope you enjoy our service, ");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("Thank You !\n");
                                        Console.ResetColor();
                                        PrintforUser();
                                        break;
                                    }
                                    else
                                    {
                                        Invalid_Option();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void PrintforUser()
        {
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void AfterProcess()
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("\nProcessing Successful");
            Console.ResetColor();
            Console.WriteLine("Please take your cash. ");
        }
        public static void AfterProcess_Deposit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProcessing Successful");
            Console.ResetColor();
        }
        public static void Change_Pin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPin No change successful");
            Console.ResetColor();
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Require_balance()
        {
            Console.WriteLine("Minimum required balance is RM20. ");
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Insufficient_Balance()
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("Sorry! Insufficient Balance.");
            Console.ResetColor();
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Incorrect_Pin()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nIncorrect Pin No");
            Console.ResetColor();
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Invalid_Option()
        {
            Console.WriteLine("Invalid Option");
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void OnlyNumber()
        {
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.WriteLine("\nEnter Numbers Only.");
            Console.ResetColor();
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Bank()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("\n       Welcome to GE LEGACY BANK ATM SERVICE\n ");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.ResetColor();
        }
        public static void Fast_Cash()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("          Fast Cash Withdrawal ");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.ResetColor();
            Console.WriteLine("1. RM100 \t 5.RM1000");
            Console.WriteLine("2. RM200 \t 6.RM2000 ");
            Console.WriteLine("3. RM300 \t 7.RM5000 ");
            Console.WriteLine("4. RM500 \t 8. Back ");
            Console.Write("Enter Your Option:");
        }
        public static void Balance_Inquiry()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("            Balance Inquiry ");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.ResetColor();
            
        }
        public static void Withdraw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                Withdrawal ");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.ResetColor();

        }
        public static void Deposit()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("                Deposit ");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.ResetColor();

        }
        public static void Renew_Pin()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("              Renew Pin No ");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.ResetColor();
        }
        public static void Min_Deposit()
        {
            Console.WriteLine("\nMinimum deposit amount is RM10. ");
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Min_Withdraw()
        {
            Console.WriteLine("\nMinimum withdrawal amount is RM10. ");
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Negative_No()
        {
            Console.WriteLine("\nCan't insert negative number. ");
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Print()
        {
            Console.WriteLine("\nDo you need any receipt?");
            Console.WriteLine("1. Yes\t 2. No");
            Console.Write("Enter Your Option: ");
        }
        public static void Continue()
        {
            Console.WriteLine("\nDo you want to continue? ");
            Console.WriteLine("1. Yes\t2. No");
            Console.Write("Enter Your Option: ");
        }
        public static void Print_Receipt()
        {
            Console.Clear();
            Console.WriteLine("Your receipt is printing succesfully, please take your receipt. ");
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
