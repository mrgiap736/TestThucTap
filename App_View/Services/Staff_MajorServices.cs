using App_Data.Data;
using App_Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App_View.Services
{
    public class Staff_MajorServices
    {
        HttpClient _client;

        public Staff_MajorServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Staff_MajorFacility>> GetAllStaffMajor(Guid idstaff)
        {
            string requestUrl = $"https://localhost:7169/api/Staff_Major/get-all-staffmajor?idstaff={idstaff}";

            var response = await _client.GetStringAsync(requestUrl);

            return JsonConvert.DeserializeObject<List<Staff_MajorFacility>>(response);
        }

        public async Task<List<Facility>> GetAllFacilities()
        {
            string requestUrl = $"https://localhost:7169/api/Staff_Major/get-all-facility";

            var response = await _client.GetStringAsync(requestUrl);

            return JsonConvert.DeserializeObject<List<Facility>>(response);
        }

    }
}
