using System.Collections.Generic;
using Dapper;
using System;
public class ToDoItemRepository : BaseRepository
{
    public IEnumerable<ToDoItem> GetAll()
    {
        using var connection = CreateConnection();
        return connection.Query<ToDoItem>("SELECT * FROM ToDoItems;");
    }

    public void Delete(long id)
    {
        using var connection = CreateConnection();
        connection.Execute("DELETE FROM ToDoItems WHERE Id = @Id;", new { Id = id });
    }

    public ToDoItem GetOne(long id)
    {
        using var connection = CreateConnection();
        return connection.QuerySingle<ToDoItem>("SELECT * FROM ToDoItems WHERE Id = @Id;", new { Id = id });
    }

    public ToDoItem Update(ToDoItem ToDoItem)
    {
        using var connection = CreateConnection();  
        return connection.QuerySingle<ToDoItem>("UPDATE ToDoItems SET Title = @Title, Priority = @Priority, IsComplete = @IsComplete WHERE Id = @Id RETURNING *;", ToDoItem);
    }

    public ToDoItem Insert(ToDoItem ToDoItem)
    {
        using var connection = CreateConnection(); 
        return connection.QuerySingle<ToDoItem>("INSERT INTO ToDoItems (Title, Priority, IsComplete) VALUES (@Title, @Priority, @IsComplete) RETURNING *;", ToDoItem);
    }

}

