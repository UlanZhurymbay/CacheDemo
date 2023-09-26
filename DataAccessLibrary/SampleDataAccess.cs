using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SampleDataAccess
    {
        private readonly IMemoryCache _memoryCache;
        public SampleDataAccess(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<EmloyeeModel> GetEmloyees()
        {
            var list = new List<EmloyeeModel>()
            {
                new("Tim", "Corey"),
                new("Sue", "Storm"),
                new("Jane", "Jones")
            };

            Thread.Sleep(3000);

            return list;
        }

        public async Task<List<EmloyeeModel>> GetEmloyeesDBAsync()
        {
            var list = new List<EmloyeeModel>()
            {
                new("Tim", "Corey"),
                new("Sue", "Storm"),
                new("Jane", "Jones")
            };

            await Task.Delay(3000);

            return list;
        }

        public async Task<List<EmloyeeModel>> GetEmloyeesCacheAsync()
        {
            List<EmloyeeModel> list;

            list = _memoryCache.Get<List<EmloyeeModel>>("employees");

            if (list is null)
            {
                list = await GetEmloyeesDBAsync();

                await Task.Delay(3000);

                _memoryCache.Set("employees", list, TimeSpan.FromMinutes(1));
            }

            return list;
        }
    }
}
