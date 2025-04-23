using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CtrlLights.Data.Models;
using CtrlLights.Data.Api_Service;

namespace CtrlLights.Data.Api_Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://ctrlightsapi.onrender.com/api/ctrlights/")
            };
        }

        public async Task<List<TrafficLights>> GetTrafficLightsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("getTrafficLights");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse<List<TrafficLights>>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.TrafficLightsList ?? new List<TrafficLights>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetTrafficLightsAsync: {ex.Message}");
            }
        }

        public async Task<List<AirQuality>> GetAirQualityAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("getAirQualities");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse<List<AirQuality>>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.AirQualityList ?? new List<AirQuality>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetAirQualityAsync: {ex.Message}");
            }
        }

        public async Task<List<AdminUsers>> GetAdminProfilesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("getAdminsProfiles");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse<List<AdminUsers>>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.AdminUsersList ?? new List<AdminUsers>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetAdminProfilesAsync: {ex.Message}");
            }
        }

        public async Task<List<EspDevice>> GetEspDevicesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("getEspDevices");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse<List<EspDevice>>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.EspDevicesList ?? new List<EspDevice>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetEspDevicesAsync: {ex.Message}");
            }
        }

        public async Task<bool> VerifyLoginAsync(string key)
        {
            try
            {
                var response = await _httpClient.GetAsync($"getLoginVerification/{key}");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse<bool>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.Check ?? false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in VerifyLoginAsync: {ex.Message}");
            }
        }

        public async Task<AdminUsers> GetUserByUsernameAsync(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync($"getByUserName/{username}");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse<AdminUsers>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.User;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetUserByUsernameAsync: {ex.Message}");
            }
        }




    }
}

