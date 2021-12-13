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

        public void AddCategory(Category category)
        {
            if (_categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
                return;

            int maxId = 0;
            if (_categories?.Count > 0)
                maxId = _categories.Max(x => x.CategoryId);

            category.CategoryId = maxId + 1;

            _categories.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryToRemove = GetCategoryById(categoryId);
            if (categoryToRemove != null)
                _categories.Remove(categoryToRemove);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }
    }
}