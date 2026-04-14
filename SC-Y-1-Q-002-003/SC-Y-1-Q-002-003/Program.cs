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
                new Product(7, "Del Monte Pineapple Juice 1L (6-pack)", 549, 0), // Not Sponsored 🥲
                // Making product 7 at 0 stock for checking.
                new Product(8, "C2 Green Tea (Case of 24)", 489, 50), // Not Sponsored 🥲
                new Product(9, "Champion Detergent Powder (Sack 3kg)", 289, 40), // Not Sponsored 🥲
                new Product(10, "Johnson’s Baby Powder (Case 12pcs)", 999, 40), // Not Sponsored 🥲
                new Product(11, "USB Flash Drive 32GB (Box of 10)", 1299, 25),
                new Product(12, "Closeup Toothpaste (Box of 6)", 489, 55), // Not Sponsored 🥲
                // The "9", budol of marketing
            };

            Console.Clear();
            // Main loop
            while (true)
            {
                //Display the menu using a loop
                Console.WriteLine("==========[ MENU ]==========");
                foreach (Product p in products)
                {
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
                bool IsInt1 = int.TryParse(Userinput1, out SelectedProductID);
                int MainIndex = -1; // Index used to track

                if (IsInt1)
                {
                    // Invalid product number checker
                    bool productisValid = false;

                    // Using for instead of foreach.
                    // Making it easier for me to track the selected product.
                    for(int i = 0; i < products.Length; i++)
                    {
                        Product p = products[i];
                        MainIndex = i;
                        if (SelectedProductID == p.Pid)
                        {
                            productisValid = true;
                        }
                    }

                    if (!productisValid) {
                        Console.WriteLine("Product ID does not exist.");
                        Console.Write("Press Enter to Continue..");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Please enter a numerical product ID.");
                    Console.Write("Press Enter to Continue..");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                //o Enter quantity
                Console.Write("Enter the Quantity of the Product: ");
                string Userinput2 = Console.ReadLine() ?? "";

                // Non-numeric input checker
                int SelectedProductQuantity;
                bool IsInt2 = int.TryParse(Userinput2, out SelectedProductQuantity);

                if (IsInt2)
                {
                    // o Invalid quantity (Maybe checking for negativity and 0 quantity)
                    if (SelectedProductQuantity <= 0) {
                        Console.WriteLine("Please enter a quantity higher than zero.");
                        continue;
                    }
                    //putting the other part down because I don't want to fill this part a lot.
                }
                else
                {
                    Console.WriteLine("Please enter a numerical quantity.");
                    Console.Write("Press Enter to Continue..");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (!products[MainIndex].hasEnoughStock(SelectedProductQuantity))
                {
                    Console.WriteLine("Not enough stock available.");
                }
            }
        }
    }
}