using DashboardData.Models;
namespace DashboardData.Services
{
    public interface ISensorService
    {
        Task<List<SensorData>> GetSensorDataAsync();
        void AddSensor(SensorData sensorData);
    }

    public class SensorService : ISensorService
    {
        private readonly List<SensorData> _sensors = new List<SensorData>()
        {
            new SensorData { Name = "Temp_Salon", Value = 22.5 },
            new SensorData { Name = "Hum_Cuisine", Value = 45.0 },
            new SensorData { Name = "C02_Bureau", Value = 800 },
            new SensorData { Name = "Temp_Chambre", Value = 20.0 },
            new SensorData { Name = "Hum_Salon", Value = 40.0 },
            new SensorData { Name = "Temp_Bureau", Value = 600 },
        };
        public async Task<List<SensorData>> GetSensorDataAsync()
        {
            await Task.Delay(2000); // Simulate async data retrieval
            return _sensors;
        }
        public void AddSensor(SensorData sensorData)
        {
            _sensors.Add(sensorData);
        }
    }
}
