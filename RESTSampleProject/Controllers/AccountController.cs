using RESTExcecise.Business;
using RESTExcercise.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RESTSampleProject.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAccount accountBusinessManager;
        public AccountController(IAccount accountBusinessManager)
        {
            this.accountBusinessManager = accountBusinessManager;
        }
        public AccountController()
        {
            this.accountBusinessManager = new AccountManager();
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return accountBusinessManager.Get();
        }

        [HttpGet]
        [Route("{tranGUID}")]
        [ResponseType(typeof(Transaction))]
        public Transaction GetTransaction([FromUri] string tranGUID)
        {
            return accountBusinessManager.Get(tranGUID);
        }

        [Route("")]
        [HttpPost]
        public void create(Transaction transaction)
        {
            accountBusinessManager.Add(transaction);
        }
        [Route("")]
        [HttpPut]
        public void update(Transaction transaction)
        {
            accountBusinessManager.Update(transaction);
        }

        [Route("{tranGUID}")]
        [HttpDelete]
        public void Delete([FromUri] string tranGUID)
        {
            accountBusinessManager.Delete(tranGUID);
        }

    }
}
