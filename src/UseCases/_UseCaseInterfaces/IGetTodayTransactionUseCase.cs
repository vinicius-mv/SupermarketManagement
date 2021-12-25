using CoreBusiness;

namespace UseCases
{
    public interface IGetTransactionsByDateUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime date);
    }
}