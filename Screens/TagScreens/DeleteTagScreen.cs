using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class DeleteTagScreen
{
    public static void LoadScreen()
    {
        Tag tag = ReadTagData();
        if (tag != null) DeleteTag(tag);
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
            return tag;
        return null!;
    }

    private static void DeleteTag(Tag tag)
    {
        try
        {
            Repository<Tag> repository = new();
            repository.Delete(tag);
            Console.WriteLine($"Tag {tag.Name} ({tag.Id}) excluída com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível excluir a tag...");
            Console.WriteLine(ex.Message);
        }
    }
}
