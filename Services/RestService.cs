using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using MAUI_Blazor_Demo.Data;
using MAUI_Blazor_Demo.Models;

namespace MAUI_Blazor_Demo.Services;
internal class RestService
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;

    public List<Bookings> bookingItems { get; private set; }

    public RestService()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
    public async Task<List<Bookings>> getBookingDetails()
    {
        List<Bookings> Items = new List<Bookings>();

        Uri uri = new Uri(string.Format("https://localhost:44302/api/Bookings/getBookingDetails", string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<List<Bookings>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return Items;
    }

    public async Task<List<WeatherForecast>> getWhetherDetails()
    {
        List<WeatherForecast> Items = new List<WeatherForecast>();

        Uri uri = new Uri(string.Format("https://localhost:44302/WeatherForecast", string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<List<WeatherForecast>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return Items;
    }
}

