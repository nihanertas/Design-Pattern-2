using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cPro2
{
    class Deposit: Transaction
    {

        private decimal amount;
        private Keypad keypad;
        private DepositSlot depositSlot;
        private const int CANCELED = 0;
        public Deposit(int userAccountNumber, Screen atmScreen, BankDatabase atmBankDatabase, Keypad atmKeypad, DepositSlot atmDepositSlot)
            : base(userAccountNumber, atmScreen, atmBankDatabase)
        {
            keypad = atmKeypad;
            depositSlot = atmDepositSlot;
        }
        public override void Execute()
        {
            amount = PrompForDepositAmount();
            if (amount != CANCELED)
            {
                UserScreen.DisplayMessage("\nPlease insert a deposit envelope containing");
                UserScreen.DisplayDollaramount(amount);
                UserScreen.DisplayMessageLine("in the deposit slot");
                bool envelopeReceived = depositSlot.isDepositEnvelopeReceived();
                if (envelopeReceived)
                {
                    UserScreen.DisplayMessageLine("Your envelope has been received");
                    Database.Credit(AccountNumber, amount);
                }

                else
                    UserScreen.DisplayMessageLine("you did not insert an envelope ");
            }

            else
                UserScreen.DisplayMessageLine("jwıjdwjd");
        }
        private decimal PrompForDepositAmount()
        {
            UserScreen.DisplayMessageLine("\n please input a deposit amount in Cents");
            int input = keypad.GetInput();
            if (input == CANCELED)
                return CANCELED;
            else
                return input;
        }
    }
}
