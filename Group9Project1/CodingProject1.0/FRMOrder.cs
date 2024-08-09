//AUTHOR: Karthik Ponnapalli, Dania Alabki, and Khizrali Kradiya (Group 9)
//COURSE: ISTM250.502
//FORM: FRMOrder
//PURPOSE: Order items from a deli.
//INPUT: We are collecting customer information and desired order from user.
//PROCESS: Taking user input and finding the subtotal of the order.
//OUTPUT: Subtotal of order and items orders in a list box.
//HONOR CODE: “On my honor, as an Aggie, I have neither given
// nor received unauthorized aid on this academic
// work.”

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CodingProject1._0
{
    public partial class FRMOrder : Form
    {
        public FRMOrder()
        {
            InitializeComponent();
        }

       



        //creates an array for the different items, bread types, and the different crust types.
        string[] strItems = { "Ham & Swiss Sandwich", "Turkey & Provolone Sandwich", "BLT sandwich", "Med. Cheese Pizza", "Med.Pepporoni Pizza", "Med. Supreme Pizza" };

        string[] strBreadTypes = { "White", "Pumpernickel", "Rye", "Sourdough", "Multigrain" };

        string[] strCrustTypes = { "Origional", "Pan", "Thin", "Wheat" };

        //declares the subtotal variable
        decimal decSubtotal = 0;

        //cbx item type
        int intSelectedIndexOfItemType;
        //qty
        int intQTYOfOrder;

        /// <summary>
        /// Loads items into the combobox
        /// </summary>
        private void LoadInventoryComboBox()
        {
            CBXItemType.Items.Clear();

            foreach (string strItem in strItems)
            {
                CBXItemType.Items.Add(strItem);
            }
            CBXItemType.SelectedIndex = -1;

            CBXBreadType.SelectedIndex = -1;
        }

        /// <summary>
        /// This will close the application when the user clicks the exit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNExit_Click(object sender, EventArgs e)
        {
            //This closes the application.
            Close();
        }

        /// <summary>
        /// When the form is loaded the combo box will load as well as all the different inventory items. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FRMOrder_Load(object sender, EventArgs e)
        {
            LoadInventoryComboBox();
        }

        /// <summary>
        /// This button will calculate the price of eah item and will output a message box for the subtotal price
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                int intQTY = Convert.ToInt32(TXTQuantity.Text);
                if(intQTY <= 0) 
                {
                    MessageBox.Show("Quantity must be greater than 0.", "Entry Error");
                }
                if (IsValidDataAdd() && intQTY > 0)
                {

                    intQTYOfOrder = intQTY; //added this in for removing of inventory
                    intSelectedIndexOfItemType = CBXItemType.SelectedIndex; // added this in for the removing of inventory


                    //int intQTY = Convert.ToInt32(TXTQuantity.Text);
                    decimal decPriceOfItem = 0; // itemized price
                    decimal decTotalPrice = 0; // with tax

                    if (CBXItemType.SelectedIndex == 0 || CBXItemType.SelectedIndex == 1 || CBXItemType.SelectedIndex == 2) //if customer selects a sandwich
                    {
                        decPriceOfItem = 5m;
                    }
                    else if (CBXItemType.SelectedIndex == 3 || CBXItemType.SelectedIndex == 4 || CBXItemType.SelectedIndex == 5) //if customer selects pizza
                    {
                        decPriceOfItem = 9.50m;
                    }

                    decTotalPrice = decPriceOfItem * intQTY;

                    decSubtotal += decTotalPrice;

                    string strText = "";

                    strText = strItems[CBXItemType.SelectedIndex] + ", " + TXTQuantity.Text + "@" + decPriceOfItem.ToString("c") + ", total: " + decTotalPrice.ToString("c");

                    LBXItems.Items.Add(strText); //adding different items into the listbox

                    //RemoveInventory(); //removes inventory when user adds an item to the order 

                    TXTSubtotal.Clear();

                    CBXItemType.SelectedIndex = -1;
                    CBXBreadType.Items.Clear();

                   

                    TXTQuantity.Clear(); //resetting the selections each time user clicked submit

                    PBXFood.Image = null;

                    //calculates the total with taxes and displays it for the user to see

                    decSubtotal *= 1.0825m;

                    TXTSubtotal.Text = decSubtotal.ToString("c");

                    RemoveInventory(decQTYOfItems);
                }
            }
            catch
            {
                MessageBox.Show("An unexpected error occured. Please try again.");
            }
            
        }

        /// <summary>
        /// submits the order when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNSubmitOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidDataSubmit())
                {
                   

                    //clearing the form

                    LBXItems.Items.Clear();

                    //customer information

                    TXTCity.Clear();
                    TXTName.Clear();
                    TXTPhoneNumber.Clear();
                    TXTStreetAddress.Clear();
                    TXTState.Clear();
                    TXTZipCode.Clear();
                    TXTSubdivision.Clear();

                    //delivery information

                    TXTDeliveryName.Clear();
                    TXTDeliveryStreetAddress.Clear();
                    TXTDeliveryCity.Clear();
                    TXTDeliveryState.Clear();
                    TXTDeliveryZipCode.Clear();
                    TXTDeliveryPhoneNumber.Clear();
                    TXTDeliverySubdivision.Clear();

                    CBXBreadType.SelectedIndex = -1;
                    CBXItemType.SelectedIndex = -1;

                    PBXFood.Image = null;
                    //decimal decTotal = Convert.ToDecimal(TXTSubtotal.Text);
                    TXTSubtotal.Clear();

                   
                    string strSubTotal = String.Format("{0:C}",decSubtotal);
                    

                    MessageBox.Show("Your order total is: " + strSubTotal + "!", "Order Total");
                   
                }
            }
            catch
            {
                MessageBox.Show("An unexpected error occured");
            }
        }

        
        /// <summary>
        /// checks if user wants delivery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CHKDelivery_CheckedChanged(object sender, EventArgs e)
        {
            if(CHKDelivery.Checked)
            {
                GBXDeliveryInformation.Enabled = true;
                //setting each textbox equal to their delivery textbox counterpart.
                TXTDeliveryCity.Text = TXTCity.Text;
                TXTDeliveryName.Text = TXTName.Text;
                TXTDeliveryPhoneNumber.Text = TXTPhoneNumber.Text;
                TXTDeliveryStreetAddress.Text = TXTStreetAddress.Text;
                TXTDeliveryState.Text = TXTState.Text;
                TXTDeliveryZipCode.Text = TXTZipCode.Text;
                TXTDeliverySubdivision.Text = TXTSubdivision.Text;

                TXTDeliveryName.Focus(); 
                //if user selects delivery, info from customer info group box will copy into delivery groupbox
            }
            else
            {
                GBXDeliveryInformation.Enabled = false;

                TXTDeliveryCity.Clear();
                TXTDeliveryName.Clear();
                TXTDeliveryPhoneNumber.Clear();
                TXTDeliveryStreetAddress.Clear();
                TXTDeliveryState.Clear();
                TXTDeliveryZipCode.Clear();
                TXTDeliverySubdivision.Clear();
                //clearing delivery group box if it is disabled
            }
        }

        /// <summary>
        /// This will clear each textbox or listbox when the user clicks the clear button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNClearOrder_Click(object sender, EventArgs e) //resetting form if user clicks clear order
        {
            //list box of items

            LBXItems.Items.Clear();
            CBXItemType.SelectedIndex = -1;
            CBXBreadType.SelectedIndex = -1;

            //customer information

            TXTCity.Clear();    
            TXTName.Clear();
            TXTPhoneNumber.Clear();
            TXTStreetAddress.Clear();
            TXTState.Clear();
            TXTZipCode.Clear();
            TXTSubdivision.Clear();

            //delivery information

            TXTDeliveryName.Clear();
            TXTDeliveryStreetAddress.Clear();
            TXTDeliveryCity.Clear();
            TXTDeliveryState.Clear();
            TXTDeliveryZipCode.Clear();
            TXTDeliveryPhoneNumber.Clear();
            TXTDeliverySubdivision.Clear();

            decSubtotal = 0m;
            TXTSubtotal.Clear();
            TXTQuantity.Clear();

            decQTYOfItems = decBaseInventory; //when order is cleared the inventory levels should go back to normal

            //image

            PBXFood.Image = null;          
        }

        /// <summary>
        /// If the item selected is the first 3 then their should be an image of the item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBXItemType_SelectedIndexChanged(object sender, EventArgs e) //adding the picture based upon user selection in combobox
        {
            if (CBXItemType.SelectedIndex == 0 || CBXItemType.SelectedIndex == 1 || CBXItemType.SelectedIndex == 2) //if user selects a sandwich, show pic of sandwich
            {
                CBXBreadType.Items.Clear();

                foreach (string strBreadType in strBreadTypes)
                {
                    CBXBreadType.Items.Add(strBreadType);
                }

                //clears qty of items and changes picture
                TXTQuantity.Clear();
                PBXFood.Image = Properties.Resources.deli;
                PBXFood.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            else //if user selects pizza, show picture of pizza
            {
                CBXBreadType.Items.Clear();

                foreach (string strCrustType in strCrustTypes)
                {
                    CBXBreadType.Items.Add(strCrustType);
                }

                TXTQuantity.Clear();
                PBXFood.Image = Properties.Resources.pizza;
                PBXFood.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        #region Validation

        /// <summary>
        /// data validor method
        /// </summary>
        /// <returns></returns>
        private bool IsValidDataAdd()
        {
            //this will increase if we have errors
            string strErrorMessage = "";

            //Item Type
            strErrorMessage += Validator.IsPresent(CBXItemType.Text, "Item type");

            //Crust Type
            strErrorMessage += Validator.IsPresent(CBXBreadType.Text, "Crust or bread type");

            //qty
            strErrorMessage += Validator.IsInteger(TXTQuantity.Text, "Quantity");



            if (strErrorMessage != "") // if we have one or more errors 
            {
                MessageBox.Show(strErrorMessage, "Entry Error");
                return false;       // we do NOT have valid data 
            }
            else
            {
                return true;        // we do have valid data 
            }

        }
        /// <summary>
        /// Data validation for submitting the order 
        /// </summary>
        /// <returns></returns>
        private bool IsValidDataSubmit()
        {
            string strErrorMessage = ""; //this will increase if we have errors

            //customer info

            strErrorMessage += Validator.IsPresent(TXTName.Text.Trim(), "Customer Name"); //make sure to fill tags
            strErrorMessage += Validator.IsPresent(TXTStreetAddress.Text.Trim(), "Customer Street Address");
            strErrorMessage += Validator.IsPresent(TXTCity.Text.Trim(), "Customer City");
            strErrorMessage += Validator.IsPresent(TXTState.Text.Trim(), "Customer State");
            strErrorMessage += Validator.IsInteger(TXTZipCode.Text.Trim(), "Customer Zip Code");
            strErrorMessage += Validator.IsPresent(TXTPhoneNumber.Text.Trim(), "Customer Phone number");
            strErrorMessage += Validator.IsPresent(TXTSubdivision.Text.Trim(), "Customer Subdivison");



            //making sure user has added stuff to their order

            if (LBXItems.Items.Count == 0)
            {
                strErrorMessage += "Please add the item to your order before submitting. \n";
            }

            //is within delivery range

            if (CHKDelivery.Checked)
            {
                strErrorMessage += Validator.IsWithinDeliveryRange(TXTDeliveryCity.Text.ToLower(), TXTDeliveryState.Text.ToLower());

                strErrorMessage += Validator.IsPresent(TXTDeliveryName.Text.Trim(), "Delivery name");
                strErrorMessage += Validator.IsPresent(TXTDeliveryStreetAddress.Text.Trim(), "Delivery Street Address");
                strErrorMessage += Validator.IsPresent(TXTDeliveryCity.Text.Trim(), "Delivery City");
                strErrorMessage += Validator.IsPresent(TXTDeliveryState.Text.Trim(), "Delivery State");
                strErrorMessage += Validator.IsInteger(TXTDeliveryZipCode.Text.Trim(), "Delivery Zip Code");
                strErrorMessage += Validator.IsPresent(TXTDeliveryPhoneNumber.Text.Trim(), "Delivery Phone Number");
                strErrorMessage += Validator.IsPresent(TXTDeliverySubdivision.Text.Trim(), "Delivery Subdivision");
            }

            if (strErrorMessage != "") // if we have one or more errors 
            {
                MessageBox.Show(strErrorMessage, "Entry Error");
                return false;       // we do NOT have valid data 
            }
            else
            {
                return true;        // we do have valid data 
            }
        }
        #endregion

        private void BTNInventory_Click(object sender, EventArgs e)
        {
            FRMInventory frmInventory = new FRMInventory();
            frmInventory.FRMInventory_Load(decQTYOfItems);
            frmInventory.ShowDialog();                   
        }

        string[] strIngredients = { "flour", "yeast", "sugar", "oil", "ham", "turkey", "scheese", "lettuce", "tomato", "bacon", "pickles", "mayo", "mustard", "pepprni", "sauce", "gcheese", "salt", "pepper" };
        decimal[] decQTYOfItems = { 200m, 50m, 30m, 25m, 10m, 10m, 20m, 14m, 14m, 10m, 20m, 15m, 12m, 20m, 60m, 25m, 10m, 10m };
        decimal[] decBaseInventory = { 200m, 50m, 30m, 25m, 10m, 10m, 20m, 14m, 14m, 10m, 20m, 15m, 12m, 20m, 60m, 25m, 10m, 10m };


        decimal[,] decUsage = {
            {1m, 1m, 1m, 3m, 3m, 3m},
            {0.5m, 0.5m, 0.5m, 2m, 2m, 2m},
            {0.03m, 0.03m, 0.03m, 0.5m, 0.5m, 0.5m},
            {0.05m, 0.05m, 0.05m, 0.1m, 0.1m, 0.1m},
            {0.1m, 0m, 0m, 0m, 0m, 0.1m},
            {0m, 0.1m, 0m, 0m, 0m, 0.1m},
            {0.1m, 0.1m, 0m, 0m, 0m, 0m},
            {0.25m, 0.25m, 0.3m, 0m, 0m, 0m},
            {0.25m, 0.25m, 0.3m, 0m, 0m, 0.3m},
            {0m, 0m, 0.1m, 0m, 0m, 0.1m},
            {0.02m, 0.02m, 0m, 0m, 0m, 0m},
            {0.02m, 0.02m, 0.02m, 0m, 0m, 0m},
            {0.02m, 0.02m, 0.02m, 0m, 0m, 0m},
            {0m, 0m, 0m, 0m, 0.3m, 0.3m},
            {0m, 0m, 0m, 1m, 1m, 1m},
            {0m, 0m, 0m, 0.3m, 0.2m, 0.2m},
            {0.01m, 0.01m, 0.01m, 0.02m, 0.02m, 0.02m},
            {0.01m, 0.01m, 0.01m, 0.02m, 0.02m, 0.02m}
        };

        public decimal[] RemoveInventory(decimal[] decQTYOfItems)
        { //cbx item type, qty

            

            for (int i = 0; i < decQTYOfItems.GetLength(0); i++)
            {
                decQTYOfItems[i] -= decUsage[i, intSelectedIndexOfItemType] * intQTYOfOrder;              
            }

            return decQTYOfItems;
        }

    }
}


