using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopUsingList
{
    public partial class FrmCoffeeShop : Form
    {
        List<string> Names = new List<string>();
        List<string> Contacts = new List<string>();
        List<string> Addresses = new List<string>();
        List<string> Orders = new List<string>();
        List<int> Quantities = new List<int>();
        List<int> Prices = new List<int>();


        public FrmCoffeeShop()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {

            bool isDup = CheckDuplicate(contactTextBox.Text);
            if (isDup == true)
            {
                MessageBox.Show("Contact Number Must be Unique,Please Enter Another Contact");
                return;
            }


            try
            {
                Convert.ToInt16(quantityTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Quantity Feild is empty,please put an amount");
                return;
            }

            bool isempty = string.IsNullOrEmpty(orderComboBox.Text);
            if (isempty == true)
            {
                MessageBox.Show("Please Select an Order");
                return;
            }

            Names.Add(nameTextBox.Text);
            Contacts.Add(contactTextBox.Text);
            Addresses.Add(addressTextBox.Text);
            Orders.Add(orderComboBox.Text);
            Quantities.Add(Convert.ToInt16(quantityTextBox.Text));
            
                       
            int Bill = 0;
            int amount = Convert.ToInt16(quantityTextBox.Text);

            if (orderComboBox.Text == "Black")
            {
                Bill = 120 * amount;
            }
            else if (orderComboBox.Text == "Cold")
            {
                Bill = 100 * amount;
            }
            else if (orderComboBox.Text == "Hot")
            {
                Bill = 90 * amount;
            }
            else if (orderComboBox.Text == "Reguler")
            {
                Bill = 80 * amount;
            }
            else
            {
            }  
             
            Prices.Add(Bill);
           
            richTextBox.Text = "Your Purchase Info:"+"\n" + "Name:" + nameTextBox.Text +"\n"+ "Contact No:" 
                + contactTextBox.Text+"\n"+ "Address:" + addressTextBox.Text + Environment.NewLine + "You ordered: "
                + amount.ToString()+" " + orderComboBox.Text + " Coffee" +"\n"+ "Your Payment Bill is:" + Bill.ToString();

            ClearAllControls();

           
        }


        private void showButton_Click(object sender, EventArgs e)
        {
            string message="";
            for (int i = 0; i <Names.Count(); i++)
            {
                message += "Purchase Info for "+ Names[i] +"\n"+ "Contact no: " + Contacts[i] + " , Address: " 
                    + Addresses[i]+ "\n"+"You Ordered: " + Quantities[i] +" "+ Orders[i] + " Coffee"
                    +"\n"+"Your Payment Bill is: "+Prices[i]+"\n"+"\n";
            }
            richTextBox.Text = message;
        }

        public bool CheckDuplicate(string cinput)
        {
            bool isduplicale = false;

            bool isnull = string.IsNullOrEmpty(cinput);
            if (isnull == true)
            {
                return isduplicale;
            }


            foreach (string c in Contacts)
            {
                if (c == cinput)
                {
                    isduplicale = true;
                    break;
                }
                else
                    continue;
            }
            return isduplicale;

        }

        private void ClearAllControls()
        {
            nameTextBox.Text = "";
            contactTextBox.Text = "";
            addressTextBox.Text = "";
            orderComboBox.SelectedIndex =-1;
            quantityTextBox.Text = "";
                     
        }
     
    }
}
