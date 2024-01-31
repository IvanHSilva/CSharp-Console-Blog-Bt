namespace Blog.Screens.TagScreens;

public static class MenuTagScreen
{
    public static void LoadScreen()
    {
        Console.Clear();
        Console.WriteLine("Menu de Tags");
        Console.WriteLine("------------");
        Console.WriteLine("1) Listar Tags");
        Console.WriteLine("2) Cadastrar Tag");
        Console.WriteLine("3) Atualizar Tag");
        Console.WriteLine("4) Excluir Tag");
        Console.WriteLine("0) Sair");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine()!);
        switch (option)
        {
            case 1:
                ListTagScreen.LoadScreen(); break;
            case 2:
                CreateTagScreen.LoadScreen(); break;
            case 3:
                UpdateTagScreen.LoadScreen(); break;
            case 4:
                DeleteTagScreen.LoadScreen(); break;
            default: LoadScreen(); break;
        }
    }
}