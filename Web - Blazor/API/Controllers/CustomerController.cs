using BusinessLogic.Services;
using Dapper;
using DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICustomerService _customerService;
        private readonly DemoDBContext _demoDBContext;
        public CustomerController(ICustomerService customerService, DemoDBContext demoDBContext, IConfiguration configuration)
        {
            this._customerService = customerService;
            this._demoDBContext = demoDBContext;
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("getCustomers")]
        public async Task<IActionResult> getCustomers(int skip = 0, int take = 3)
        {
            var data = await _customerService.getCustomers(skip, take);
            return Ok(data);
        }
        [HttpPost]
        [Route("CreateCustomer")]
        public void CreateCustomer(Customer customer)
        {
            using (IDbConnection dbConnection = new SqlConnection(_configuration["ConnectionStrings:DBConnection"]))
            {
                string insert = @"INSERT INTO Customer (CompanyName,ContactName,Address,City,Region,PostalCode,Country,Phone) VALUES(@CompanyName,@ContactName,@Address,@City,@Region,@PostalCode,@Country,@Phone)";
                dbConnection.Open();
                dbConnection.Execute(insert, customer);
            }
        }
        
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public void DeleteCustomer(int id)
        {
            using (IDbConnection dbconnection = new SqlConnection(_configuration["ConnectionStrings:DBConnection"]))
            {
                string delete = @"DELETE FROM Customer WHERE Id=@id";
                dbconnection.Open();
                dbconnection.Execute(delete,new { Id = id});
            }
        }
        [HttpGet]
        [Route("EditCustomer/{id}")]
        public Customer EditCustomer(string id)
        {
            using (IDbConnection dbconnection = new SqlConnection(_configuration["ConnectionStrings:DBConnection"]))
            {
                string edit = @"SELECT * FROM Customer WHERE Id=@Id";
                dbconnection.Open();
               return dbconnection.Query<Customer>(edit, new { Id = id }).FirstOrDefault();
            }
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public void UpdateCustomer(Customer customer)
        {
           using(IDbConnection dbConnection = new SqlConnection(_configuration["ConnectionStrings:DBConnection"]))
            {
                string update = @"UPDATE Customer SET CompanyName=@CompanyName, ContactName=@ContactName, Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,Phone=@Phone WHERE Id=@Id";
                dbConnection.Open();
                dbConnection.Query(update,customer);
            }
        }
    }
}
