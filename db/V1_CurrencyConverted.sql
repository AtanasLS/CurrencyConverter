CREATE TABLE test.history(
    id SERIAL PRIMARY KEY,
    date_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    source_curr VARCHAR,
    target_curr VARCHAR,
    value_curr INTEGER,
    result DECIMAL
);