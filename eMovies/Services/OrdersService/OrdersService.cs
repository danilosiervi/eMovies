﻿using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services.OrdersService;

public class OrdersService : IOrdersService
{
    private readonly AppDbContext _context;

    public OrdersService(AppDbContext context)
    {
        _context = context;
    }

    public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail)
    {
        var order = new Order()
        {
            UserId = userId,
            Email = userEmail
        };

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        foreach (var item in items)
        {
            var orderItem = new OrderItem()
            {
                Amount = item.Amount,
                MovieId = item.Movie.Id,
                OrderId = order.Id,
                Price = item.Movie.Price
            };

            await _context.OrderItems.AddAsync(orderItem);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetOrdersByUserIdAsync(string userId, string userRole)
    {
        var orders =  await _context.Orders
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Movie)
            .Include(o => o.User)
            .ToListAsync();

        if (userRole != "Admin")
        {
            orders = orders.Where(o => o.UserId == userId).ToList();
        }

        return orders;
    }
}
