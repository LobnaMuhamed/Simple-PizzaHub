using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_App___
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();
            if (rdSmall.Checked)
            {
                lbSize.Text = rdSmall.Text;
            }
            else if (rdMedium.Checked)
            {
                lbSize.Text = rdMedium.Text;
            }
            else if (rdLarge.Checked)
            {
                lbSize.Text = rdLarge.Text;
            }
            else
                lbSize.Text = "";
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();
            lbToppings.Text = "";
            if (chkExtraChees.Checked)
                lbToppings.Text += chkExtraChees.Text + ", ";
            if (chkOnion.Checked)
                lbToppings.Text += chkOnion.Text + ", ";
            if (chkMushrooms.Checked)
                lbToppings.Text += chkMushrooms.Text + "\n";
            if (chkOlives.Checked)
                lbToppings.Text += chkOlives.Text + ", ";
            if (chkTomatos.Checked)
                lbToppings.Text += chkTomatos.Text + ", ";
            if (chkGreenPaper.Checked)
                lbToppings.Text += chkGreenPaper.Text;
            if (lbToppings.Text == "")
                lbToppings.Text = "No Toppings";
        }
        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rdThinCrust.Checked)
                lbCrust.Text = rdThinCrust.Text;
            else if (rdThickCrust.Checked)
                lbCrust.Text = rdThickCrust.Text;
            else
                lbCrust.Text = "";
        }
        void UpdateWhereToEat()
        {
            UpdateTotalPrice();
            if (rdEatIn.Checked)
                lbWhereToEat.Text = rdEatIn.Text;
            else if (rdTakeOut.Checked)
                lbWhereToEat.Text = rdTakeOut.Text;
            else
                lbWhereToEat.Text = "";
        }

        private void rdSizeCheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }


        private void rdCrustCheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void chkToppingChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rdWhereEatCheckedIn(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        float GetSelectedSizePrice()
        {
            if (rdSmall.Checked)
                return Convert.ToSingle(rdSmall.Tag);
            else if (rdMedium.Checked)
                return Convert.ToSingle(rdMedium.Tag);
            else
                return Convert.ToSingle(rdLarge.Tag);
        }

        float CalaculateToppingsPrice()
        {
            float ToppingsTotalPrice = 0;
            if (chkExtraChees.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkExtraChees.Tag);
            if (chkOnion.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkOnion.Tag);
            if (chkMushrooms.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            if (chkOlives.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);
            if (chkTomatos.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkTomatos.Tag);
            if (chkGreenPaper.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkGreenPaper.Tag);
            return ToppingsTotalPrice;
        }

        float GetSelectedCrustPrice()
        {
            if (rdThickCrust.Checked)
                return Convert.ToSingle(rdThickCrust.Tag);
            else
                return Convert.ToSingle(rdThinCrust.Tag);
        }

        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + CalaculateToppingsPrice() + GetSelectedCrustPrice();
        }

        void UpdateTotalPrice()
        {
            lbPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }

        void ResetForm()
        {
            // reset Groups
            gpSize.Enabled = true;
            gpToppings.Enabled = true;
            gpCrust.Enabled = true;
            gpWhereEat.Enabled = true;

            // reset Size
            rdMedium.Enabled = true;

            // reset Toppings
            chkExtraChees.Checked = false;
            chkGreenPaper.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkOnion.Checked = false;
            chkTomatos.Checked = false;

            // reset CrustType
            rdThinCrust.Checked = true;

            // reset Where To Eat
            rdEatIn.Checked = true;

            // reset Order Button
            btnOrder.Enabled = true;
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Order Confirm", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrder.Enabled = false;
                gpSize.Enabled = false;
                gpToppings.Enabled = false;
                gpCrust.Enabled = false;
                gpWhereEat.Enabled = false;
            }
            else
                MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }
}
