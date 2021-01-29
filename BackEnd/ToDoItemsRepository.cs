using System.Collections.Generic;
using Dapper;
using System;
public class ToDoItemsRepository : BaseRepository
{
    public IEnumerable<ToDoItems> GetAll()
    {
        using var connection = CreateConnection();
        return connection.Query<ToDoItems>("SELECT * FROM ToDoItems;");
    }

    public ToDoItems GetOne(long id)
    {
        using var connection = CreateConnection();
        return connection.QuerySingle<ToDoItems>("SELECT * FROM ToDoItems WHERE Id = @Id;", new { Id = id });
    }

    public void Delete(long id)
    {
        using var connection = CreateConnection();
        connection.Execute("DELETE FROM ToDoItems WHERE Id = @Id;", new { Id = id });
    }

    public ToDoItems Update(ToDoItems ToDoItems)
    {
        using var connection = CreateConnection();  
        return connection.QuerySingle<ToDoItems>("UPDATE ToDoItems SET Title = @Title, Priority = @Priority, IsComplete = @IsComplete WHERE Id = @Id; SELECT * FROM ToDoItems Where Id = @Id", ToDoItems);
    }

    public ToDoItems Insert(ToDoItems ToDoItems)
    {
        using var connection = CreateConnection(); 
        return connection.QuerySingle<ToDoItems>("INSERT INTO ToDoItems (Title, Priority, IsComplete) VALUES (@Title, @Priority, @IsComplete); SELECT * FROM ToDoItems Where Id = last_insert_rowid();", ToDoItems);
    }


}
