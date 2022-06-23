using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class Orders
    {
        [Inject]
        public IOrderService OrderService { get; set; }

        List<OrderOverviewResponse> orders = null;

        protected override async Task OnInitializedAsync()
            => orders = await OrderService.GetOrders();
    }
}
