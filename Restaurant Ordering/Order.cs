/****************************************************************/
/* Name:     Alfin Rahardja                                     */
/* Class:    CS 364 - .NET Programming                          */
/* Due-date: March 8, 2016                                      */
/****************************************************************/

/****************************************************************/
/* Class Order stores the information about the number of       */
/* customer's order, and also calculates the bill for the       */
/* order.                                                       */
/****************************************************************/

namespace Restaurant_Ordering
{
    class Order
    {
        // Class constant members
        private const float BURGER_SAND_PRICE = 4.19f,  // The price for one burger sandwich
                            CHICKEN_SAND_PRICE = 4.99f, // The price for one chicken sandwich
                            FISH_SAND_PRICE = 3.99f,    // The price for one fillet fish sandwich
                            HOTDOG_SAND_PRICE = 3.59f,  // The price for one hot dog sandwich
                            FRIES_PRICE = 2.19f,        // The price for one french fries
                            SODA_PRICE = 1.00f,         // The price for one can of soda
                            TAX = 0.075f;               // The meal's tax percentage

        // Class variable members
        private int burgerSandwichTotal,  // Total number of burger sandwich customer orders
                    chickenSandwichTotal, // Total number of chicken sandwich customer orders
                    fishSandwichTotal,    // Total number of fish sandwich customer orders
                    hotdogSandwichTotal,  // Total number of hot dog sandwich customer orders
                    friesTotal,           // Total number of french fries customer orders
                    sodaTotal;            // Total number of soda customer orders

        // Constructor that takes no paramater
        public Order()
        {
            burgerSandwichTotal = 0;
            chickenSandwichTotal = 0;
            fishSandwichTotal = 0;
            hotdogSandwichTotal = 0;
            friesTotal = 0;
            sodaTotal = 0;
        }

        //Constructor that takes parameters
        public Order(int totalBurgerSand = 0, int totalChickenSand = 0, int totalFishSand = 0, 
            int totalHotdogSand = 0, int totalFries = 0, int totalSoda = 0)
        {
            burgerSandwichTotal = totalBurgerSand;
            chickenSandwichTotal = totalChickenSand;
            fishSandwichTotal = totalFishSand;
            hotdogSandwichTotal = totalHotdogSand;
            friesTotal = totalFries;
            sodaTotal = totalSoda;
        }

        // Class' mutators and accessors
        public int BurgerSandwichTotal
        {
            get { return burgerSandwichTotal; }
            set { burgerSandwichTotal += value; }
        }

        public int ChickenSandwichTotal
        {
            get { return chickenSandwichTotal; }
            set { chickenSandwichTotal += value; }
        }

        public int FishSandwichTotal
        {
            get { return fishSandwichTotal; }
            set { fishSandwichTotal += value; }
        }

        public int HotdogSandwichTotal
        {
            get { return hotdogSandwichTotal; }
            set { hotdogSandwichTotal += value; }
        }

        public int FriesTotal
        {
            get { return friesTotal; }
            set { friesTotal += value; }
        }

        public int SodaTotal
        {
            get { return sodaTotal; }
            set { sodaTotal += value; }
        }

        // Calculate the price for all burger sandwiches customer orders
        public float BurgerPrice
        {
            get { return BurgerSandwichTotal * BURGER_SAND_PRICE; }
        }

        // Calculate the price for all chicken sandwiches customer orders
        public float ChickenPrice
        {
            get { return ChickenSandwichTotal * CHICKEN_SAND_PRICE; }
        }

        // Calculate the price for all fillet fish sandwiches customer orders
        public float FishPrice
        {
            get { return FishSandwichTotal * FISH_SAND_PRICE; }
        }

        // Calculate the price for all hot dog sandwiches customer orders
        public float HotdogPrice
        {
            get { return HotdogSandwichTotal * HOTDOG_SAND_PRICE; }
        }

        // Calculate the price for all french fries customer orders
        public float FriesPrice
        {
            get { return FriesTotal * FRIES_PRICE; }
        }

        // Calculate the price for all can of soda customer orders
        public float SodaPrice
        {
            get { return SodaTotal * SODA_PRICE; }
        }

        // Calculate the sub total for all items
        public float SubTotal
        {
            get { return BurgerPrice + ChickenPrice + FishPrice + HotdogPrice + FriesPrice + SodaPrice; }
        }

        // Calculate the meal's tax customer must pay
        public float Tax
        {
            get { return SubTotal * TAX; }
        }

        // Calculate the total price with tax included
        public float Total
        {
            get { return SubTotal + Tax; }
        }
    }
}
