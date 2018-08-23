using RESTExcercise.Contracts;
using RESTExcercise.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTExcecise.Business
{
    public class AccountManager : IAccount
    {
        private IAccount accountRepository;
        public AccountManager()
        {
            accountRepository = new JSONRepository();
        }
        public AccountManager(IAccount accountrepository)
        {
            accountRepository = accountrepository;
        }
        public void Add(Transaction transaction)
        {
            accountRepository.Add(transaction);
        }

        public void Delete(string transactionGUID)
        {
            accountRepository.Delete(transactionGUID);
        }

        public IEnumerable<Transaction> Get()
        {
            var result = accountRepository.Get();
            return result;
        }

        public Transaction Get(string transactionGUID)
        {
            return accountRepository.Get(transactionGUID); 
        }

        public Transaction Update(Transaction transaction)
        {
            return accountRepository.Update(transaction);
        }
    }
}
