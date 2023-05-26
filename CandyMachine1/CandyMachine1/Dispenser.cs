using System;
using System.Collections.Generic;
using System.Text;

namespace CandyMachine1
{
    internal class Dispenser
    {


        private int cost = 0;

        private int numberOfItems = 0;


        public Dispenser()
        {

            cost = 50;
            numberOfItems = 50;
        }


        public Dispenser(int numberOfItems, int cost)
        {

         this.numberOfItems = numberOfItems;
         this.cost = cost;


            if (numberOfItems <=  0)
            {
                numberOfItems = 50;
                this.cost = cost;
            } 
        }

       public int getCount()
        {

            return numberOfItems;
        }

        public int getProductCost() {
        
            return cost;
        
        
        }


        public void makeSale() {


            numberOfItems = getCount() - 1;
        
        }

        public int Refill(int numberOfItems) {
        
        this.numberOfItems = numberOfItems;

            return numberOfItems;
        
        }

          

    }
}
