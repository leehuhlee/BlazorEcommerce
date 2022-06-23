using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class OrderDetails
    {
        [Parameter]
        public int OrderId { get; set; }

        [Inject]
        public IOrderService OrderService { get; set; }

        OrderDetailsResponse order = null;

        protected override async Task OnInitializedAsync() 
            => order = await OrderService.GetOrderDetails(OrderId);
    }
}
