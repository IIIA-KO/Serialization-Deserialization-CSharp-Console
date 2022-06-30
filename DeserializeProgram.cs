using MySerializeClassLib;

string Path = @"D:/listSerial.txt";

try
{
    List<PC> list = PC.DeserializeList(Path);

    if (!File.Exists(Path))
    {
        throw new FileLoadException();
    }
    else
    {
        Console.WriteLine("Десереалізований масив: ");
        foreach (PC p in list)
            Console.WriteLine(p);

        for (int i = 0; i < list.Count; i++)
        {
            string path = $"D:/object{i + 1}.txt";
            PC computer = PC.DeserializeObject(path);
            Console.WriteLine($"Десереалізований об'єкт №{i + 1}:\n{computer}");
        }
    }
}
catch (Exception ex)
{
    PC.PrintMessage($"Помилка: {ex.Message}");
}