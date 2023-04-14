using eMovies.Models;

namespace eMovies.Services.OrdersService;

public interface IOrdersService
{
    Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
    Task<List<Order>> GetOrdersByUserIdAsync(string userId, string userRole);
}
