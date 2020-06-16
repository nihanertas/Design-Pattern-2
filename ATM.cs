using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cPro2
{
    class ATM
    {
        BankDatabase bankDatabase;
        CashDispenser cashDispenser;
        int currentAccountNumber;
        DepositSlot depositSlot;
        Keypad keypad;
        Screen screen;
        bool userAuthenticated;
        private const int BalanceInqıry = 1;
        private const int WithDrawal = 2;
        private const int Deposit = 3;
        private const int Exit = 4;
        public ATM()
        {
            userAuthenticated = false;
            currentAccountNumber = 0;
            screen = new Screen();
            keypad = new Keypad();
            depositSlot = new DepositSlot();
            bankDatabase = new BankDatabase();
            cashDispenser = new CashDispenser(0, 0);
        }
        public void AuthenticateUser()
        {
            screen.DisplayMessage("\nP lease enter account number");
            int AccountNumber = keypad.GetInput();
            screen.DisplayMessage("\n Please enter your pin");
            int Pin = keypad.GetInput();
            userAuthenticated = bankDatabase.authenticateUser(AccountNumber, Pin);
            if (!userAuthenticated)
            {
                currentAccountNumber = AccountNumber;            
            }           
        }
        public Transaction CreateTransaction(int input)
        {
            Transaction temp = null;
            switch (input)
            {
                case BalanceInqıry:
                    temp = new Balancelnquiry(currentAccountNumber, screen, bankDatabase);
                    break;
                case WithDrawal:
                    temp = new WithDrawal(currentAccountNumber, screen, bankDatabase, keypad, cashDispenser);
                    break;
                case Deposit:
                    temp = new Deposit(currentAccountNumber, screen, bankDatabase, keypad, depositSlot);
                    break;
            }
            return temp;
        }
        public void PerformTransaction()
        {
            Transaction currentTransaction = null;
            bool Userexit = false;
            while (!Userexit)
            {
                int MenuSelect = SelectMenu();
                switch (MenuSelect)
                {
                    case BalanceInqıry:
                    case WithDrawal:
                    case Deposit:
                        currentTransaction = CreateTransaction(MenuSelect);
                        currentTransaction.Execute();
                        break;
                    case Exit:
                        screen.DisplayMessageLine("Exit!");
                        Userexit = true;
                        break;
                    default:
                        screen.DisplayMessageLine("Please select again !\n\n");
                        break;
                }
            }
        }
        public void Run()
        {
            while (true)
            {
                while (!userAuthenticated)
                {
                    screen.DisplayMessageLine("Welcome !");
                    AuthenticateUser();
                    break;
                }

                PerformTransaction();
                userAuthenticated = false;
                currentAccountNumber = 0;
                screen.DisplayMessageLine("Goodbye !");
            }
        }
        public int SelectMenu()
        {
            screen.DisplayMessage("********Welcome to ATM Service**************\n");
            screen.DisplayMessage("1. Check Balance\n");
            screen.DisplayMessage("2. Withdraw Cash\n");
            screen.DisplayMessage("3. Deposit Cash\n");
            screen.DisplayMessage("4. Quit\n");
            screen.DisplayMessage("*********************************************\n\n");
            screen.DisplayMessage("Enter your choice: ");
            return keypad.GetInput();
        }
    }
}
