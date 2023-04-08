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

    public static ShoppingCart GetShoppingCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;

        var context = services.GetService<AppDbContext>();
        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        session.SetString("CartId", cartId);

        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }

    public void AddItemToCart(Movie movie)
    {
        var shoppingCartItem =  _context.ShoppingCartItems
            .FirstOrDefault(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Movie = movie,
                Amount = 1
            };

            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }

        _context.SaveChanges();
    }

    public void RemoveItemFromCart(Movie movie)
    {
        var shoppingCartItem = _context.ShoppingCartItems
            .FirstOrDefault(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1) shoppingCartItem.Amount--;
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }

        _context.SaveChanges();
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ??= _context.ShoppingCartItems
            .Where(s => s.ShoppingCartId == ShoppingCartId)
            .Include(s => s.Movie)
            .ToList();
    }

    public double GetShoppingCartTotal()
    {
        return _context.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)
            .Select(s => s.Movie.Price * s.Amount).Sum();
    }

    public async Task ClearShoppingCartAsync()
    {
        var items = await _context.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)
            .ToListAsync();

        _context.ShoppingCartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
    }
}
