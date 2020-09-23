using API.DataAccess.Interfaces;
using API.Domain;
using API.Domain.Entities;
using Infrastructure.Common.Constants;
using Infrastructure.Utils.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IHttpClientCustom _httpClientCustom;
        private readonly AppSettings _appSettings;

        public EmployeeRepository(IHttpClientCustom httpClientCustom, IOptions<AppSettings> appSettings)
        {
            _httpClientCustom = httpClientCustom;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var uri = new Uri(_appSettings.Masglobaltestapi + Constants.GetAllEmployees);
            return await _httpClientCustom.GetAsync<IEnumerable<Employee>>(uri);
        }
    }
}
