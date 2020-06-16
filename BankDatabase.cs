using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cPro2
{
    class BankDatabase
    {
        Account[] accounts;
        public BankDatabase()
        {
            accounts = new Account[3];
            accounts[0] = new Account(417860, 1453, 1000, 2000);
            accounts[1] = new Account(150101, 1903, 5000, 100000);
            accounts[2] = new Account(130215, 318, 10000, 2000000);
        }
        public bool authenticateUser(int userAccountNumber, int userPin)
        {
            Account userAccount = GetAccount(userAccountNumber);
            if (userAccount != null)
            {
                return userAccount.ValidatePin(userPin);
            }
            return false;
        }
        public void Credit(int userAccountNumber, decimal amount)
        {
            GetAccount(userAccountNumber).Credit(amount);
        }
        public void Debit(int userAccountNumber, decimal amount)
        {
            GetAccount(userAccountNumber).Debit(amount);
        }
        public Account GetAccount(int accountNumber)
        {   
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].accountNumber == accountNumber)
                {
                    return accounts[i];
                }
            }
            return null;
        }
        public decimal getAvailableBalance(int userAccountNumber)
        {
            return GetAccount(userAccountNumber).availableBalance;
        }
        public decimal getTotalBalance(int userAccountNumber)
        {
            return GetAccount(userAccountNumber).totalBalance;
        }
    }
}
