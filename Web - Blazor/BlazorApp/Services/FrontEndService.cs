using DataModels.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using BusinessLogic.Services;

namespace BlazorApp.Services
{
    public class FrontEndService : IFrontEndService
    {
        private readonly HttpClient _httpClient;
        public FrontEndService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<CustomerResults> getCustomers(int skip, int take)
        {
            return await _httpClient.GetFromJsonAsync<CustomerResults>($"api/Customer/getCustomers?Skip={skip}&Take={take}");
        }
        public void InsertCustomer(Customer customer)
        {
            var insertCustomer = new Customer
            {
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone
            };
            _httpClient.PostAsJsonAsync("http://localhost:5218/api/Customer/CreateCustomer", insertCustomer);
        }

        public void DeleteCustomer(int id)
        {
           
            _httpClient.DeleteAsync("http://localhost:5218/api/Customer/DeleteCustomer/" +id);
        }
        public async Task<Customer>EditCustomer(string id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>("http://localhost:5218/api/Customer/EditCustomer/" + id);
        }

        public void UpdateCustomer(Customer customer)

        {
            _httpClient.PutAsJsonAsync("http://localhost:5218/api/Customer/UpdateCustomer", customer);
        }
    }
}
