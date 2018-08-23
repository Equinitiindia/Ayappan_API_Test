using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTExcercise.Contracts
{
    public enum TransactionType
    {
        Debit,
        Credit
    }
    public class Transaction
    {
        public string TransGUID;
        public int ApplicationID;
        public TransactionType Type;
        public string Summary;
        public double Amount;
        public DateTime PostingDate;
        public bool IsCleared;
        public DateTime ClearedDate;
    }
}
