using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTExcercise.Contracts
{
    public interface IAccount
    {
        void Add(Transaction transaction);
        Transaction Get(string transactionGUID);
        IEnumerable<Transaction> Get();
        Transaction Update(Transaction transaction);
        void Delete(string transactionGUID);
    }
}
