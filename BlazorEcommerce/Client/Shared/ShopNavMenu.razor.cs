using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ShopNavMenu
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetCategories();
        }

        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}
