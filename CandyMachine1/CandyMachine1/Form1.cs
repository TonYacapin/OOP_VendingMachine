using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CandyMachine1
{
    public partial class Form1 : Form
    {

        int password = 103101;
        int credit = 0;
        int option = 0;
        int refilloption =0;
        Boolean refillcandy = false;
        Boolean refillgum = false;
        Boolean refillcookies = false;
        Boolean refillchips = false;
        static int ItemCapacity = 10;
        static int MachineCash = 500;
         
        CashRegister Cash = new CashRegister(MachineCash);
        Dispenser Candy = new Dispenser(ItemCapacity, 1);
        Dispenser Chips = new Dispenser(ItemCapacity, 5);
        Dispenser Gum = new Dispenser(ItemCapacity, 2);
        Dispenser Cookies = new Dispenser(ItemCapacity, 3);

        public Form1()
        {
            InitializeComponent();
        }

        private void bttnCredit_Click(object sender, EventArgs e)
        {

            credit = credit + 1;
            txtCredits.Text = credit.ToString();


        }

        private void bttn1_Click(object sender, EventArgs e)
        {
            option = 1;
            txtTrans.Text = "CANDY 1 peso";
        }

        private void bttn2_Click(object sender, EventArgs e)
        {
            option = 2;
            txtTrans.Text = "CHIPS 5 pesos ";

        }

        private void bttn3_Click(object sender, EventArgs e)
        {
            option = 3;
            txtTrans.Text = "GUM 2 pesos";

        }

        private void bttn4_Click(object sender, EventArgs e)
        {
            option = 4;
            txtTrans.Text = "COOKIES 3 pesos";

        }

        private void bttnProceed_Click(object sender, EventArgs e)
        {
            if (option == 1)
            {
                if (Candy.getCount() > 0)
                {
                    if (credit >= Candy.getProductCost())
                    {
                        Candy.makeSale();

                        credit = credit - Candy.getProductCost();

                        Cash.acceptAmount(Candy.getProductCost());
                        txtCredits.Text = credit.ToString();
                    }
                    else
                    {
                        int creditneeded = Candy.getProductCost() - credit;
                        MessageBox.Show("An amount of " + creditneeded.ToString() + " peso/s is needed", "Insufficient Credit");
                    }
                }
                else
                {
                    MessageBox.Show("CANDY not Available", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    OOSCandy.Visible = true;
          

                }


            }

            else if (option == 2) {

                if (Chips.getCount() > 0)
                {

                    if (credit >= Chips.getProductCost())
                    {
                        Chips.makeSale();

                        credit = credit - Chips.getProductCost();

                        Cash.acceptAmount(Chips.getProductCost());
                        txtCredits.Text = credit.ToString();
                    }
                    else
                    {
                        int creditneeded = Chips.getProductCost() - credit;
                        MessageBox.Show(creditneeded.ToString() + " peso/s is needed", "Insufficient Credit");
                    }
                }
                else
                {
                    MessageBox.Show("CHIPS not Available","Out of Stock",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                   OOSchips.Visible = true;
                }
                }

            else if (option == 3) {
                if (Gum.getCount() > 0)
                {
                    if (credit >= Gum.getProductCost())
                    {
                        Gum.makeSale();
                        credit = credit - Gum.getProductCost();

                        Cash.acceptAmount(Gum.getProductCost());
                        txtCredits.Text = credit.ToString();
                    }
                    else
                    {
                        int creditneeded =  Gum.getProductCost() - credit;
                        MessageBox.Show(creditneeded.ToString() + " peso/s is needed", "Insufficient Credit");
                    }
                }
                else { MessageBox.Show("GUM not Available","Out of Stock",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                 OOSGum.Visible = true;
                }
            }

            else if (option == 4) {

                if (Cookies.getCount() > 0)
                {
                    if (credit >= Cookies.getProductCost())
                    {
                        Cookies.makeSale();
                        credit = credit - Cookies.getProductCost();

                        Cash.acceptAmount(Cookies.getProductCost());
                        txtCredits.Text = credit.ToString();
                     
                    }
                    else
                    {
                        int creditneeded = Cookies.getProductCost() - credit;
                        MessageBox.Show("An amount of " + creditneeded.ToString() + " peso/s is needed", "Insufficient Credit");
                    }
                }
                else
                {
                    MessageBox.Show("COOKIES not Available", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    OOScookie.Visible = true;
                }

            }
             

            else MessageBox.Show("No Option Selected");
        }

        private void bttnMachineInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cash: "+ Cash.currentBalance() + " " +  
                            "Candy: " + Candy.getCount() + " " +
                            "Chips: " +Chips.getCount() + " " +
                            "Gum: " +Gum.getCount() + " " +
                            "Cookies: " +Cookies.getCount() 
                            );
        }

        private void bttnRefill_Click(object sender, EventArgs e)
        {
            Candy = new Dispenser(ItemCapacity, 1);
            Chips = new Dispenser(ItemCapacity, 5);
            Gum = new Dispenser(ItemCapacity, 2);
            Cookies = new Dispenser(ItemCapacity, 3);
            OOSGum.Visible = false;
            OOSCandy.Visible = false;
            OOScookie.Visible = false;
            OOSchips.Visible = false;   
            MessageBox.Show("All items are refilled");

        }

        private void bttnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your " + credit + " peso/s is returned", "Thank you for using the machine");
            credit = 0;
            txtCredits.Text = credit.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bttncredit5_Click(object sender, EventArgs e)
        {
            credit = credit + 5;
            txtCredits.Text = credit.ToString();

        }

        private void bttncredit10_Click(object sender, EventArgs e)
        {
            credit = credit + 10;
            txtCredits.Text = credit.ToString();
        }

        private void bttnenter_Click(object sender, EventArgs e)
        {
            if (txtPASS.Text == password.ToString())
            {
                bttnRefill.Enabled = true;
                bttnMachineInfo.Enabled = true;
                bttnwithdraw.Enabled = true;
                bttnLogout.Enabled = true;
                MessageBox.Show("Logged in Successfuly", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                MessageBox.Show("Wrong Password", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void bttnLogout_Click(object sender, EventArgs e)
        {
            bttnRefill.Enabled = false;
            bttnMachineInfo.Enabled = false;
            bttnwithdraw.Enabled = false;
            bttnLogout.Enabled = false;
            txtPASS.Text = "";
            MessageBox.Show("Logout!", "Logout Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bttnwithdraw_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("An amount of " + (Cash.currentBalance() -MachineCash)  + " peso/s is Withdrawn" , "Withdrawal Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cash = new CashRegister(MachineCash);
        }
    }
}
