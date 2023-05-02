using MAUI_Blazor_Demo.Models;
using MAUI_Blazor_Demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Blazor_Demo.Data
{
    internal class BookingService
    {
        RestService service = new RestService();
        public async Task<List<Bookings>> GetBookingDetailsAsyncFromAPI()
        {
            return await service.getBookingDetails();
        }

        public async Task<List<WeatherForecast>> GetWhetherDetailsAsyncFromAPI()
        {
            return await service.getWhetherDetails();
        }
    }
}
