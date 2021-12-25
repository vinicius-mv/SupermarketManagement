using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public TransactionInMemoryRepository()
        {
        }

        public IEnumerable<Transaction> Get()
        {
            return _transactions;
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            return _transactions.Where(x => x.TimeStamp.Date == date.Date && x.CashierName == cashierName);
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            int lastTransactionId = 0;
            if (_transactions?.Count > 0)
                lastTransactionId = _transactions.Max(x => x.ProductId);

            _transactions!.Add(new Transaction
            {
                TransactionId = lastTransactionId + 1,
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            });
        }
    }
}
