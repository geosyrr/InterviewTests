using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface ICustomerService
    {
        Task<CustomerResults> getCustomers(int skip, int take);
    }
}
