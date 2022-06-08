using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {
        [Inject]
        public HttpClient Http { get; set; }

        private static List<Product> Products = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetFromJsonAsync<List<Product>>("api/product");
            if (result != null)
                Products = result;
        }
    }
}
