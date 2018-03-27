using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceNew.Models;
using SalesForceNew.Class;

namespace SalesForceNew.Controllers
{
    public class ExpensesController : ApiController
    {
        public IEnumerable<ExpensesDetails_Result> Get()
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.ExpensesDetails().ToList();
            }
        }


        public IEnumerable<UsersExpensesDetails_Result> Get(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.UsersExpensesDetails(Id).ToList();
            }
        }

        public void Post([FromBody] InsertExpenses addexpense)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.AddExpense(addexpense.UserId, addexpense.Date, addexpense.Description, addexpense.Amount);
                entities.SaveChanges();
            }
        }

        public void Put([FromBody] string status, int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.UpdateExpenses(Id, status);
                entities.SaveChanges();
            }
        }
    }
}
