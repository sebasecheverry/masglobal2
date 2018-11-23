using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public partial class apiHelper
    {
        public async Task<List<EmployeeEntity>> GetEmployees()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Employees"));
            return await GetAsync<List<EmployeeEntity>>(requestUrl);
        }

        public async Task<EmployeeEntity> GetEmployee(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Employees/" + id));
            return await GetAsync<EmployeeEntity>(requestUrl);
        }
    }
}
