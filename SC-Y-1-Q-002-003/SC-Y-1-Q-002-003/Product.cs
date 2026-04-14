/* 
  Insuring all the requirements are fulfilled, 
  I'll do everything inside your pdf one by one sir. 
  
  considering all those, I still want to implement things I want.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC_Y_1_Q_002_003
{
    // Create a class named Product 
    internal class Product
    {
        // Initialization.
        // Making it private to make it safer and cleaner.
        /*
            Add the following fields/properties:  
            o Id  = product_id
            o Name = product_name
            o Price = product_price
            o RemainingStock = product_stock
        */

        private int product_id, product_stock;
        private double product_price;
        private string product_name;

        // For creating
        public Product(int id, string name, double price, int stock)
        {
            product_id = id;
            product_stock = stock;
            product_name = name;
            product_price = price;
        }

        // for encapsulation ( getter and setter )
        // adding a condition for setter to make it more invulnerable
        public int Pid { get { return product_id; } set { product_id = (value > 0) ? value : 0; } }
        public string Pname { get { return product_name; } set { product_name = (string.IsNullOrWhiteSpace(value)) ? "No Value" : value; } }
        public double Pprice { get { return product_price; } set { product_price = (value < 0) ? 0 : value; } }
        public int PStock { get { return product_stock; } set { product_stock = (value < 0) ? 0 : value; } }

        //Add the following methods:
        // o DisplayProduct()

        public string DisplayProduct()
        {
            return $"| Product ID: {product_id} | Name: {product_name} | Price: {product_price} | Remaining Stocks: {product_stock} | ";
        }
        //  At least one additional method aside from DisplayProduct()
        /*
            Examples: 
                ▪ GetItemTotal(int quantity) 
                // Another realization: Must be here

                ▪ HasEnoughStock(int quantity) 
                // I think putting it here is a proper choice.

                ▪ DeductStock(int quantity) check ✔️
         */


        public void deduct_stock(int quantity)
        {
            product_stock -= quantity;
        }

        public bool hasEnoughStock(int quantity) 
        {
            return product_stock >= quantity;
        }

        public double getItemTotal(int quantity)
        {
            return product_price * quantity;
        }
    }
}
