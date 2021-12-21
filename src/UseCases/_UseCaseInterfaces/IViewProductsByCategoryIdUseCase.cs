using CoreBusiness;

namespace UseCases
{
    public interface IViewProductsByCategoryIdUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}