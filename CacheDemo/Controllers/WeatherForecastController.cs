using DataAccessLibrary;
using Microsoft.AspNetCore.Mvc;

namespace CacheDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SampleDataAccess _dataAccess;

        public WeatherForecastController(SampleDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet("GetEmployees")]
        public List<EmloyeeModel> Get()
        {
            return _dataAccess.GetEmloyees();
        }

        [HttpGet("GetEmployeesAsync")]
        public async Task<List<EmloyeeModel>> GetAsync()
        {
            return await _dataAccess.GetEmloyeesAsync();
        }

        [HttpGet("GetEmployeesCache")]
        public async Task<List<EmloyeeModel>> GetCacheAsync()
        {
            return await _dataAccess.GetEmloyeesCacheAsync();
        }
    }
}