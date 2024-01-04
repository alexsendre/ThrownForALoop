List<Product> products = new()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        StockDate = new DateTime(2023, 10, 20),
        ManufactureYear = 2010,
        Condition = 3.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.33M,
        Sold = false,
        StockDate = new DateTime(2022, 12, 19),
        ManufactureYear = 2014,
        Condition = 2.5
    },
    new Product()
    {
        Name = "Boomerang",
        Price = 20.00M,
        Sold = true,
        StockDate = new DateTime(2021, 4, 22),
        ManufactureYear = 2003,
        Condition = 4.8
    },
    new Product()
    {
        Name = "Frisbee",
        Price = 13.99M,
        Sold = false,
        StockDate = new DateTime(2005, 3, 21),
        ManufactureYear = 2002,
        Condition = 3.7
    },
    new Product()
    {
        Name = "Golf Putter",
        Price = 33.33M,
        Sold = false,
        StockDate = new DateTime(2017, 8, 28),
        ManufactureYear = 2016,
        Condition = 2.1
    }
};

string greeting = @"Welcome to Thrown For a Loop,
Your one-stop shop for used sporting equipment";
Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
        0. Exit
        1. View All Products
        2. View Product Details
        3. View Latest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
        break;
    }    
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products: ");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewProductDetails()
{
    ListProducts();
    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Type only integers please.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please chose only existing items!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Invalid. Try again");
        }

    }

    DateTime now =  DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine(@$"You chose: {chosenProduct.Name}, which costs {chosenProduct.Price} dollars and {(chosenProduct.Sold ? "has been sold." : $"has been in stock for {timeInStock.Days} days.")}
    It is now {now.Year - chosenProduct.ManufactureYear} years old.");
}

void ViewLatestProducts()
{
    List<Product> latestProducts = new();
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    foreach (Product product in products)
    {
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }

    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}

