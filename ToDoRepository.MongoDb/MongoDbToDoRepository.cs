using MongoDB.Driver;

namespace ToDoRepository;

public class MongoDbToDoRepository : IToDoRepository
{
    private readonly IMongoCollection<TodoItem> todoCollection;


    public MongoDbToDoRepository(MongoDbRepositoryOptions options)
    {
       var client = new MongoClient(options.ConnectionString);
       var database = client.GetDatabase(options.DatabaseName);
       todoCollection = database.GetCollection<TodoItem>("TodoItem");
    }
    public async Task<IEnumerable<TodoItem>> getTodoItemsAsync()
    {
        return await todoCollection.Find(item => true).ToListAsync();
    }

    public async Task<TodoItem?> createTodoItemAsync(TodoItem todoItem)
    {
       await todoCollection.InsertOneAsync(todoItem); 
       return todoItem;
    }

    public async Task<TodoItem?> getTodoItemAsync(Guid id)
    {
        return todoCollection.Find(item => item.Id == id).FirstOrDefault();
    }
}