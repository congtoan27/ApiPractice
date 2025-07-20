using Microsoft.AspNetCore.Mvc;
using ToDoRepository;

namespace TodoApi.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IToDoRepository todoRepository;

        public TodoController(IToDoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            return Ok(await todoRepository.getTodoItemsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(Guid id)
        {
            var item = await todoRepository.getTodoItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem(TodoItem todoItem)
        {
            return Ok(await todoRepository.createTodoItemAsync(todoItem));
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(int id)
        {
            return Ok($"DeleteTodoItem{id}");
        }
    }
}