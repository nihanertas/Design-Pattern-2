using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cPro2
{
    class CashDispenser
    {
        private int billCount;
        private int INITIAL_COUNT;
        public CashDispenser(int billCount, int INITIAL_COUNT)
        {
            this.billCount = billCount;
            this.INITIAL_COUNT = INITIAL_COUNT;
        }
        public void DispenseCash(decimal amount)
        {
            decimal withdraw = amount % 2;

            if (withdraw == 0)
            {
                withdraw = amount / 2;
                billCount -= (int)withdraw;
            }
        }
        public bool isSufficiantCashAvailable(decimal amount)
        {
            decimal withdraw = amount % 2;

            if (withdraw == 0)

                withdraw = amount / 20;
            if (billCount >= withdraw)
            {
                return true;
            }
            else
                return false;
        }
    }
}
