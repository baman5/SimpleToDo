using SimpleToDo.Models;

namespace SimpleToDo.Services;

public class TodoService
{
    private readonly List<TodoItem> _todos = new();
    private int _nextId = 1;

    public void AddTodo(string title)
    {
        TodoItem todo = new TodoItem(_nextId, title);
        _todos.Add(todo);
        _nextId++;
    }

    public List<TodoItem> GetAllTodos()
    {
        return _todos;
    }
}