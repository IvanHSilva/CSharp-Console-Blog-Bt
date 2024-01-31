using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class ListTagScreen
{
    public static void LoadScreen()
    {
        ListTags();
        Console.WriteLine();
        Console.ReadKey();
        MenuTagScreen.LoadScreen();
    }

    private static void ListTags()
    {
        Repository<Tag> repository = new();
        var tags = repository.SelectAll();

        Console.Clear();
        Console.WriteLine("Tags:");
        foreach (var tag in tags)
        {
            Console.WriteLine($"{tag.Id}- {tag.Name} ({tag.Slug})");
        }
    }
}
