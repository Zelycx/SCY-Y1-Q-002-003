using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC_Y_1_Q_002_003
{
    internal class CartItem
    {
        // less comment (just did almost the same thing as the product)
        private int cartem_id, cartem_quantity;
        private string cartem_name;
        private double cartem_price;
        private double item_total;

        public CartItem(int id, string name, double price, int quantity, double itemtotal) {
            cartem_id = id;
            cartem_name = name;
            cartem_price = price;
            cartem_quantity = quantity;
            item_total = itemtotal;
        }
        public int Cid { get { return cartem_id; } set { cartem_id = (value > 0) ? value : 0; } }
        public string Cname { get { return cartem_name; } set { cartem_name = (string.IsNullOrWhiteSpace(value)) ? "No Value" : value; } }
        public double Cprice { get { return cartem_price; } set { cartem_price = (value > 0) ? value : 0; } }
        public int Cquantity { get { return cartem_quantity; } set { cartem_quantity = (value > 0) ? value : 0; } }
        // adding item total for the use of Product's "getItemTotal"
        public double Cit { get { return item_total; } set { item_total = (value > 0) ? value : 0; } }


        // For Receipt

        // Display the receipt and Grand Total 
        public string show_receipt()
        {
            return $"| Product: {Cname} | Price:  {Cprice:N2} | Quantity: {Cquantity} | Total Price: {item_total:N2} |";
        }
    }
}
