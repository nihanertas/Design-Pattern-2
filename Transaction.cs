using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cPro2
{
    abstract class Transaction
    {
        private int accountNumber;
        private Screen userScreen;
        private BankDatabase database;
        public Transaction(int userAccount, Screen theScreen, BankDatabase theDatabase)
        {
            accountNumber = userAccount;
            userScreen = theScreen;
            database = theDatabase;
        }
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public Screen UserScreen
        {
            get
            {
                return userScreen;
            }
        }
        public BankDatabase Database
        {
            get
            {
                return database;
            }
        }
        abstract public void Execute();
    }
    }

