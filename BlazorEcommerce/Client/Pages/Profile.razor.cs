using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    [Authorize]
    public partial class Profile
    {
        [Inject]
        public IAuthService AuthService { get; set; }

        UserChangePassword request = new UserChangePassword();
        string message = string.Empty;

        private async Task ChangePassword()
        {
            var result = await AuthService.ChangePassword(request);
            message = result.Message;
        }
    }
}
