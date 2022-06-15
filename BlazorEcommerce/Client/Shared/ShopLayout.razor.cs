using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ShopLayout : ComponentBase
    {
        [Parameter]
        public RenderFragment? Body { get; set; }
    }
}
