using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class ProductDetails
    {
        [Inject]
        public ICartService CartService { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        private Product? product = null;
        private string message;
        private int currentTypeId = 1;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            message = "Loading roduct...";
            var result = await ProductService.GetProduct(Id);
            if (!result.Success)
                message = result.Message;
            else
            {
                product = result.Data;
                if (product.Variants.Any())
                    currentTypeId = product.Variants[0].ProductTypeId;
            }
        }

        private ProductVariant GetSelectedVariant()
        {
            var variant = product.Variants.FirstOrDefault(v => v.ProductTypeId == currentTypeId);
            return variant;
        }

        private async Task AddToCart()
        {
            var productVariant = GetSelectedVariant();
            var cartItem = new CartItem
            {
                ProductId = productVariant.ProductId,
                ProductTypeId = productVariant.ProductTypeId
            };
            await CartService.AddToCart(cartItem);
        }
    }
}
