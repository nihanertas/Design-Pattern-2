using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cPro2
{
    class Balancelnquiry: Transaction
    {
        public Balancelnquiry(int accountNumber, Screen screen, BankDatabase bankDatabase)
            : base(accountNumber, screen, bankDatabase)
        {

        }
        public override void Execute()
        {
            decimal Balance = Database.getAvailableBalance(AccountNumber);
            decimal TotalBalance = Database.getTotalBalance(AccountNumber);

            UserScreen.DisplayMessageLine("Information: ");
            UserScreen.DisplayMessage("Available Balance: ");
            UserScreen.DisplayDollaramount(Balance);
            UserScreen.DisplayMessage("Total Balance");
            UserScreen.DisplayDollaramount(TotalBalance);
            UserScreen.DisplayMessageLine(" ");
        }
    }
}
