using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Shared
{
    public partial class CartCounter : IDisposable
    {
        [Inject]
        ICartService CartService { get; set; }
        
        [Inject]
        ISyncLocalStorageService LocalStorage { get; set; }

        private int GetCartItemCount()
        {
            var cart = LocalStorage.GetItem<List<CartItem>>("cart");
            return cart != null ? cart.Count : 0;
        }

        protected override void OnInitialized()
        {
            CartService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CartService.OnChange -= StateHasChanged;
        }
    }
}
