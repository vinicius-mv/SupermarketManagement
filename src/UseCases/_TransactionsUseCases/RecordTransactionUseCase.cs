using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;

        public RecordTransactionUseCase(ITransactionRepository transactionRepository, IGetProductByIdUseCase getProductByIdUseCase)
        {
            _transactionRepository = transactionRepository;
            _getProductByIdUseCase = getProductByIdUseCase;
        }

        public void Execute(string cashierName, int productId, string productName, int soldQty)
        {
            var product = _getProductByIdUseCase.Execute(productId);
            int beforeQty = product.Quantity!.Value + soldQty;
            _transactionRepository.Save(cashierName, productId, productName, product.Price!.Value, beforeQty, soldQty);
        }
    }
}
