using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class OrderSucess
    {
        [Inject]
        public ICartService CartService { get; set; }

        protected override async Task OnInitializedAsync()
            => await CartService.GetCartItemsCount();
    }
}
