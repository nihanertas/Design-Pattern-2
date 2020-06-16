using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cPro2
{
    class WithDrawal:Transaction
    {
        int CANCELED = 5;
        CashDispenser cashDispenser;
        Keypad keypad;
        public WithDrawal(int userAccount, Screen screen, BankDatabase bankDatabase, Keypad keypad, CashDispenser cashDispenser)
            : base(userAccount, screen, bankDatabase)
        {
            CANCELED = userAccount;
            this.keypad = keypad;
            this.cashDispenser = cashDispenser;
        }
        public int displayMenu()
        {
            int choose = 0;
            int[] amount = { 20, 40, 60, 80 };
            while (choose == 0)
            {
                UserScreen.DisplayMessage("Menu\n");
                UserScreen.DisplayMessage("1.$20\n\n");
                UserScreen.DisplayMessage("2.$40\n\n");
                UserScreen.DisplayMessage("3.$60\n\n");
                UserScreen.DisplayMessage("4.$80\n\n");
                UserScreen.DisplayMessage("Choose a withdrawal amount");
                int temp = keypad.GetInput();
                switch (temp)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        choose = amount[temp];
                        break;
                    case 6:
                        choose = CANCELED;
                        break;
                    default:
                        UserScreen.DisplayMessage("Its not example. Please try again");
                        break;
                }
            }
            return choose;
        }
        public override void Execute()
        {
            /* Console.WriteLine("Amount " + amount + "dolar");
             Console.ReadLine();
             Console.WriteLine("Çekilecek Miktarı Giriniz : ");
             cashDispenser = keypad.GetInput();
             Console.ReadLine();
             if (amount > cashDispenser)
             {
                 amount -= cashDispenser;
                 Console.WriteLine("Karttan “" + cashDispenser + " tl çektiniz");
                 Console.WriteLine("Kalan Bakiye " + amount + " dolar");
             }*/
        }
    }
}
