using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext _db;

        public TransactionRepository(MarketContext db)
        {
            _db = db;
        }

        public IEnumerable<Transaction> Get()
        {
            return _db.Transactions.ToList();
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime refDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _db.Transactions.Where(x => x.TimeStamp.Date == refDate.Date);
            }
            else
            {
                string cashierNameLower = cashierName.ToLower();
                return _db.Transactions.Where(x => x.CashierName.ToLower() == cashierNameLower
                    && x.TimeStamp.Date == refDate.Date);
            }
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            };
            _db.Transactions.Add(transaction);
            _db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _db.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date
                    && x.TimeStamp.Date <= endDate.Date);
            }
            else
            {
                string cashierNameLower = cashierName.ToLower();
                return _db.Transactions.Where(x => cashierName == x.CashierName.ToLower()
                    && x.TimeStamp.Date >= startDate.Date
                    && x.TimeStamp.Date <= endDate.Date);
            }
        }
    }
}
