using Dapper;
using infrastructure.models;
using Npgsql;

namespace infrastructure.repositories
{
    public class HistoryRepository
    {
        private readonly  NpgsqlDataSource _dataSource;

        public HistoryRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public  IEnumerable<History> GetAllHistory()
        {
            using var conn = _dataSource.OpenConnection();
            
            return  conn.Query<History>(@$"SELECT
            id as {nameof(History.Id)},
            date_created as {nameof(History.DateCreated)},
            source_curr as {nameof(History.SourceCurrency)},
            target_curr as {nameof(History.TargetCurrency)},
            value_curr as {nameof(History.ValueCurrency)},
            result as {nameof(History.Result)}
            FROM test.history"); 
        }

        public History CreateHistory(History history)
        {
            using var conn = _dataSource.OpenConnection();

            var paramaters = new {dateCreated = history.DateCreated,sourceCurr = history.SourceCurrency,
                 targetCurr = history.TargetCurrency, valueCurr = history.ValueCurrency, result = history.Result};

            return conn.QueryFirst<History>(@$"
            insert into test.history (date_created, source_curr, target_curr, value_curr, result)
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