﻿using eMovies.Data.Cart;
using eMovies.Data.ViewModels;
using eMovies.Services.MoviesServices;
using Microsoft.AspNetCore.Mvc;

namespace eMovies.Controllers;

public class OrdersController : Controller
{
    private readonly IMoviesService _moviesService;
    private readonly ShoppingCart _shoppingCart;

    public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart)
    {
        _moviesService = moviesService;
        _shoppingCart = shoppingCart;
    }

    public IActionResult ShoppingCart()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var response = new ShoppingCartVM()
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };

        return View(response);
    }

    public async Task<IActionResult> AddItemToShoppingCart(int id)
    {
        var item = await _moviesService.GetByIdAsync(id);

        if (item != null)
        {
            _shoppingCart.AddItemToCart(item);
        }

        return RedirectToAction(nameof(ShoppingCart));
    }

    public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
    {
        var item = await _moviesService.GetByIdAsync(id);

        if (item != null)
        {
            _shoppingCart.RemoveItemFromCart(item);
        }

        return RedirectToAction(nameof(ShoppingCart));
    }
}
