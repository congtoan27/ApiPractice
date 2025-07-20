namespace ToDoRepository;
public class MongoDbRepositoryOptions
{
public required string ConnectionString { get; set; }    
public required string DatabaseName { get; set; }
}