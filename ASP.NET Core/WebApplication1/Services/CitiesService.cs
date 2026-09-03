using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService, IDisposable
    {
        List<string> _cities;
        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities =
            [
                "London", "Paris", "New york", "Tokyo", "Rome"
            ];

            //TO DO: Add logic to open the db connection
        }
        
        readonly Guid _serviceInstanceId;
        public Guid ServiceInstanceId { get { return _serviceInstanceId; } } 

        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            //TO DO: add logic to close db connection
        }
    }
}
