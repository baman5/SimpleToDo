using SimpleToDo.Models;

namespace SimpleToDo.Services;

public class TodoService
{
    private readonly List<TodoItem> _todos = new();
    private int _nextId = 1;

    public void AddTodo(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Oppgavetekst kan ikke være tom.");
        }

        TodoItem todo = new TodoItem(_nextId, title);
        _todos.Add(todo);
        _nextId++;
    }

    public List<TodoItem> GetAllTodos()
    {
        return _todos;
    }

    public bool MarkAsCompleted(int id)
    {
        TodoItem? todo = _todos.FirstOrDefault(t => t.Id == id);

        if (todo == null)
        {
            return false;
        }

        todo.IsCompleted = true;
        return true;
    }

    public bool DeleteTodo(int id)
    {
        TodoItem? todo = _todos.FirstOrDefault(t => t.Id == id);

        if (todo == null)
        {
            return false;
        }

        _todos.Remove(todo);
        return true;
    }
}