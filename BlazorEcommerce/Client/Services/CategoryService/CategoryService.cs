namespace BlazorEcommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Category> AdminCategories { get; set; } = new List<Category>();

        public event Action OnChange;

        public async Task AddCategory(Category category)
        {
            var response = await _http.PostAsJsonAsync("api/category/admin", category);
        }

        public Category CreateNewCategory()
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task GetAdminCategories()
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category/admin");
            if (response != null && response.Data != null)
                Categories = response.Data;
        }

        public async Task GetCategories()
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            if(response != null && response.Data != null)
                Categories = response.Data;
        }

        public Task UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
