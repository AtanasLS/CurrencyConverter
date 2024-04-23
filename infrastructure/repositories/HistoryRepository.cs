using System.Runtime.CompilerServices;
using Dapper;
using infrastructure.models;
using Npgsql;

namespace infrastructure.repositories
{
    public class HistoryRepository
    {
        private readonly  NpgsqlDataSource? _dataSource;
        private readonly List<History> testHistories;

        public HistoryRepository(NpgsqlDataSource? dataSource)
        {
            if (dataSource != null)
            {
                _dataSource = dataSource;
            }
            testHistories = new List<History>();
        History model1 = new History { DateCreated = DateTime.Now, 
                                        SourceCurrency = "EUR", TargetCurrency = "USD", ValueCurrency = 30, Result = 25};
        History model2 = new History { DateCreated = DateTime.Now,
                                         SourceCurrency = "USD", TargetCurrency = "EUR", ValueCurrency = 40, Result = 20};
        testHistories.Add(model1);
        testHistories.Add(model2);
        }

        public  IEnumerable<History> GetAllHistory()
        {
            if(_dataSource == null)
            {
                return testHistories;
            }

            using var conn = _dataSource.OpenConnection();
            
            return  conn.Query<History>(@$"SELECT
            id as {nameof(History.Id)},
            date_created as {nameof(History.DateCreated)},
            source_curr as {nameof(History.SourceCurrency)},
            target_curr as {nameof(History.TargetCurrency)},
            value_curr as {nameof(History.ValueCurrency)},
            result as {nameof(History.Result)}
            FROM public.history");
        }

        public History CreateHistory(History history)
        {
            if(_dataSource == null) 
            {
                return history;
            }
                     
            using var conn = _dataSource.OpenConnection();

            var paramaters = new {dateCreated = history.DateCreated,sourceCurr = history.SourceCurrency,
                 targetCurr = history.TargetCurrency, valueCurr = history.ValueCurrency, result = history.Result};

            return conn.QueryFirst<History>(@$"
            insert into public.history (date_created, source_curr, target_curr, value_curr, result)
            values (@dateCreated, @sourceCurr, @targetCurr, @valueCurr, @result)
            RETURNING
            id as {nameof(History.Id)},
            date_created as {nameof(History.DateCreated)},
            source_curr as {nameof(History.SourceCurrency)},
            target_curr as {nameof(History.TargetCurrency)},
            value_curr as {nameof(History.ValueCurrency)},
            result as {nameof(History.Result)}
            ;", paramaters);
        }

    }
}