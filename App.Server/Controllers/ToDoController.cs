using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{

    private IRepository _repository { get; }
    
    public ToDoController(IRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public IEnumerable<TodoModel> Get()
    {
          return _repository.GetToDos();
        
    }
    [HttpPost]
    public ActionResult<string> Post([FromBody] TodoModel newToDo)
    {
        return _repository.PostToDo(newToDo);
    }
}