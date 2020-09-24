using EmployeeApp.Models;
using Infrastructure.Common.Constants;
using Infrastructure.Utils.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientCustom _httpClientCustom;
        private readonly AppSettings _appSettings;

        public HomeController(IHttpClientCustom httpClientCustom, IOptions<AppSettings> appSettings)
        {
            _httpClientCustom = httpClientCustom;
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(int? id)
        {
            var url = _appSettings.EmployeeApi + Constants.GetUriEmployeeApi;
            var param = new Dictionary<string, string>() { { "id", id.HasValue ? id.Value.ToString() : string.Empty } };

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            var employeeList = await _httpClientCustom.GetAsync<IEnumerable<Employee>>(newUrl);
            return View(employeeList);
        }
    }
}
