namespace UseCases
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int productId, string productName, int qtyToSell);
    }
}