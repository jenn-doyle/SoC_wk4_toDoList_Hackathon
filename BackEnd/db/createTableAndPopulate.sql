CREATE TABLE ToDoItems (
    Id SERIAL PRIMARY KEY,
    Title VARCHAR,
    Priority TEXT,
    IsComplete BOOLEAN

);

INSERT INTO
    ToDoItems (Title, Priority, IsComplete)
VALUES
    ('Recap JavaScript functions', 'High', false),
    ('Practice array methods', 'Medium', false),
    ('Recap Document Object Model', 'Medium', true),
    ('Practice Asychronous functions', 'High', false),
    ('Create table on PostgreSQL', 'Low', true);