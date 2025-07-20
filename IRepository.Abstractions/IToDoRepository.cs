namespace ToDoRepository;

public interface IToDoRepository
{
    Task<IEnumerable<TodoItem>> getTodoItemsAsync();
    Task<TodoItem?> createTodoItemAsync(TodoItem todoItem);
    Task<TodoItem> getTodoItemAsync(Guid id);
}