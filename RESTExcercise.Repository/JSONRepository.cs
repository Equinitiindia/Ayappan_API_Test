using Newtonsoft.Json;
using RESTExcercise.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTExcercise.Repository
{
    public class JSONRepository : IAccount
    {
        readonly string filepath;
        public JSONRepository()
        {
            filepath = @"D:\Ayyappan Interview\RESTSampleProject\RESTExcercise.Repository\sample-data.json";
        }
        public void Add(Transaction transaction)
        {
            var lstTransation = JsonConvert.DeserializeObject<List<Transaction>>(ReadJSONFile());
            lstTransation.Add(transaction);
            var convertedJson = JsonConvert.SerializeObject(lstTransation, Formatting.Indented);
            File.WriteAllText(filepath, convertedJson);
        }

        public void Delete(string transactionGUID)
        {
            var lstTransation = JsonConvert.DeserializeObject<List<Transaction>>(ReadJSONFile());
            lstTransation.RemoveAll(transaction => transaction.TransGUID.Equals(transactionGUID, StringComparison.OrdinalIgnoreCase));
            var convertedJson = JsonConvert.SerializeObject(lstTransation, Formatting.Indented);
            File.WriteAllText(filepath, convertedJson);
        }

        public IEnumerable<Transaction> Get()
        {
            var lstTransation = JsonConvert.DeserializeObject<List<Transaction>>(ReadJSONFile());
            return lstTransation;
        }

        public Transaction Get(string transactionGUID)
        {
            var lstTransation = JsonConvert.DeserializeObject<List<Transaction>>(ReadJSONFile());
            var transaction = lstTransation.Where(item => item.TransGUID.Equals(transactionGUID, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            return transaction;
        }

        public Transaction Update(Transaction transaction)
        {
            var lstTransation = JsonConvert.DeserializeObject<List<Transaction>>(ReadJSONFile());
            var tranItem = lstTransation.Where(item => item.TransGUID.Equals(transaction.TransGUID, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (null != tranItem)
            {
                tranItem = transaction;
                return tranItem;
            }
            else
                return null;
        }
        private string ReadJSONFile()
        {
            string txtTransaction = System.IO.File.ReadAllText(filepath);
            return txtTransaction;
        }
    }
}
