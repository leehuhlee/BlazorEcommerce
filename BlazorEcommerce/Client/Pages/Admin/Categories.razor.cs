using Microsoft.AspNetCore.Authorization;

namespace BlazorEcommerce.Client.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public partial class Categories
    {

    }
}
