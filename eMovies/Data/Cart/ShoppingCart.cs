using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Data.Cart;

public class ShoppingCart
{
    private AppDbContext _context { get; set; }

    public string ShoppingCartId { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public ShoppingCart(AppDbContext context)
    {
        _context = context;
    }

    public async void AddItemToCart(Movie movie)
    {
        var shoppingCartItem =  await _context.ShoppingCartItems
            .FirstOrDefaultAsync(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Movie = movie,
                Amount = 1
            };

            await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }

        await _context.SaveChangesAsync();
    }

    public async void RemoveItemFromCart(Movie movie)
    {
        var shoppingCartItem = await _context.ShoppingCartItems
            .FirstOrDefaultAsync(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1) shoppingCartItem.Amount--;
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<ShoppingCartItem>> GetShoppingCartItems()
    {
        return ShoppingCartItems ??= await _context.ShoppingCartItems
            .Where(s => s.ShoppingCartId == ShoppingCartId)
            .Include(s => s.Movie)
            .ToListAsync();
    }

    public async Task<double> GetShoppingCartTotal()
    {
        return await _context.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)
            .Select(s => s.Movie.Price * s.Amount).SumAsync();
    }
}
