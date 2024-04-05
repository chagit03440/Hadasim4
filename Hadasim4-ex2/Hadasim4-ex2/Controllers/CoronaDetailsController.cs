using Hadasim4_ex2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Hadasim4_ex2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaDetailsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CoronaDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllCoronaDetails")]

        public Response GetAllCoronaDetails()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("userConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllCoronaDetails(connection);
            return response;
        }

        [HttpGet]
        [Route("GetCoronaDetailsById/{id}")]

        public Response GetCoronaDetailsById(string id)
        {
            Response response = new Response();
            DAL dal = new DAL();
            bool flag = dal.IsValidID(id);
            if (!flag)
            {
                response.StatusCode = 100;
                response.StatusMessage = "No valid id";
                response.corona = null;
            }
            else
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("userConnection").ToString());
                response = dal.GetCoronaDetailsById(connection, id);

            }
            return response;
        }

        [HttpPost]
        [Route("AddCoronaDetails")]

        public Response AddCoronaDetails(CoronaDetails cd)
        {
            Response response = new Response();
            DAL dal = new DAL();
            var validationErrors = dal.ValidCoronaDetails(cd);
            if (validationErrors.Count == 0)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("userConnection").ToString());
                response = dal.AddCoronaDetails(connection, cd);

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = string.Join(", ", validationErrors);
                response.corona = null;
            }
            return response;

        }

    }
}
