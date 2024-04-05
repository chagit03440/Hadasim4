using Hadasim4_ex2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewCoronaManagment.Models;

namespace Hadasim4_ex2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        string BaseUrl = "http://localhost:57205";
        public async Task<IActionResult> IndexAsync()
        {
            DataTable dt = new DataTable();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{BaseUrl}/api/CoronaDetails/GetAllCoronaDetails");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var coronaDetails = System.Text.Json.JsonSerializer.Deserialize<Response>(responseContent, options);
                    return View(coronaDetails);
                }
            }
            return View();
        }
        public async Task<IActionResult> ViewAllCoronaDetails()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{BaseUrl}/api/CoronaDetails/GetAllCoronaDetails");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var coronaDetails = System.Text.Json.JsonSerializer.Deserialize<Response>(responseContent, options);
                    return View(coronaDetails);
                }
            }

            return View();
        }

        public async Task<IActionResult> ViewAllEmployees()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{BaseUrl}/api/Employee/GetAllEmployees");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var employeeName = System.Text.Json.JsonSerializer.Deserialize<Response>(responseContent, options);
                    return View(employeeName);
                }
            }
            return View();
        }
        public async Task<IActionResult> ViewNotVaccinated()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{BaseUrl}/api/Employee/GetNotVaccinated");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var employeeName = System.Text.Json.JsonSerializer.Deserialize<Response>(responseContent, options);
                    return View(employeeName);
                }
            }
            return View();
        }
        public async Task<IActionResult> ViewSicksForLastMonth()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{BaseUrl}/api/Employee/GetCoronaSummery");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var coronaSummary = System.Text.Json.JsonSerializer.Deserialize<Response>(responseContent, options);
                    return View(coronaSummary);
                }
            }
            return View();
        }
      
    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
