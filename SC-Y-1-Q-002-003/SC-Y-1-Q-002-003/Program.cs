using System.Xml.Linq;

namespace SC_Y_1_Q_002_003
{
    class Program
    {
        // ------------|INITIALIZATION OF OBJECTS|---------------

        // Globalizing them or making them static so they belong to the class and can be used by all methods

        //1. Create an array of Product objects as your store menu

        // Create an array of Product objects as your store menu 
        // created an array of Product
        // New: Added a category for each object.
        static Product[] products = new Product[] {
                new Product(1, "Electric Fan", 1399, 50, "Electronics"),
                new Product(2, "Rexona", 89, 25, "Personal Care"), // Not Sponsored 🥲
                new Product(3, "iPhone 17 Pro Max", 86990, 10, "Electronics"), // Not Sponsored 🥲
                new Product(4, "3 White T-Shirts", 550, 35, "Clothing"), // Changing it to Tshirt for Clothing
                new Product(5, "Pair of Shoes", 1499, 60, "Clothing"),
                new Product(6, "Lucky Me Pancit Canton (Pack of 6)", 89, 60, "Food"), // Not Sponsored 🥲
                // Making product 7 at 0 stock for checking.
                new Product(7, "Del Monte Pineapple Juice 1L (6-pack)", 549, 0, "Food"), // Not Sponsored 🥲
                new Product(8, "C2 Green Tea (Case of 24)", 489, 50, "Food"), // Not Sponsored 🥲
                new Product(9, "Champion Detergent Powder (Sack 3kg)", 289, 40, "Personal Care"), // Not Sponsored 🥲
                new Product(10, "Johnson’s Baby Powder (Case 12pcs)", 999, 40, "Personal Care"), // Not Sponsored 🥲
                new Product(11, "USB Flash Drive 32GB (Box of 10)", 1299, 25, "Electronics"),
                new Product(12, "Closeup Toothpaste (Box of 6)", 489, 55, "Personal Care"), // Not Sponsored 🥲
                // The "9", budol of marketing
            };
        // "fixed-size cart array"
        // Limiting the cart items to 20.
        static CartItem[] cartItems = new CartItem[20];
        static int CartIndex = 0; // tracking the index of the used cart
        static History[] DoneTransactions = new History[1000]; // 1000 because of the 0001
        public static void ViewProduct()
        {
            //Display the menu using a loop
            Console.Clear();
            Console.WriteLine("==========[ List of Products ]==========");
            foreach (Product p in products)
            {
                Console.WriteLine(p.DisplayProduct());
            }
            // Since it's only view I'll just put this as it's functionalities
            Console.Write("Press Enter to Continue..");
            Console.ReadLine();
        }
        public static void AddToCart()
        {
            Console.Clear();
            while (true)
            {
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
                    for (int i = 0; i < products.Length; i++)
                    {
                        Product p = products[i];
                        if (SelectedProductID == p.Pid)
                        {
                            MainIndex = i;
                            productisValid = true;
                        }
                    }

                    if (!productisValid)
                    {
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

                // Blocking it already when the picked item does not have stock.
                // Less work for user
                if (products[MainIndex].PStock == 0)
                {
                    Console.WriteLine("This product is out of stock.");
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
                    if (SelectedProductQuantity <= 0)
                    {
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

                bool enough = false;

                if (products[MainIndex].hasEnoughStock(SelectedProductQuantity))
                {
                    enough = true;
                }

                if (!enough)
                {
                    Console.WriteLine("Not enough stock available.");
                    continue; // didn't see it earlier lol
                }


                /*
                     If valid: 
                        o Compute itemTotal = Price * Quantity 
                        o Add item to cart 
                        o Deduct quantity from RemainingStock 
                */

                // o Compute itemTotal = Price * Quantity ✔️
                double item_total = products[MainIndex].getItemTotal(SelectedProductQuantity);

                // o Add item to cart 

                /*
                        o Prevent adding items if the cart is already full 
                        o Display an appropriate message(example: “Cart is full.”)
                */

                if (CartIndex == cartItems.Length)
                {
                    Console.WriteLine("Cart is full.");
                    continue;
                }
                // Using the example to make it identical to the document.


                /*
                     Prevent duplicate cart entries 
                        o If the same product is selected again, 
                          update the existing cart quantity and subtotal 
                          instead of adding a new cart row
                */

                // Using for loop for tracing.
                for (int ci = 0; ci < cartItems.Length; ci++)
                {
                    if (cartItems[ci] != null && products[MainIndex].Pid == cartItems[ci].Cid)
                    {
                        cartItems[ci].Cquantity += SelectedProductQuantity;
                        cartItems[ci].Cit = cartItems[ci].Cprice * cartItems[ci].Cquantity;
                        products[MainIndex].deduct_stock(SelectedProductQuantity);
                        Console.WriteLine("Item quantity updated in cart.");
                        break;
                    }
                    else if (cartItems[ci] == null)
                    {
                        cartItems[ci] = new CartItem(
                                products[MainIndex].Pid,
                                products[MainIndex].Pname,
                                products[MainIndex].Pprice,
                                SelectedProductQuantity,
                                item_total
                            );
                        products[MainIndex].deduct_stock(SelectedProductQuantity);
                        CartIndex++;
                        Console.WriteLine("Item has been added to cart.");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                // Allow the user to keep adding items until they choose N 
                // All Y/N prompts must re-prompt until valid input is entered. 
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Still want to keep adding items? (Y/N)");
                    Console.Write("Decision: ");
                    var looper = Console.ReadLine() ?? "";

                    if (looper.ToUpper() == "N")
                    {
                        return; // this will go out of the func itself 
                    }
                    else if (looper.ToUpper() == "Y")
                    {
                        break; // this will break the loop and go back to the func loop
                    }
                    else
                    {
                        Console.Clear();
                        // Invalid input. Please enter Y or N only. 
                        Console.WriteLine("Invalid input. Please enter Y or N only. ");
                        Console.Write("Press Enter to Continue..");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                }

            }
        }
        public static void CheckOut()
        {
            Console.Clear();
            // Display the receipt 
            // Error Occured: Because earlier I'm fet   ching null items. ( minutes of thinking.. )
            // Solution: Condition for item not being null.
            Console.WriteLine("SIX SEVEN EVELYN");
            Console.WriteLine("THANK YOU FOR BUYING!!\n");
            foreach (CartItem item in cartItems)
            {
                if (item != null) // the solution.
                {
                    Console.WriteLine(item.show_receipt());
                }
            }

            // Grand total process
            double grandtotal = 0;
            double discount = 0;

            foreach (CartItem item in cartItems)
            {
                if (item != null)
                {
                    grandtotal += item.Cit;
                }
            }

            // If the Grand Total is 5000 or more, apply a 10% discount
            if (grandtotal >= 5000)
            {
                discount = grandtotal * 0.10;
            }
            double finalprice = grandtotal - discount;

            // Displaying grand total, discount, and final total
            Console.WriteLine($"\nTotal Price: {grandtotal:N2}");
            Console.WriteLine($"Discount: {discount:N2}");
            Console.WriteLine($"Final Price: {finalprice:N2} \n");
            Console.WriteLine("Contact Number: 0967 990 9900 67\n");

            // Checkout Payment Validation

            Console.Write("Enter Payment: ");

            // • Payment must be numeric. 
            // • Payment must be greater than or equal to final total. 
            // • If payment is insufficient, ask again. 

            // still tryparse
            // all three conditions to validate already to lessen the lines
            double payment;
            while (!double.TryParse(Console.ReadLine(), out payment) || payment < finalprice)
            {
                // • If payment is insufficient, ASK AGAIN. 
                Console.WriteLine("Invalid or insufficient payment. Try again.");
                // No one is breaking it bro
                Console.Write("Enter Payment: ");
            }

            double change = payment - finalprice;

            Console.WriteLine($"Payment: {payment:N2}");
            Console.WriteLine($"Change: {change:N2}");

            // Receipt Number and Date
            /*
                 Each receipt should show:
                    • Receipt number 
                    • Checkout date and time 
                    • Purchased items 
                    • Grand total 
                    • Discount 
                    • Final total 
                    • Payment 
             */

            // incrementation of numbers making it an ID
            int receiptNumber = 1;

            for (int i = 0; i < DoneTransactions.Length; i++)
            {
                if (DoneTransactions[i] != null)
                {
                    receiptNumber++;
                }
            }

            History newHistory = new History(
                receiptNumber, // • Receipt number
                DateTime.Now,  // • Checkout date and time 
                grandtotal,    // • Grand total 
                discount,      // • Discount 
                finalprice,    // • Final total
                payment,       // • Payment
                change         // • Change
            );

            // Store the transaction to history
            for (int i = 0; i < DoneTransactions.Length; i++)
            {
                if (DoneTransactions[i] == null)
                {
                    DoneTransactions[i] = newHistory;
                    break;
                }
            }

            // receipt from the history (with rnumber and rdate)
            Console.WriteLine("\n---------| Receipt |---------");
            Console.WriteLine(newHistory.DisplayFullReceipt());

            // clearing the cart after checking out
            for (int i = 0; i < cartItems.Length; i++)
            {
                cartItems[i] = null;
            }
            CartIndex = 0;

            // I deleted the stock checking part as it can be seen in the view product

            Console.Write("Press Enter to Continue..");
            Console.ReadLine();
        }

        public static void ViewCart()
        {
            Console.Clear();
            foreach (CartItem item in cartItems)
            {
                if (item != null) Console.WriteLine(item.show_receipt());
            }
            Console.Write("Press Enter to Continue..");
            Console.ReadLine();
        }
        public static void RemoveCartItem()
        {
            Console.Clear();
            while (true)
            {
                bool isRemoving = false;
                // adding an exit way here
                Console.WriteLine("Important Note: Press 'E' to exit");
                Console.Write("Enter Product ID to remove : ");
                // Base on my experience every removal or deletion requires confirmation
                var itemtoremove = Console.ReadLine() ?? "";
                if (itemtoremove.ToUpper() == "E") return;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Important Note: Press 'E' to exit");
                    Console.WriteLine($"Are you sure you want to remove item [{itemtoremove}] ? (Y/N)");
                    Console.Write("Response : ");
                    string response = Console.ReadLine() ?? "";
                    if (response.ToUpper() == "Y")
                    {
                        isRemoving = true;
                        break;
                    }
                    else if (response.ToUpper() == "N")
                    {
                        Console.WriteLine("Removing the item cancelled.");
                        Console.Write("Press Enter to Continue..");
                        Console.ReadLine();
                        break;
                    }
                    else if (response.ToUpper() == "E") return;
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N only. ");
                        Console.Write("Press Enter to Continue..");
                        Console.ReadLine();
                    }
                }

                if (!isRemoving)
                {
                    continue;
                }

                int ItemToRemove;
                bool ItemIsInt = int.TryParse(itemtoremove, out ItemToRemove);

                /* 
                    Got a problem, I tried to just null it but then realize that
                    it will cause an issue for tons of functionalities such as 
                    checkout and add to cart.

                    then I tried to put the last object inside that hole, it got it right
                    but then I also saw that removing an item 

                    this took me so much just making all of the items to move
                    from the beginning because there will be a hole inside the cart 
                */

                for (int i = 0; i < CartIndex; i++)
                {
                    if (cartItems[i] != null && cartItems[i].Cid == ItemToRemove)
                    {
                        // FIX: return stock BEFORE shifting
                        for (int k = 0; k < products.Length; k++)
                        {
                            if (products[k].Pid == cartItems[i].Cid)
                            {
                                products[k].PStock += cartItems[i].Cquantity;
                                break;
                            }
                        }

                        for (int j = i; j < CartIndex - 1; j++)
                        {
                            cartItems[j] = cartItems[j + 1];
                        }

                        cartItems[CartIndex - 1] = null;
                        CartIndex--;

                        Console.WriteLine("Item removed successfully.");
                        break;
                    }
                }
            }
        }

        public static void ClearCart()
        {
            // I don't really know what to say to this. It's pretty easy.
            // 2 steps
            while (true)
            {
                // 1. Confirmation
                Console.WriteLine($"Are you sure you want to clear the cart? (Y/N)");
                Console.Write("Response : ");
                string response = Console.ReadLine() ?? "";
                if (response.ToUpper() == "Y")
                {
                    break;
                }
                else if (response.ToUpper() == "N")
                {
                    Console.WriteLine("Clearing the cart cancelled.");
                    Console.Write("Press Enter to Continue..");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N only. ");
                    Console.Write("Press Enter to Continue..");
                    Console.ReadLine();
                    continue;
                }
            }

            // OHHH Such an oblivious and huge headed person, thought it was just 2 steps

            // Put back the stocks to products
            for (int i = 0; i < cartItems.Length; i++)
            {
                if (cartItems[i] != null)
                {
                    for (int j = 0; j < products.Length; j++)
                    {
                        if (products[j].Pid == cartItems[i].Cid)
                        {
                            products[j].PStock += cartItems[i].Cquantity;
                            break;
                        }
                    }
                }
            }

            // 2. Nullification
            for (int i = 0; i < cartItems.Length; i++)
            {
                cartItems[i] = null;
            }

            CartIndex = 0;
        }
        public static void UpdateCartQuantity()
        {
            while (true)
            {
                // for this there will be another 2 steps
                Console.Clear();
                int itemtoupdate = -1; // the index
                int productstock = -1;

                Console.WriteLine("UPDATE ITEM QUANTITY");
                Console.Write("Please specify the Item ID to update: ");
                var temp1 = Console.ReadLine() ?? "";

                int Account;
                bool temp1IsInt = int.TryParse(temp1, out Account);

                if (temp1IsInt)
                {
                    for (int i = 0; i < cartItems.Length; i++)
                    {
                        if (cartItems[i] != null && cartItems[i].Cid == Account)
                        {
                            itemtoupdate = i;
                            break;
                        }
                    }

                    if (itemtoupdate == -1)
                    {
                        Console.WriteLine("Item does not exist inside the cart");
                        Console.Write("Press Enter to Continue..");
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an item ID");
                    Console.Write("Press Enter to Continue..");
                    Console.ReadLine();
                    continue;
                }

                Console.Write("Enter the new quantity: ");
                var temp2 = Console.ReadLine() ?? "";

                int QuantityToChange;
                bool tempIsInt = int.TryParse(temp2, out QuantityToChange);

                if (tempIsInt)
                {
                    if (QuantityToChange <= 0)
                    {
                        Console.WriteLine("Quantity must be greater than zero.");
                        Console.Write("Press Enter to Continue..");
                        Console.ReadLine();
                        continue;
                    }

                    // 1. get back the quantity to the product
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (products[i].Pid == cartItems[itemtoupdate].Cid)
                        {
                            productstock = i;

                            // return old quantity
                            products[i].PStock += cartItems[itemtoupdate].Cquantity;

                            // check if enough stock for new quantity
                            if (products[i].PStock >= QuantityToChange)
                            {
                                products[i].PStock -= QuantityToChange;
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Stock");
                                Console.Write("Press Enter to Continue..");
                                Console.ReadLine();

                                // restore original deduction
                                products[i].PStock -= cartItems[itemtoupdate].Cquantity;

                                productstock = -1;
                            }

                            break;
                        }
                    }

                    // 2. update the quantity
                    if (productstock != -1)
                    {
                        cartItems[itemtoupdate].Cquantity = QuantityToChange;
                        cartItems[itemtoupdate].Cit = cartItems[itemtoupdate].Cprice * QuantityToChange;

                        Console.WriteLine("Item quantity updated successfully.");
                        Console.Write("Press Enter to Continue..");
                        Console.ReadLine();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a numerical quantity.");
                    Console.Write("Press Enter to Continue..");
                    Console.ReadLine();
                }
            }
        }

        public static void ManageCart()
        {
            /*
                1. Cart Management Menu 
                Add a cart menu where the user can: 
                • View cart  
                • Remove an item from cart  
                • Update item quantity  
                • Clear cart  
                • Checkout  

                This is a good (next step) because many students already have add-to-cart logic, but not full cart 
                management. 
             
             */
            while (true)
            {
                // put it here cuz it's not working in the function loop
                Console.Clear();
                Console.WriteLine("Cart Management Menu");
                Console.WriteLine("1. View Cart");
                Console.WriteLine("2. Remove an item from the cart");
                Console.WriteLine("3. Update item quantity");
                Console.WriteLine("4. Clear Cart");
                Console.WriteLine("5. Check-out");
                Console.WriteLine("E. Exit");

                Console.Write("\nPlease proceed by selecting an option : ");
                // I don't really know why I'm making it var instead of just string. still the same lol.
                var CartManagementMenuOption = Console.ReadLine() ?? "";

                if (CartManagementMenuOption.ToUpper() == "E") return;

                int CartOption;
                bool CartManagementMenuOptionisInt = int.TryParse(CartManagementMenuOption, out CartOption);

                if (CartManagementMenuOptionisInt)
                {
                    switch (CartOption)
                    {
                        case 1:
                            ViewCart();
                            break;
                        case 2:
                            RemoveCartItem();
                            break;
                        case 3:
                            UpdateCartQuantity();
                            break;
                        case 4:
                            ClearCart();
                            break;
                        case 5:
                            CheckOut();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please select an existing option.");
                            Console.Write("Press Enter to Continue..");
                            Console.ReadLine();
                            continue;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please select an existing option.");
                    Console.Write("Press Enter to Continue..");
                    Console.ReadLine();
                    continue;
                }
            }
        }
        static void Main(string[] args)
        {
            // Main loop of the program
            while (true)
            {

                /*
                      * Create an enhanced version of your Shopping Cart System. Your program must now allow 
                        users to manage their cart before checkout, validate payment, generate a receipt with receipt 
                        number and date/time, show low-stock alerts, and keep an order history during the program 
                        run. You must still use classes, objects, arrays, validation, and stock management.

                        Features to be implemented: 

                        * Cart management menu ✔️
                        * Product search ✔️
                        * Product categories ✔️
                        * Low stock alert ✔️
                        * Payment validation ✔️
                        * Receipt system ✔️
                        * Order history ✔️
                        * Main menu system ✔️
                        * Input validation ✔️
                 */

                /* 
                    While thinking like a programmer who did a lot of POS with a GUI I notice a lot of errors in my mind
                    Console based system will be hard to navigate by trying to put tons of functionalities in a single section
                    of the syetem because it would lead to tons of complexities, therefore I would like to put tons of 
                    considerations and understanding in this and create a place for the system to be managed.

                    Considering that this is a Console Based System I would like to create a Main Menu
                    containing all the essential functionalities and use functions to make it more cleaner.
                 */

                Console.Clear();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("1. View Product"); // Showing all the current products along with it's Stock Reorder Alert
                Console.WriteLine("2. Search Product"); // This will be a function for the user if the user know what product to buy
                Console.WriteLine("3. Filter by Category"); // Checking the products again but by Category  
                Console.WriteLine("4. Add to Cart"); // Adding a product inside a cart
                Console.WriteLine("5. Manage Cart"); // Where the Cart Management Menu is
                Console.WriteLine("6. View Order History"); // For viewing the completed transactions
                Console.WriteLine("E. Exit"); // Exiting the program/system itself 

                Console.Write("\nSelect an option : ");
                var menuaction = Console.ReadLine() ?? "";

                if (menuaction.ToUpper() == "E") return;

                // still using tryparse :>
                int option;
                bool MenuActionisInt = int.TryParse(menuaction, out option);


                // Breaking each functionalities of the program into functions to make it more easier to manage

                if (MenuActionisInt)
                {
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            ViewProduct();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            Console.Clear();
                            AddToCart();
                            break;
                        case 5:
                            Console.Clear();
                            ManageCart();
                            break;
                        case 6:
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please select an existing option.");
                            Console.Write("Press Enter to Continue..");
                            Console.ReadLine();
                            continue;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please select an existing option.");
                    Console.Write("Press Enter to Continue..");
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}