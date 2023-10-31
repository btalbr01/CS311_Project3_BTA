using System.DirectoryServices.ActiveDirectory;

namespace CS311_Project3_BTA
{
    public partial class frmBensPizzaPlace : Form
    {
        //tax in Kentucky is 6%.
        double tax = 1.06;


        public frmBensPizzaPlace()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Button click calls Summarize() to process the order.
            Summarize();
        }

        private void Summarize()
        {
            //variables to handle the subtotal, taxes and total for the order.
            float subtotal = 0;
            double tax;
            double total;

            //variables to handle pizza size and crust type.
            String size = cboSizes.GetItemText(cboSizes.SelectedItem);
            String crust = "";

            //clears the Order Summary box every time the order is calculated.         
            rtfOrderSummary.Text = "";

            //if statements to determine pizza size and cost for that size.
            if (cboSizes.Text == "Small")
                subtotal = subtotal + 2;
            if (cboSizes.Text == "Medium")
                subtotal = subtotal + 5;
            if (cboSizes.Text == "Large")
                subtotal = subtotal + 10;
            if (cboSizes.Text == "X-Large")
                subtotal = subtotal + 15;
            if (cboSizes.Text == "Ginormous")
                subtotal = subtotal + 20;

            //if statements to determine what toppings are on the pizza and 
            //add their cost to the subtotal.
            if (ckbPepperoni.Checked == true)
                subtotal = subtotal + 2;
            if (ckbSausage.Checked == true)
                subtotal = subtotal + 2;
            if (ckbCanadianBacon.Checked == true)
                subtotal = subtotal + 2;
            if (ckbSpicyItalian.Checked == true)
                subtotal = subtotal + 2;
            if (ckbOnion.Checked == true)
                subtotal = subtotal + 1;
            if (ckbGreenPepper.Checked == true)
                subtotal = subtotal + 1;
            if (ckbBlackOlives.Checked == true)
                subtotal = subtotal + 1;
            if (ckbGreenOlives.Checked == true)
                subtotal = subtotal + 1;
            if (ckbBananaPeppers.Checked == true)
                subtotal = subtotal + 1;
            if (ckbJalapeno.Checked == true)
                subtotal = subtotal + 1;
            if (ckbExtraCheese.Checked == true)
                subtotal = subtotal + 1;
            if (ckbMushroom.Checked == true)
                subtotal = subtotal + 1;

            //sets crust variable to crust type picked by user.
            if (rdoThin.Checked)
                crust = "Thin";
            else if (rdoThick.Checked)
                crust = "Thick";
            else if (rdoRegular.Checked)
                crust = "Regular";

            //if crust type or size not chosen, prompts user to choose them.
            if (crust == "" || size == "")
                rtfOrderSummary.Text = "Please choose a size or crust";

            //if crust and size chosen, prints subtotal, tax and total to
            //their text boxes as dollar amounts.
            else
            {
                txtSubtotal.Text = subtotal.ToString("C");
                tax = subtotal * 0.06;
                txtTax.Text = tax.ToString("C");
                total = subtotal + tax;
                txtTotal.Text = total.ToString("C");
                rtfOrderSummary.SelectedText = "You ordered a " + size + " pizza with " + crust +
                    " crust and the following toppings:\n";
            }

            //sets bulleted points for the toppings.
            rtfOrderSummary.SelectionBullet = true;

            //if statements to determine what topings were chosen
            //and display them as bulleted points.
            if (ckbPepperoni.Checked == true)
                rtfOrderSummary.SelectedText = "Pepperoni\n";
            if (ckbSausage.Checked == true)
                rtfOrderSummary.SelectedText = "Sausage\n";
            if (ckbCanadianBacon.Checked == true)
                rtfOrderSummary.SelectedText = "Canadian Bacon\n";
            if (ckbSpicyItalian.Checked == true)
                rtfOrderSummary.SelectedText = "Spicy Italian Sausage\n";
            if (ckbOnion.Checked == true)
                rtfOrderSummary.SelectedText = "Onion\n";
            if (ckbGreenPepper.Checked == true)
                rtfOrderSummary.SelectedText = "Green Pepper\n";
            if (ckbBlackOlives.Checked == true)
                rtfOrderSummary.SelectedText = "Black Olives\n";
            if (ckbGreenOlives.Checked == true)
                rtfOrderSummary.SelectedText = "Green Olives\n";
            if (ckbBananaPeppers.Checked == true)
                rtfOrderSummary.SelectedText = "Banana Peppers\n";
            if (ckbJalapeno.Checked == true)
                rtfOrderSummary.SelectedText = "Jalapeno\n";
            if (ckbExtraCheese.Checked == true)
                rtfOrderSummary.SelectedText = "Extra Cheese\n";
            if (ckbMushroom.Checked == true)
                rtfOrderSummary.SelectedText = "Mushroom\n";

            //ends bullet point formatting.
            rtfOrderSummary.SelectionBullet = false;
        }
    }
}