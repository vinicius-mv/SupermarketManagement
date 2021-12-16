using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _productRespository;

        public DeleteProductUseCase(IProductRepository productRespository)
        {
            _productRespository = productRespository;
        }

        public void Execute(int productId)
        {
            _productRespository.DeleteProduct(productId);
        }
    }
}
