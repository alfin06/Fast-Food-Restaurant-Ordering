/****************************************************************/
/* Name:     Alfin Rahardja                                     */
/* Class:    CS 364 - .NET Programming                          */
/* Due-date: March 8, 2016                                      */
/****************************************************************/

/****************************************************************/
/* This program takes customer's meal orders, prints the orders */
/* and calculates the total amount that customer needs to pay.  */
/****************************************************************/

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

namespace Restaurant_Ordering
{
    // The definition of a sandwich structure
    struct Sandwich
    {
        // Fields
        private string sandwichName;
        private string toppings;

        // Structure properties
        public string SandwichName
        {
            get { return sandwichName; }
            set { sandwichName = value; }
        }

        public string Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }
    
        // Structure constructor
        public Sandwich(string pName, string pToppings)
        {
            sandwichName = pName;
            toppings = pToppings;
        }
    }

    // Enumeration that stores the sandwich type
    enum SandwichType { BurgerSandwich, ChickenSandwich, FishSandwich, HotdogSandwich }
    // Enumeration that stores the sandwich's toppings
    enum Topping { Lettuce, Tomato, Onion, Mushrooms, Cheddar, Pickles}

    public sealed partial class MainPage : Page
    {
        Order newOrder = new Order(); // create a new order object

        public MainPage()
        {
            this.InitializeComponent();
        }

        // Read the user's input and print the order into the Your order box
        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(burgerButton.IsChecked == true)
                { 
                    if(int.Parse(burgerAmt.Text) <= 0)
                    {
                        ShowMessageDialog("The quantity value must be greater than 0");
                        emptyQuantityBoxes();
                    }
                    else
                    {
                        processOrder(SandwichType.BurgerSandwich.ToString(), int.Parse(burgerAmt.Text));
                        newOrder.BurgerSandwichTotal = int.Parse(burgerAmt.Text);
                        emptyQuantityBoxes();
                    }
                }
                else if(chickenButton.IsChecked == true)
                {
                    if(int.Parse(chickenAmt.Text) <= 0)
                    {
                        ShowMessageDialog("The quantity value must be greater than 0");
                        emptyQuantityBoxes();
                    }
                    else
                    {
                        processOrder(SandwichType.ChickenSandwich.ToString(), int.Parse(chickenAmt.Text));
                        newOrder.ChickenSandwichTotal = int.Parse(chickenAmt.Text);
                        emptyQuantityBoxes();
                    }
                    
                }
                else if(fishButton.IsChecked == true)
                {
                    if(int.Parse(fishAmt.Text) <= 0)
                    {
                        ShowMessageDialog("The quantity value must be greater than 0");
                        emptyQuantityBoxes();
                    }
                    else
                    {
                        processOrder(SandwichType.FishSandwich.ToString(), int.Parse(fishAmt.Text));
                        newOrder.FishSandwichTotal = int.Parse(fishAmt.Text);
                        emptyQuantityBoxes();
                    }
                }
                else if(hotdogButton.IsChecked == true)
                {
                    if(int.Parse(hotdogAmt.Text) <= 0)
                    {
                        ShowMessageDialog("The quantity value must be greater than 0");
                        emptyQuantityBoxes();
                    }
                    else
                    {
                        processOrder(SandwichType.HotdogSandwich.ToString(), int.Parse(hotdogAmt.Text));
                        newOrder.HotdogSandwichTotal = int.Parse(hotdogAmt.Text);
                        emptyQuantityBoxes();
                    }
                }
                else if(friesButton.IsChecked == true)
                {
                    if(int.Parse(friesAmt.Text) <= 0)
                    {
                        ShowMessageDialog("The quantity value must be greater than 0");
                        emptyQuantityBoxes();
                    }
                    else
                    {
                        printSideOrder(friesLabel.Text, int.Parse(friesAmt.Text));
                        newOrder.FriesTotal = int.Parse(friesAmt.Text);
                        emptyQuantityBoxes();
                    }
                }
                else
                {
                    if(int.Parse(sodaAmt.Text) <= 0)
                    {
                        ShowMessageDialog("The quantity value must be greater than 0");
                        emptyQuantityBoxes();
                    }
                    else
                    {
                        printSideOrder(sodaLabel.Text, int.Parse(sodaAmt.Text));
                        newOrder.SodaTotal = int.Parse(sodaAmt.Text);
                        emptyQuantityBoxes();
                    }
                }
            }
            catch (FormatException)
            {
                ShowMessageDialog("ERROR! Please enter a numeric value into the quantity box.");
                emptyQuantityBoxes();
            }
        }

        // Store the topping that customer chooses, then print the customer's order with its toppings
        private void processOrder(string orderName, int numberOfOrders)
        {
            string toppingsAdded = string.Empty;

            toppingsAdded = addToppings();
            uncheckAllToppings();
            Sandwich newSandwich = new Sandwich(orderName, toppingsAdded);
            printMainOrder(newSandwich, numberOfOrders);
        }

        // Store all toppings that customer chooses in a string variable
        private string addToppings()
        {
            string toppingList = string.Empty;

            toppingList += "\n            ";
            if(lettuce.IsChecked == true)
            {
                toppingList += " " + Topping.Lettuce + ".";
            }
            if(tomato.IsChecked == true)
            {
                toppingList += " " + Topping.Tomato + ".";
            }
            if(onion.IsChecked == true)
            {
                toppingList += " " + Topping.Onion + ".";
            }
            if(mushrooms.IsChecked == true)
            {
                toppingList += " " + Topping.Mushrooms + ".";
            }
            if(cheddar.IsChecked == true)
            {
                toppingList += " " + Topping.Cheddar + ".";
            }
            if(pickles.IsChecked == true)
            {
                toppingList += " " + Topping.Pickles + ".";
            }

            return toppingList;
        }
        
        // Print all sandwich orders
        private void printMainOrder(Sandwich newSandwich, int numberOfOrders)
        {
            orderSummary.Text += "\n(" + numberOfOrders + ") " + newSandwich.SandwichName + newSandwich.Toppings;
        }

        // Print all side orders like french fries and can of soda
        private void printSideOrder(string sideName, int numberOfOrders)
        {
            orderSummary.Text += "\n(" + numberOfOrders + ") " + sideName;
        }

        // Pop up an error message box
        private async void ShowMessageDialog(string errorMessage)
        {
            MessageDialog messagebox = new MessageDialog(errorMessage);
            await messagebox.ShowAsync();
        }

        // Make all quantity textboxes empty
        private void emptyQuantityBoxes()
        {
            burgerAmt.Text = string.Empty;
            chickenAmt.Text = string.Empty;
            fishAmt.Text = string.Empty;
            hotdogAmt.Text = string.Empty;
            friesAmt.Text = string.Empty;
            sodaAmt.Text = string.Empty;
        }

        // Uncheck all topping's checkboxes
        private void uncheckAllToppings()
        {
            all.IsChecked = false;
            lettuce.IsChecked = false;
            tomato.IsChecked = false;
            onion.IsChecked = false;
            mushrooms.IsChecked = false;
            cheddar.IsChecked = false;
            pickles.IsChecked = false;
        }
    
        // Check all topping's checkboxes
        private void all_Checked(object sender, RoutedEventArgs e)
        {
            lettuce.IsChecked = true;
            tomato.IsChecked = true;
            onion.IsChecked = true;
            mushrooms.IsChecked = true;
            cheddar.IsChecked = true;
            pickles.IsChecked = true;
        }

        // Uncheck all topping's checkboxes
        private void all_Unchecked(object sender, RoutedEventArgs e)
        {
            uncheckAllToppings();
        }

        // Enable the burger sandwich radio button and disable the other radio buttons
        private void burgerButton_Checked(object sender, RoutedEventArgs e)
        {
            disableQuantityBoxes();
            burgerAmt.IsEnabled = true;
            enableToppingOptions();
        }

        // Enable the fillet fish sandwich radio button and disable the other radio buttons
        private void fishButton_Checked(object sender, RoutedEventArgs e)
        {
            disableQuantityBoxes();
            fishAmt.IsEnabled = true;
            enableToppingOptions();
        }

        // Enable the chicken sandwich radio button and disable the other radio buttons
        private void chickenButton_Checked(object sender, RoutedEventArgs e)
        {
            disableQuantityBoxes();
            chickenAmt.IsEnabled = true;
            enableToppingOptions();
        }

        // Enable the hotdog sandwich radio button and disable the other radio buttons
        private void hotdogButton_Checked(object sender, RoutedEventArgs e)
        {
            disableQuantityBoxes();
            hotdogAmt.IsEnabled = true;
            enableToppingOptions();
        }

        // Enable the french fries radio button and disable the other radio buttons
        private void friesButton_Checked(object sender, RoutedEventArgs e)
        {
            disableQuantityBoxes();
            friesAmt.IsEnabled = true;
            disableToppingOptions();
        }

        // Enable the soda radio button and disable the other radio buttons
        private void sodaButton_Checked(object sender, RoutedEventArgs e)
        {
            disableQuantityBoxes();
            sodaAmt.IsEnabled = true;
            disableToppingOptions();
        }

        // Disable all textboxes for quantity value
        private void disableQuantityBoxes()
        {
            burgerAmt.IsEnabled = false;
            fishAmt.IsEnabled = false;
            chickenAmt.IsEnabled = false;
            hotdogAmt.IsEnabled = false;
            friesAmt.IsEnabled = false;
            sodaAmt.IsEnabled = false;
        }

        // Enable all topping option's checkboxes
        private void enableToppingOptions()
        {
            all.IsEnabled = true;
            lettuce.IsEnabled = true;
            tomato.IsEnabled = true;
            onion.IsEnabled = true;
            mushrooms.IsEnabled = true;
            cheddar.IsEnabled = true;
            pickles.IsEnabled = true;
        }

        // Disable all topping option's checkboxes
        private void disableToppingOptions()
        {
            all.IsEnabled = false;
            lettuce.IsEnabled = false;
            tomato.IsEnabled = false;
            onion.IsEnabled = false;
            mushrooms.IsEnabled = false;
            cheddar.IsEnabled = false;
            pickles.IsEnabled = false;
        }

        // Calculate and print the bill's information
        private void checkout_Click(object sender, RoutedEventArgs e)
        {
            burgerTotal.Text = "x" + newOrder.BurgerSandwichTotal.ToString();
            burgerPrice.Text = "$ " + newOrder.BurgerPrice.ToString("###,##0.00");

            chickenTotal.Text = "x" + newOrder.ChickenSandwichTotal.ToString();
            chickenPrice.Text = "$ " + newOrder.ChickenPrice.ToString("###,##0.00");

            fishTotal.Text = "x" + newOrder.FishSandwichTotal.ToString();
            fishPrice.Text = "$ " + newOrder.FishPrice.ToString("###,##0.00");

            hotdogTotal.Text = "x" + newOrder.HotdogSandwichTotal.ToString();
            hotdogPrice.Text = "$ " + newOrder.HotdogPrice.ToString("###,##0.00");

            frenchFriesTotal.Text = "x" + newOrder.FriesTotal.ToString();
            frenchFriesPrice.Text = "$ " + newOrder.FriesPrice.ToString("###,##0.00");

            softDrinkTotal.Text = "x" + newOrder.SodaTotal.ToString();
            softDrinkPrice.Text = "$ " + newOrder.SodaPrice.ToString("###,##0.00");

            subTotal.Text = "$ " + newOrder.SubTotal.ToString("###,##0.00");
            tax.Text = "$ " + newOrder.Tax.ToString("###,##0.00");
            total.Text = "$ " + newOrder.Total.ToString("###,##0.00");

            addItem.IsEnabled = false;
        }

        // Create a new order object and clear all previous customer's information
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            newOrder = new Order();
            orderSummary.Text = string.Empty;

            burgerTotal.Text = string.Empty;
            burgerPrice.Text = string.Empty;

            chickenTotal.Text = string.Empty;
            chickenPrice.Text = string.Empty;

            fishTotal.Text = string.Empty;
            fishPrice.Text = string.Empty;

            hotdogTotal.Text = string.Empty;
            hotdogPrice.Text = string.Empty;

            frenchFriesTotal.Text = string.Empty;
            frenchFriesPrice.Text = string.Empty;

            softDrinkTotal.Text = string.Empty;
            softDrinkPrice.Text = string.Empty;

            subTotal.Text = string.Empty;
            tax.Text = string.Empty;
            total.Text = string.Empty;

            addItem.IsEnabled = true;
        }
    }
}
