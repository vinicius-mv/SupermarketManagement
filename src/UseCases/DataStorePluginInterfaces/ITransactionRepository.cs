using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get();
        IEnumerable<Transaction> GetByDay(string cashierName, DateTime date);
        void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty);
    }
}
