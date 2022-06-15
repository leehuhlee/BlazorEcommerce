using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList : IDisposable
    {
        [Inject]
        public IProductService ProductService { get; set; }

        protected override void OnInitialized()
        {
            ProductService.ProductsChanged += StateHasChanged;
        }

        public void Dispose()
        {
            ProductService.ProductsChanged -= StateHasChanged;
        }

        private string GetPriceText(Product product) 
        {
            var variants = product.Variants;
            if (!variants.Any())
                return string.Empty;
            else if (variants.Count == 1)
                return $"${variants[0].Price}";
            decimal minPrice = variants.Min(v => v.Price);
            return $"Starting at ${minPrice}";
        }
    }
}
