using SimpleToDo.Services;

namespace SimpleToDo.Tests;

public class TodoServiceTests
{
    [Fact]
    public void AddTodo_ShouldAddTodoToList()
    {
        TodoService service = new TodoService();

        service.AddTodo("Lese til eksamen");

        Assert.Single(service.GetAllTodos());
        Assert.Equal("Lese til eksamen", service.GetAllTodos()[0].Title);
    }

    [Fact]
    public void MarkAsCompleted_ShouldMarkTodoAsCompleted()
    {
        TodoService service = new TodoService();

        service.AddTodo("Lage Git commit");
        bool result = service.MarkAsCompleted(1);

        Assert.True(result);
        Assert.True(service.GetAllTodos()[0].IsCompleted);
    }

    [Fact]
    public void DeleteTodo_ShouldRemoveTodoFromList()
    {
        TodoService service = new TodoService();

        service.AddTodo("Slette testoppgave");
        bool result = service.DeleteTodo(1);

        Assert.True(result);
        Assert.Empty(service.GetAllTodos());
    }
}