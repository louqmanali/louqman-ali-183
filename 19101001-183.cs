var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    // Additional properties related to the order can be added as needed

    // Example constructor for creating an order
    public Order(int orderId, string customerName, DateTime orderDate, decimal totalAmount)
    {
        OrderId = orderId;
        CustomerName = customerName;
        OrderDate = orderDate;
        TotalAmount = totalAmount;
    }
}
using System;
using System.Collections.Generic;

public class Order
{
    public int UserId { get; set; }
    public decimal Amount { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Sample orders for demonstration
        List<Order> orders = new List<Order>
        {
            new Order { UserId = 1, Amount = 300 },
            new Order { UserId = 2, Amount = 800 },
            new Order { UserId = 3, Amount = 1200 },
            new Order { UserId = 4, Amount = 2000 }
        };

        // Lists to store user IDs based on amount criteria
        List<int> userIdsLessThan500 = new List<int>();
        List<int> userIdsGreaterThan1500 = new List<int>();

        // Populate lists based on amount criteria
        foreach (var order in orders)
        {
            if (order.Amount < 500)
            {
                userIdsLessThan500.Add(order.UserId);
            }
            else if (order.Amount > 1500)
            {
                userIdsGreaterThan1500.Add(order.UserId);
            }
        }

        // Display the results
        Console.WriteLine("User IDs with amount less than 500:");
        foreach (var userId in userIdsLessThan500)
        {
            Console.WriteLine(userId);
        }

        Console.WriteLine("\nUser IDs with amount greater than 1500:");
        foreach (var userId in userIdsGreaterThan1500)
        {
            Console.WriteLine(userId);
        }
    }
}
