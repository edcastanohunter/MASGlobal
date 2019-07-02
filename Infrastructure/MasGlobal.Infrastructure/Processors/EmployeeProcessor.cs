using MasGlobal.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasGlobal.Infrastructure.Processors
{
    public static class EmployeeProcessor
    {
        public static async Task<List<ApiEmployeeModel>> LoadEmployees()
        {
            string url = "http://masglobaltestapi.azurewebsites.net/api/Employees";
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        List<ApiEmployeeModel> employess = await response.Content.ReadAsAsync<List<ApiEmployeeModel>>();
                        return employess;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error when connecting, get:  " + ex.Message);
            }
        }
    }
}
