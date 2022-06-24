using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace BlazorEcommerce.Client.Shared
{
    public partial class AdminMenu
    {
        [Inject]
        public AuthenticationStateProvider AuthStateProvider { get; set; }

        bool authorized = false;

        protected override async Task OnInitializedAsync()
        {
            string role = (await AuthStateProvider.GetAuthenticationStateAsync())
                .User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if(role.Contains("Admin"))
                authorized = true;
        }
    }
}
