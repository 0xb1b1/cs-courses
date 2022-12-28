using System;
// Import JSON serializer
using System.Text.Json;
using System.Collections.Generic;

// Import Item class from file Models.cs
using static CLIShop.Item;
using static CLIShop.City;

namespace CLIShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Greet the user
            Console.WriteLine("Welcome to the CLI Shop!\n\nSelect the city you are currently residing in:");

            //! cities.json
            // Create a list of cities from resources/cities.json
            // Check if the file exists; if not, create it
            if (!File.Exists("resources/cities.json"))
            {
                // Create the file
                File.Create("resources/cities.json");
                // Write empty JSON to the file
                File.WriteAllText("resources/cities.json", "{\"cities\": []}");
                Console.WriteLine("Error: Could not find cities.json\nCreated cities.json; halting...");
            }
            List<City> cities = new List<City>();
            string cities_json = File.ReadAllText("resources/cities.json");
            /*
                cities.json:
                {
                    "cities": [
                        "New York",
                        "Berlin"
                    ]
                }
            */
            // Parse the JSON
            var cities_parsed = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(cities_json);
            if (cities_parsed == null)
            {
                Console.WriteLine("Error: Could not parse cities.json");
                return;
            }
            foreach (var cities_raw in cities_parsed)
            {
                foreach (var name in cities_raw.Value)
                {
                    cities.Add(new City(name));
                }
            }

            // List the cities
            for (int i = 0; i < cities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cities[i].Name}");
            }

            City selectedCity = cities[0];
            bool validCity = false;
            while (!validCity)
            {
                // Get the user's input
                Console.Write("Select a city: ");
                int cityIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                if (cityIndex >= 0 && cityIndex < cities.Count)
                {
                    validCity = true;
                    selectedCity = cities[cityIndex];
                }
                else
                {
                    Console.WriteLine("Invalid city. Please try again.");
                }
            }

            // Print the selected city
            Console.WriteLine($"{selectedCity.Name} city selected!");

            // Create a list of items from resources/items.json
            /*
                items.json:
                {
                    "items": [
                        {
                            "name": "Apple",
                            "price": 199,
                            "description": "A delicious apple",
                            "weight": 0.5
                        },
                        {
                            "name": "Orange",
                            "price": 299,
                            "description": "A delicious orange",
                            "weight": 0.5
                        }
                    ]
                }
            */

            //! items.json
            // Check if the file exists; if not, create it
            if (!File.Exists("resources/items.json"))
            {
                // Create the file
                File.Create("resources/items.json");
                // Write empty JSON to the file
                File.WriteAllText("resources/items.json", "{\"items\": []}");
                Console.WriteLine("Error: Could not find itema.json\nCreated items.json; halting...");
                return;
            }
            string items_json = File.ReadAllText("resources/items.json");
            // Parse the JSON
            // Serialize each item to a Item object
            var items_parsed_raw = JsonSerializer.Deserialize<Dictionary<string, List<Item>>>(items_json);
            // Select list of items
            var items_parsed = items_parsed_raw["items"];
            if (items_parsed == null)
            {
                Console.WriteLine("Error: Could not parse items.json");
                return;
            }

            // Parse available items
            /*
                available_peoducts.json
                {
                    "available_items": {
                        "Moscow": [
                            "Apple",
                            "Orange"
                        ],
                        "Saint Petersburg": [
                            "Apple",
                            "Orange"
                        ]
                    }
                }
            */
            var available_items_parsed = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<string>>>>(File.ReadAllText("resources/available_items.json"));
            if (available_items_parsed == null)
            {
                Console.WriteLine("Error: Could not parse available_items.json");
                return;
            }
            // Store all available items for the selected city
            List<string> available_items = new List<string>();
            var available_items_list = available_items_parsed["available_items"][selectedCity.Name];
            foreach (var item in available_items_list)
            {
                available_items.Add(item);
            }
            foreach (var item in items_parsed)
            {
                if (available_items.Contains(item.Name)) {
                    selectedCity.AddItem(item);
                }
            }
            Console.WriteLine($"\nAvailable items in your city ({selectedCity.GetItemCount()}):");
            for (int i = 0; i < selectedCity.Items.Count; i++)
            {
                Console.WriteLine($"{selectedCity.Items[i].Name}");
            }

            //! Cart interface
            // Create a cart
            Cart cart = new Cart();
            Console.WriteLine("\n===\nWelcome to your cart!\nCurrently, it is empty. Let's add some items to it!");
            Console.WriteLine("Hints:\ncheckout — go to checkout\ncart — show current cart contentss\ntotal — get the total price of the items in the cart\nitems — toggle the list of items in the city\n");

            bool cartInterface = true;
            bool showItems = true;
            while (cartInterface) {
                // Add items to the cart
                if (showItems) {
                    Console.WriteLine("\nAvailable items:");
                    for (int i = 0; i < selectedCity.Items.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {selectedCity.Items[i].Name} - {selectedCity.Items[i].Price} UAH");
                    }
                }
                Console.Write("Select an item: ");
                string input = Console.ReadLine();
                if (input == "checkout")
                {
                    cartInterface = false;
                    break;
                }
                else if (input == "total") {
                    Console.WriteLine($"\nTotal: {cart.GetTotal()} UAH");
                }
                else if (input == "items")
                {
                    showItems = !showItems;
                }
                else if (input == "cart")
                {
                    Console.WriteLine($"\n{cart.GetCartSummary()}");
                }
                else
                {
                    // Try converting the input to an integer, if it fails, it's not a valid item
                    try { Convert.ToInt32(input); }
                    catch (Exception) { Console.WriteLine("Invalid item. Please try again."); continue; }

                    int itemIndex = Convert.ToInt32(input) - 1;
                    if (itemIndex >= 0 && itemIndex < selectedCity.Items.Count)
                    {
                        cart.AddItem(selectedCity.Items[itemIndex]);
                        Console.WriteLine($"\n{selectedCity.Items[itemIndex].Name} added to cart!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid item. Please try again.");
                    }
                }
            }
            //! Checkout interface

            // Calculate delivery price by item count
            if (cart.Items.Count > 0 && cart.Items.Count <= 3)
            {
                cart.setDeliveryPrice(50);
            }
            else if (cart.Items.Count > 3 && cart.Items.Count <= 6)
            {
                cart.setDeliveryPrice(100);
            }
            else if (cart.Items.Count > 6 && cart.Items.Count <= 10)
            {
                cart.setDeliveryPrice(150);
            }
            else if (cart.Items.Count > 10)
            {
                cart.setDeliveryPrice(200);
            }
            Console.WriteLine($"\n===\nWelcome to checkout!\n\nYour cart contains:\n{cart.GetCartSummary()}");
            Console.WriteLine($"Total: {cart.GetTotal()} UAH");
            Console.Write("Enter your name: ");
            string? customer_name_temp = Console.ReadLine();
            string? customer_name_temp1 = customer_name_temp != "" ? customer_name_temp : "John Doe";
            string customer_name = customer_name_temp1 ?? "John Doe";
            Console.Write("Enter your address: ");
            string? customer_address_temp = Console.ReadLine();
            string? customer_address_temp1 = customer_address_temp != "" ? customer_address_temp : "Baker Street 221B";
            string customer_address = customer_address_temp1 ?? "Baker Street 221B";
            Console.Write("Enter your phone number: ");
            string? customer_phone_temp = Console.ReadLine();
            string? customer_phone_temp1 = customer_phone_temp != "" ? customer_phone_temp : "+380000000000";
            string customer_phone = customer_phone_temp1 ?? "+380000000000";
            Console.Write("Enter your email: ");
            string? customer_email_temp = Console.ReadLine();
            string? customer_email_temp1 = customer_email_temp != "" ? customer_email_temp : "johndoe@bakers.street";
            string customer_email = customer_email_temp1 ?? "johndoe@bakers.street";

            // Confirm payment
            Console.WriteLine("\nEnter your credit card details");
            Console.Write("Card number: ");
            string? cardNumberTemp = Console.ReadLine();
            int cardNumber = Convert.ToInt32(cardNumberTemp != "" ? cardNumberTemp : "0");
            Console.Write("Card CVV: ");
            string? cardCVVTemp = Console.ReadLine();
            int cardCVV = Convert.ToInt32(cardCVVTemp != "" ? cardCVVTemp : "0");
            Console.Write("Card expiry date (MM/YY): ");
            string? cardExpiryTemp = Console.ReadLine();
            string? cardExpiryTemp1 = cardExpiryTemp != "" ? cardExpiryTemp : "01/01";
            string cardExpiry = cardExpiryTemp1 != null ? cardExpiryTemp1 : "01/01";
            Console.Write("Card holder name: ");
            string? cardHolderNameTemp = Console.ReadLine();
            string? cardHolderNameTemp1 = cardHolderNameTemp != "" ? cardHolderNameTemp : "John Doe";
            string cardHolderName = cardHolderNameTemp1 != null ? cardHolderNameTemp1 : "John Doe";

            // Check if the card is valid
            if (cardNumber == 0 || cardCVV == 0 || cardExpiry == "01/01" || cardHolderName == "John Doe")
            {
                Console.WriteLine("Error: Invalid card details");
                return;
            }

            // Success message
            Console.WriteLine($"\n===\nThank you for your purchase, {customer_name}!\nYour order will be delivered to {customer_address} within 1-2 business days.\n\nTotal: {cart.GetTotal()} UAH");
        }
    }
}
