using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]s")]
public class ToDoItemController : ControllerBase
{
    private readonly ToDoItemRepository _toDoItemRepository;

    public ToDoItemController()
    {
        _toDoItemRepository = new ToDoItemRepository();
    }

    [HttpGet]
    public IEnumerable<ToDoItem> GetAllToDoItems(int id)
    {
        return _toDoItemRepository.GetAll();
    }

    [HttpGet("{id}")]
    public ToDoItem GetToDoItem(int id)
    {
        return _toDoItemRepository.GetOne(id);
    }

    [HttpPut("{id}")]
    public ToDoItem UpdateToDoItem(int id, [FromBody] ToDoItem toDoItem)
    {
        toDoItem.Id = id;
        return _toDoItemRepository.Update(toDoItem);
    }

    [HttpPost]
    public ToDoItem CreateToDoItem([FromBody] ToDoItem toDoItem)
    {
        return _toDoItemRepository.Insert(toDoItem);
    }

    [HttpDelete("{id}")]
    public void DeleteToDoItem(int id)
    {
        _toDoItemRepository.Delete(id);
    }

    [HttpDelete]
    public void DeleteAllToDoItems()
    {
        _toDoItemRepository.DeleteAll();
    }

}

