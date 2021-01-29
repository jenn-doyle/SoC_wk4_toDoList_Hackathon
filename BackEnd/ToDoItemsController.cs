using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class ToDoItemsController : ControllerBase
{
    private readonly ToDoItemsRepository _ToDoItemsRepository;

    public ToDoItemsController()
    {
        _ToDoItemsRepository = new ToDoItemsRepository();
    }

    [HttpGet]
    public IEnumerable<ToDoItems> GetAllToDoItems(int id)
    {
        return _ToDoItemsRepository.GetAll();
    }

    [HttpGet("{id}")]
    public ToDoItems GetToDoItems(int id)
    {
        return _ToDoItemsRepository.GetOne(id);
    }

    [HttpPut("{id}")]
    public ToDoItems UpdateToDoItems(int id, [FromBody] ToDoItems ToDoItems)
    {
        ToDoItems.Id = id;
        return _ToDoItemsRepository.Update(ToDoItems);
    }

    [HttpPost]
    public ToDoItems CreateToDoItems([FromBody] ToDoItems ToDoItems)
    {
        return _ToDoItemsRepository.Insert(ToDoItems);
    }

    [HttpDelete("{id}")]
    public void DeleteToDoItems(int id)
    {
        _ToDoItemsRepository.Delete(id);
    }


}