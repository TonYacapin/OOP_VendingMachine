using System;
using System.Collections.Generic;
using System.Text;

namespace CandyMachine1
{
    internal class CashRegister
    {


        private int cashonHand = 0;


        public CashRegister() {

            cashonHand = 500;

        }

        public CashRegister(int cashonHand)
        {

            this.cashonHand = cashonHand;


            if (cashonHand <= 0) {


                this.cashonHand = 500;


            }

        }

        public int currentBalance ()
        {

            return cashonHand;
        }

        public void acceptAmount(int cash)
        {
            this.cashonHand = currentBalance() + cash;
            
        }
    }
}
