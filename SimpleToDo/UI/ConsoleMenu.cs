using SimpleToDo.Models;
using SimpleToDo.Services;

namespace SimpleToDo.UI;

public class ConsoleMenu
{
    private readonly TodoService _todoService = new();

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            ShowMenu();

            Console.Write("Velg et alternativ: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTodo();
                    break;

                case "2":
                    ShowTodos();
                    break;

                case "3":
                    MarkTodoAsCompleted();
                    break;

                case "4":
                    DeleteTodo();
                    break;

                case "5":
                    isRunning = false;
                    Console.WriteLine("Programmet avsluttes.");
                    break;

                default:
                    Console.WriteLine("Ugyldig valg. Prøv igjen.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("* Simple To-Do *");
        Console.WriteLine("1. Legg til oppgave");
        Console.WriteLine("2. Vis alle oppgaver");
        Console.WriteLine("3. Marker oppgave som fullført");
        Console.WriteLine("4. Slett oppgave");
        Console.WriteLine("5. Avslutt");
    }

    private void AddTodo()
    {
        Console.Write("Skriv inn oppgave: ");
        string? title = Console.ReadLine();

        try
        {
            _todoService.AddTodo(title ?? "");
            Console.WriteLine("Oppgave lagt til.");
        }
        catch (ArgumentException error)
        {
            Console.WriteLine(error.Message);
        }
    }

    private void ShowTodos()
    {
        List<TodoItem> todos = _todoService.GetAllTodos();

        if (todos.Count == 0)
        {
            Console.WriteLine("Ingen oppgaver er lagt til.");
            return;
        }

        foreach (TodoItem todo in todos)
        {
            string status = todo.IsCompleted ? "Fullført" : "Ikke fullført";
            Console.WriteLine($"{todo.Id}. {todo.Title} - {status}");
        }
    }

    private void MarkTodoAsCompleted()
    {
        Console.Write("Skriv ID på oppgaven som skal fullføres: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int id))
        {
            Console.WriteLine("Ugyldig ID.");
            return;
        }

        bool success = _todoService.MarkAsCompleted(id);

        if (success)
        {
            Console.WriteLine("Oppgaven er markert som fullført.");
        }
        else
        {
            Console.WriteLine("Fant ingen oppgave med den IDen.");
        }
    }

    private void DeleteTodo()
    {
        Console.Write("Skriv ID på oppgaven som skal slettes: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int id))
        {
            Console.WriteLine("Ugyldig ID.");
            return;
        }

        bool success = _todoService.DeleteTodo(id);

        if (success)
        {
            Console.WriteLine("Oppgaven er slettet.");
        }
        else
        {
            Console.WriteLine("Fant ingen oppgave med den ID-en.");
        }
    }
}