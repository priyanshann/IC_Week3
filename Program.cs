using EntityModels.Models;
using Microsoft.EntityFrameworkCore;
using Week3EntityFramework.Dtos;



//var customer = new Customer
//{
//    DateOfBirth = DateTime.Now.AddYears(-20)
//};


//Console.WriteLine("Please enter the customer firstname?");

//customer.FirstName = Console.ReadLine();

//Console.WriteLine("Please enter the customer lastname?");

//customer.LastName = Console.ReadLine();


//var customers = context.Customers.ToList();

//foreach (Customer c in customers)
//{   
//    Console.WriteLine("Hello I'm " + c.FirstName);
//}

//Console.WriteLine($"Your new customer is {customer.FirstName} {customer.LastName}");

//Console.WriteLine("Do you want to save this customer to the database?");

//var response = Console.ReadLine();

//if (response?.ToLower() == "y")
//{
//    context.Customers.Add(customer);
//    context.SaveChanges();
//}



//var sales = context.Sales.Include(c => c.Customer)
//    .Include(p => p.Product).ToList();

//var salesDto = new List<SaleDto>();

//foreach (Sale s in sales)
//{
//    salesDto.Add(new SaleDto(s));
//}



//context.Sales.Add(new Sale
//{
//    ProductId = 1,
//    CustomerId = 1,
//    StoreId = 1,
//    DateSold = DateTime.Now
//});


//context.SaveChanges();


//Console.WriteLine("Which customer record would you like to update?");

//var response = Convert.ToInt32(Console.ReadLine());

//var customer = context.Customers.Include(s => s.Sales)
//    .ThenInclude(p => p.Product)
//    .FirstOrDefault(c => c.Id == response);



//var customer1 = context.Customers.Except(s => s.Sales);

//var total = customer.Sales.Select(s => s.Product.Price).Sum();


//var customerSales = context.CustomerSales.ToList();

//var totalsales = customer.Sales



//Console.WriteLine($"The customer you have retrieved is {customer?.FirstName} {customer?.LastName}");

//Console.WriteLine($"Would you like to updated the firstname? y/n");

//var updateResponse = Console.ReadLine();

//if (updateResponse?.ToLower() == "y")
//{

//    Console.WriteLine($"Please enter the new name");

//    customer.FirstName = Console.ReadLine();
//    context.Customers.Add(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//    context.SaveChanges();
//}
//Console.ReadLine();

// ---------- Week 3 Home Works (Entity Framework) ----------
var context = new IndustryConnectWeek2Context();

// 1. Using the linq queries retrieve a list of all customers from the database who don't have sales

IEnumerable<Customer> cus1 = context.Customers
      .Where(c => !context.Sales
      .Select(s => s.CustomerId)
      .Contains(c.Id))
      .ToList();


foreach (Customer item in cus1)
{
    Console.WriteLine("Customer Name : " + item.FirstName + " " + item.LastName);
}

// 2. Insert a new customer with a sale record

DateTime bd1 = new DateTime(1981, 09, 22);
var newCustomer = new Customer()
{
    FirstName = "Priyan ",
    LastName = "Fernando",
    DateOfBirth = bd1
};


Console.WriteLine("Hi Do you want to add new Customer " + newCustomer.FirstName + " ? (y/n)");
var response = Console.ReadLine()?.ToLower();

try
{
    context.Customers.Add(newCustomer);
    context.SaveChanges();
    var newCusId = newCustomer.Id;
    var newSale = new Sale()
    {
        DateSold = DateTime.Now,
        CustomerId = newCusId,
        ProductId = 1,
        StoreId =1

    };
    context.Sales.Add(newSale);
    context.SaveChanges();
    Console.WriteLine("New Sale Added!");
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}


// 3.Add a new store

var newStore = new Store()
{
    Name = "CBD Store",
    Location ="CBD"
};
context.Stores.Add(newStore);
context.SaveChanges();

//4. Find the list of all stores that have sales

IEnumerable<Store> store = context.Stores
    .Include(s => s.Sales)
    .ToList();
    
foreach(Store st in store)
{
    Console.WriteLine("Store :" + st.Name);
}












