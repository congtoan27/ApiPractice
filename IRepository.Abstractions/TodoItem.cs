using MongoDB.Bson.Serialization.Attributes;

namespace ToDoRepository

{
    public class TodoItem
    {
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)] public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
