using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IRecordTransactionUseCase _recordTransactionUseCase;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase recordTransactionUseCase)
        {
            _productRepository = productRepository;
            _recordTransactionUseCase = recordTransactionUseCase;
        }

        public void Execute(string cashierName, int productId, string productName, int qtyToSell)
        {
            var product = _productRepository.GetProductById(productId);

            if (product == null)
                return;

            if (product.Quantity < qtyToSell)
                return;

            product.Quantity -= qtyToSell;
            _productRepository.UpdateProduct(product);
            _recordTransactionUseCase.Execute(cashierName, productId, productName, qtyToSell);
        }
    }
}
