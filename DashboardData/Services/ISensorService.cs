using DashboardData.Models;
namespace DashboardData.Services
{
    public interface ISensorService
    {
        Task<List<SensorData>> GetSensorDataAsync();
        void AddSensor(SensorData sensorData);
    }
}
