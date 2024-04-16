using System.ComponentModel.DataAnnotations;
using infrastructure.models;
using infrastructure.repositories;

namespace service
{
    public class HistoryService
    {
        private readonly HistoryRepository _repository;

        Dictionary<string, decimal> rates = new Dictionary<string, decimal>
            {
                {"USD", 1m},
                {"EUR", 0.93m},
                {"GBP", 0.76m},
                {"JPY", 130.53m},
                {"AUD", 1.31m}
            };

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

        public History CreateHistory( string sourceCurrency, string targetCurrency, 
                                    decimal valueCurrency)
        {
             DateTime dateCreated = DateTime.Now;
             
             decimal rateToUsd = rates[sourceCurrency!];
             decimal amountInUSD = valueCurrency / rateToUsd;
             decimal targetRate = rates[targetCurrency!];
             decimal result = amountInUSD * targetRate;
            
             var history = new History()
             {
                DateCreated = dateCreated,
                SourceCurrency = sourceCurrency,
                TargetCurrency = targetCurrency,
                ValueCurrency = valueCurrency,
                Result = result
             };

             try
             {
                return _repository.CreateHistory(history);
             }
             catch(Exception)
             {
                throw new Exception("Could not create the history!");
             }
        }



        
    }
}