﻿using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class Cart
    {
        [Inject]
        public ICartService CartService { get; set; }
        [Inject]
        public IOrderService OrderService { get; set; }

        List<CartProductResponse> cartProducts = new List<CartProductResponse>();
        string message = "Loading cart...";
        bool orderPlaced = false;

        protected override async Task OnInitializedAsync()
        {
            orderPlaced = false;
            await LoadCart();
        }

        private async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            await CartService.RemoveProductFromCart(productId, productTypeId);
            await LoadCart();
        }
        private async Task LoadCart()
        {
            await CartService.GetCartItemsCount();
            cartProducts = await CartService.GetCartProducts();
            if (!cartProducts.Any())
                message = "Your cart is empty.";
        }

        private async Task UpdateQuantity(ChangeEventArgs e, CartProductResponse product)
        {
            product.Quantity = int.Parse(e.Value.ToString());
            if (product.Quantity < 1)
                product.Quantity = 1;
            await CartService.UpdateQuantity(product);
        }

        private async Task PlaceOrder()
        {
            await OrderService.PlaceOrder();
            await CartService.GetCartItemsCount();
            orderPlaced = true;
        }
    }
}
