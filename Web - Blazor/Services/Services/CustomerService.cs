using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DemoDBContext _demoDBContext;

        public CustomerService(DemoDBContext demoDBContext)
        {
            this._demoDBContext = demoDBContext;
        }

        public async Task<CustomerResults> getCustomers(int skip = 0 , int take = 3 )
        {
            CustomerResults result = new CustomerResults()
            {
                Results = _demoDBContext.Customers.Skip(skip).Take(take).ToList(),
                Count = await _demoDBContext.Customers.CountAsync()
            };
            return  result;
        }
    }
}
