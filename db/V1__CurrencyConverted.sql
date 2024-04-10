CREATE TABLE "CurrencyConverted".test.History(
    id SERIAL PRIMARY KEY,
    date_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    source_curr VARCHAR(50),
    target_curr VARCHAR(50),
    value_curr INTEGER,
    result NUMERIC(18, 2)
);