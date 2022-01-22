using BusinessLogic.Services;
using DataModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IFrontEndService 
    {
        Task<CustomerResults> getCustomers(int skip, int take);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int id);
        Task<Customer> EditCustomer(string id);
        void UpdateCustomer(Customer customer);

    }

}
