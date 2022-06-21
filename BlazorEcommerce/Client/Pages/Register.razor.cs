using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class Register
    {
        [Inject]
        public IAuthService AuthService { get; set; }

        UserRegister user = new UserRegister();

        string message = string.Empty;
        string messageCssClass = string.Empty;

        async Task HandleRegistration()
        {
            var result = await AuthService.Register(user);
            message = result.Message;
            if(result.Success)
                messageCssClass = "text-success";
            else
                messageCssClass = "text-danger";
        }
    }
}
