using infrastructure.models;
using infrastructure.repositories;

namespace service
{
    public class HistoryService
    {
        private readonly HistoryRepository _repository;

        public HistoryService(HistoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<History> GetAllHistories()
        {
            try
            {
                return _repository.GetAllHistory();
            }
            catch (Exception)
            {
                throw new Exception("Could not get all the courses!");
            }
        }

        

        
    }
}