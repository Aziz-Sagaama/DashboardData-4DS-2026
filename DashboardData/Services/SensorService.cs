using DashboardData.Data;
using DashboardData.Models;
using Microsoft.EntityFrameworkCore;
namespace DashboardData.Services
{
    public class SensorService : ISensorService
    {
        private readonly AppDbContext _dbContext;
        public SensorService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<SensorData>> GetSensorsAsync()
        {
            // EF Core traduit Include par un JOIN SQL vers la table Location
            return await _dbContext.Sensors
                .Include(s => s.Location)
                .ToListAsync();
        }

        public async Task AddSensorAsync(SensorData sensorData)
        {
            await _dbContext.Sensors.AddAsync(sensorData);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<SensorData>> GetCriticalSensorsAsync(double threshold)
        {
            return await _dbContext.Sensors
                .Include(s => s.Location)
                .Where(s => s.Value > threshold) 
                .OrderByDescending(s => s.Value) 
                .ToListAsync();                  
        }

        public async Task<double> GetAverageValueAsync()
        {
            if (!await _dbContext.Sensors.AnyAsync()) return 0;

            return await _dbContext.Sensors.AverageAsync(s => s.Value);
        }

        public async Task<double> GetMaxValueAsync()
        {
            if (!await _dbContext.Sensors.AnyAsync()) return 0;
            return await _dbContext.Sensors.MaxAsync(s => s.Value);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _dbContext.Sensors.CountAsync();
        }
    }
}
