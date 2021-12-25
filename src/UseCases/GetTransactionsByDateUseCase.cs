using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetTransactionsByDateUseCase : IGetTransactionsByDateUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionsByDateUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName, DateTime date)
        {
            return _transactionRepository.GetByDay(cashierName, date);
        }
    }
}
