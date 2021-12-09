using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryInMemoryRepository()
        {
            // Add some default Categories
            _categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage desc" },
                new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery desc" },
                new Category { CategoryId = 3, Name = "Meat", Description = "Meat desc" },
            };
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }
    }
}