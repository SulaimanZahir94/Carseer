namespace Carseer.Services
{
    public class VehicleService
    {
        private readonly HttpClient _httpClient;

        public VehicleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Make>> GetAllMakes()
        {
            var response = await _httpClient.GetAsync("https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<ApiResponse<Make>>();
                return data.Results;
            }
            return new List<Make>();
        }

        public async Task<List<VehicleType>> GetVehicleTypesForMake(int makeId)
        {
            var response = await _httpClient.GetAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{makeId}?format=json");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<ApiResponse<VehicleType>>();
                return data.Results;
            }
            return new List<VehicleType>();
        }

        public async Task<List<Model>> GetModelsForMakeAndYear(int makeId, int year, string vehicleType)
        {
            var response = await _httpClient.GetAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<ApiResponse<Model>>();
                return data.Results.Where(m => m.VehicleType == vehicleType).ToList();
            }
            return new List<Model>();
        }
    }

    public class ApiResponse<T>
    {
        public List<T> Results { get; set; }
    }

    public class Make 
    { 
        public int Make_ID { get; set; } 
        public string Make_Name { get; set; } 
    }
    public class VehicleType 
    { 
        public string VehicleTypeName { get; set; } 
    }
    public class Model 
    { 
        public string Model_Name { get; set; } 
        public string VehicleType { get; set; } 
    }


}
