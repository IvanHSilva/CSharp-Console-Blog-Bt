namespace Blog.Screens.TagScreens;

using Blog.Models;
using Blog.Repositories;

public static class CreateTagScreen
{
    public static void LoadScreen()
    {
        Tag tag = ReadTagData();
        if (tag != null) CreateTag(tag);
        Console.WriteLine();
        Console.ReadKey();
        MenuTagScreen.LoadScreen();
    }

    private static Tag ReadTagData()
    {
        Console.Clear();
        Console.WriteLine("Dados da Tag:");
        Console.Write("Nome: ");
        string name = Console.ReadLine()!;
        Console.Write("Slug: ");
        string slug = Console.ReadLine()!;
        if (name != string.Empty && slug != string.Empty)
        {
            Tag tag = new Tag { Name = name, Slug = slug };
            return tag;
        }
        return null!;
    }

    private static void CreateTag(Tag tag)
    {
        try
        {
            Repository<Tag> repository = new();
            repository.Insert(tag);
            Console.WriteLine($"Tag {tag.Name} criada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível criar a tag...");
            Console.WriteLine(ex.Message);
        }
    }
}
