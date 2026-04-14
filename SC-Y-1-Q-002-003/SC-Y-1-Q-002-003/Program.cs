namespace SC_Y_1_Q_002_003{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Create an array of Product objects as your store menu

            /*  
                At first I want to create a list of products to make it easier and FLEXIBLE.  

                List<Product> products = new List<Product>(); 
                .add() or {product1, product2..}

                but considering "an array of Product objects" it's too risky to do that.

                after checking it again,
                even tho I really want to use list it's really needed to use array 
                both product management and cart.
                
                    If using a fixed-size cart array: 
                        o Prevent adding items if the cart is already full
                
                It might be optional but if it's in the document. just do it.
                
            */

            // Create an array of Product objects as your store menu 
            // created an array of Product
            Product[] products = new Product[] {
                new Product(1, "Electric Fan", 1399, 50),
                new Product(2, "Rexona", 89, 25), // Not Sponsored 🥲
                new Product(3, "iPhone 17 Pro Max", 86990, 10), // Not Sponsored 🥲
                new Product(4, "Teddy Bear", 1299, 35),
                new Product(5, "Pair of Shoes", 1499, 60),
                new Product(6, "Lucky Me Pancit Canton (Pack of 6)", 89, 60), // Not Sponsored 🥲
                new Product(7, "Del Monte Pineapple Juice 1L (6-pack)", 549, 55), // Not Sponsored 🥲
                new Product(8, "C2 Green Tea (Case of 24)", 489, 50), // Not Sponsored 🥲
                new Product(9, "Champion Detergent Powder (Sack 3kg)", 289, 40), // Not Sponsored 🥲
                new Product(10, "Johnson’s Baby Powder (Case 12pcs)", 999, 40), // Not Sponsored 🥲
                new Product(11, "USB Flash Drive 32GB (Box of 10)", 1299, 25),
                new Product(12, "Closeup Toothpaste (Box of 6)", 489, 55), // Not Sponsored 🥲
                // The "9", budol of marketing
            };

            //Display the menu using a loop
            foreach (Product p in products) {
                Console.WriteLine(p.DisplayProduct());
            }

            /*
                Ask the user to: 
                    o Enter product number 
                    o Enter quantity 
             */

            // o Enter product number 
            Console.WriteLine("Enter the Product ID to Add something in the Cart");
            Console.Write("Action: ");
            /*
                Validate: 
                    o Invalid product number
                    o Non-numeric input "Use int.TryParse()" 
                        I won't take "if possible" :D
            */

            string Userinput1 = Console.ReadLine() ?? "";

            // Non-numeric input checker
            int SelectedProductID;
            bool IsInt = int.TryParse(Userinput1, out SelectedProductID);

            if (IsInt) {
                // Invalid product number checker
                bool productIDValidation;
                foreach (Product p in products) {
                    if (SelectedProductID == p.Pid)
                    {
                        productIDValidation = true;
                    }
                }

            }

        }
    }
}