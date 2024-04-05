using Hadasim4_ex2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hadasim4_ex2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/employees
        [HttpGet]
        [Route("GetAllEmployees")]
        
        public Response GetAllEmployees()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("userConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllEmployees(connection);
            return response;
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]

        public Response GetEmployeeById(string id)
        {
            Response response = new Response();
            DAL dal = new DAL();
            bool flag = dal.IsValidID(id);
            if (!flag)
            {
                response.StatusCode = 100;
                response.StatusMessage = "No valid id";
                response.Employee = null;
            }
            else
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("userConnection").ToString());
                response = dal.GetEmployeeById(connection, id);

            }
            return response;
        }

        [HttpPost]
        [Route("AddEmployee")]
        
        public Response AddEmployee(Employee employee)
        {
            Response response = new Response();
            DAL dal = new DAL();
            var validationErrors = dal.ValidEmployee(employee);
            if (validationErrors.Count ==0)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("userConnection").ToString());
                response = dal.AddEmployee(connection, employee);

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = string.Join(", ", validationErrors);
                response.Employee = null;
            }
            return response;

        }

        [HttpGet]
        [Route("GetCoronaSummery")]

        public Response GetCoronaSummery()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("userConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetCoronaDataForLastMonth(connection);
            return response;
        }

        [HttpGet]
        [Route("GetNotVaccinated")]

        public Response GetNotVaccinated()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("userConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetNotVaccinated(connection);
            return response;
        }

    }
}
