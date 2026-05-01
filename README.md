# SCY-Y1-Q-002-003
A simple shopping cart system : Point: Implementation of Object Oriented Programming

# Project Overview

This project is an upgraded version of a Shopping Cart System made using C#. It started as a simple console program, but slowly grew into a more complete system that feels closer to a real checkout system you see in actual stores. The goal was to meet all requirements while also making the program more organized, reliable, and easier to use.

# Features I Implemented

The system now includes a full cart management menu where users can check what’s inside their cart, remove items, update quantities, clear everything, or proceed to checkout. Every action has proper validation so the program doesn’t break even if the user inputs something wrong or unexpected.

A product search feature is also added. Users can search products by name, and the system will still try to be helpful even if the input is not perfect. It can detect exact matches, starting matches, and partial matches, so finding items is easier and more flexible.

Products now also have categories like Food, Electronics, Clothing, and Personal Care. Users can filter products based on these categories, which makes browsing less messy and more organized, especially when the product list gets longer.

A low-stock alert system runs after checkout and also during product viewing. If a product reaches five stocks or below, it gets flagged so the user is aware that it is running low. This helps simulate real inventory behavior.

The checkout system now includes full payment validation. The user must enter a valid numeric payment that is equal to or greater than the final total. If the payment is not enough, the system will keep asking until it becomes valid. Once accepted, it calculates and shows the change clearly.

Each checkout generates a receipt that includes a receipt number, date and time, purchased items, grand total, discount (if any), final total, payment, and change. It is designed to feel like a real transaction record that can be checked later.

The system also keeps an order history during runtime. Every completed transaction is stored and can be viewed anytime while the program is running. It helps track all purchases without losing data within the session.

All Y/N prompts are strictly validated. The program will not continue until the user gives a proper answer, which helps prevent random inputs from breaking the flow.

# Code Structure

The system is built using arrays for products, cart items, and transaction history. Object-oriented programming is used through Product, CartItem, and History classes to keep the structure clean and reusable.

Stock management is automatically updated when adding to cart, updating quantities, removing items, and during checkout. This ensures that the stock values always stay accurate.

Validation is applied in almost every input area, especially in product selection, quantity input, and payment handling. The goal is to make the program stable even when users try unexpected inputs.

# AI Usage

AI was used mainly as a support tool during development. It helped me understand Git commands and workflows since I was not familiar with Git at the start of this project. It also helped me identify missing requirements and acted like a checker whenever I was unsure if something was correct or complete.

The gitignore file used in this project came from a public Git repository and was later improved with the help of AI to better fit the project setup. AI also helped me understand and fix Git errors that I encountered during development, especially when I was still learning how everything works.

Aside from that, the actual logic, structure, and implementation of the system were fully created by me. After learning how Git works and getting comfortable with it, I handled everything on my own. AI was only used for guidance and clarification, not for writing the main program logic.

# Final Note

This project is submitted as a Pull Request for review, and I understand that Part 2 should not be directly pushed to the main branch. Screenshots and sample outputs are included as required, along with meaningful commits that show the progress of the system.

I’m still learning and improving through this process, and I tried my best to follow all requirements carefully even when some parts felt confusing at first.

I’m sorry for the delay in submission. At the time, there was no electricity, and I couldn’t upload the final output properly even though it was already finished. I understand the inconvenience this may have caused, and I truly appreciate the time taken to review my work.
