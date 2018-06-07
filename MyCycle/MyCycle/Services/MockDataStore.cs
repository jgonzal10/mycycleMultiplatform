using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyCycle.Models;

[assembly: Xamarin.Forms.Dependency(typeof(MyCycle.Services.MockDataStore))]
namespace MyCycle.Services
{
    public class MockDataStore : IDataStore<Period>
    {
        List<Period> periods;

        public MockDataStore()
        {
            periods = new List<Period>();
            var mockPeriods = new List<Period>
            {

            };

            foreach (var period in mockPeriods)
            {
                periods.Add(period);
            }
        }

        public async Task<bool> UpdatePeriodAsync(Period period)
        {
            var _period = periods.Where((Period arg) => arg.Id == period.Id).FirstOrDefault();
            periods.Remove(_period);
            periods.Add(period);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteIPeriodAsync(string id)
        {
            var _period = periods.Where((Period arg) => arg.Id == id).FirstOrDefault();
            periods.Remove(_period);

            return await Task.FromResult(true);
        }


        public async Task<Period> GetPeriodAsync(string id)
        {
            return await Task.FromResult(periods.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Period>> GetPeriodsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(periods);
        }

        public async Task<bool> AddPeriodAsync(Period period)
        {
            periods.Add(period);

            return await Task.FromResult(true);
        }



    }
}