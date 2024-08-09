using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingProject1._0
{
    public partial class FRMInventory : Form
    {
        public FRMInventory()
        {
            InitializeComponent();
        }

        public string[] strIngredients = { "flour", "yeast", "sugar", "oil", "ham", "turkey", "scheese", "lettuce", "tomato", "bacon", "pickles", "mayo", "mustard", "pepprni", "sauce", "gcheese", "salt", "pepper" };
        public decimal[] decQTYOfItems = { 200m, 50m, 30m, 25m, 10m, 10m, 20m, 14m, 14m, 10m, 20m, 15m, 12m, 20m, 60m, 25m, 10m, 10m };
               
        public void FRMInventory_Load(decimal[] decStock)
        {
           
            for (int i = 0; i < decQTYOfItems.Length; i++)
            {
                LBXInventory.Items.Add(strIngredients[i] + "\t" + decStock[i]);
            }           
        }
    }
}
