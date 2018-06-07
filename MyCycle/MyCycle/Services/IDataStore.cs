using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCycle.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddPeriodAsync(T period);
        Task<bool> UpdatePeriodAsync(T period);
        Task<bool> DeleteIPeriodAsync(string id);
        Task<T> GetPeriodAsync(string id);
        Task<IEnumerable<T>> GetPeriodsAsync(bool forceRefresh = false);


    }
}
