using CoreBusiness;

namespace UseCases
{
    public interface IViewCategoriesUseCases
    {
        IEnumerable<Category> Execute();
    }
}