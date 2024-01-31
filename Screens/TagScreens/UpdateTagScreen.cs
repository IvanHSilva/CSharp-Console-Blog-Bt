using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class UpdateTagScreen
{
    public static void LoadScreen()
    {
        Tag tag = ReadTagData();
        if (tag != null) UpdateTag(tag);
        Console.WriteLine();
        Console.ReadKey();
        MenuTagScreen.LoadScreen();
    }

    private static Tag ReadTagData()
    {
        Console.Clear();
        Console.WriteLine("Dados da Tag:");
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine()!);

        Repository<Tag> repository = new();
        Tag tag = repository.Select(id);

        if (tag != null)
        {
            Console.Write($"Nome: ");
            string name = Console.ReadLine()!;
            Console.Write($"Slug: ");
            string slug = Console.ReadLine()!;
            if (name != string.Empty && slug != string.Empty)
            {
                tag.Name = name;
                tag.Slug = slug;
                return tag;
            }
        }
        return null!;
    }

    private static void UpdateTag(Tag tag)
    {
        try
        {
            Repository<Tag> repository = new();
            repository.Update(tag);
            Console.WriteLine($"Tag {tag.Name} ({tag.Id}) atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a tag...");
            Console.WriteLine(ex.Message);
        }
    }
}
