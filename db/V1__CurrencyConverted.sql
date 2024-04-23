CREATE TABLE "CurrencyConverted".History(
    id SERIAL PRIMARY KEY,
    date_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    source_curr VARCHAR(50),
    target_curr VARCHAR(50),
    value_curr NUMERIC (18, 2),
    result NUMERIC(18, 2)
);