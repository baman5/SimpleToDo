namespace SimpleToDo.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }

    public TodoItem(int id, string title)
    {
        Id = id;
        Title = title;
    }
}