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
            
            I'll add two more attributes for this object
            * RestockLevel —> Can make the Stock Reorder Alert feature more flexible
            * Category —> this thing is needed for filtering by category feature

            but after checking it again 

            Requirement states:
            "Set a reorder level, such as RemainingStock <= 5" 
            
            for my interpretation, 5 is just an example —> "such as" 
            but considering the part 1 of this project I must strictly match the requirements.
            the requirements does NOT really state that the reorder level should be hardcoded.

            but I decided to use a hardcoded value "<= 5" to strictly match the requirement, 
            I did not add a RestockLevel Attribute to avoid unnecessary complexity, and focus on 
            putting all the required features.

            TL;DR:
            RestockLevel could be added for flexibility, but is not necessary requirement compliance
            so I choosed to stick to it.
        */

        private int product_id, product_stock;
        private double product_price;
        private string product_name, product_category;


        // For creating
        public Product(int id, string name, double price, int stock, string category)
        {
            product_id = id;
            product_stock = stock;
            product_name = name;
            product_price = price;
            product_category = category; // Add a Category field to the Product class.
        }

        // for encapsulation ( getter and setter )
        // adding a condition for setter to make it more invulnerable
        public int Pid { get { return product_id; } set { product_id = (value > 0) ? value : 0; } }
        public string Pname { get { return product_name; } set { product_name = (string.IsNullOrWhiteSpace(value)) ? "No Value" : value; } }
        public double Pprice { get { return product_price; } set { product_price = (value < 0) ? 0 : value; } }
        public int PStock { get { return product_stock; } set { product_stock = (value < 0) ? 0 : value; } }
        public string PCategory { get { return product_category;  } set { product_category = (string.IsNullOrWhiteSpace(value)) ? "No Value" : value; } }

        // 

        //Add the following methods:
        // o DisplayProduct()

        public string DisplayProduct()
        {
            return $"| Product ID: {product_id} | Name: {product_name} | Price: {product_price:N2} | Remaining Stocks: {product_stock} | Category: {product_category}";
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
