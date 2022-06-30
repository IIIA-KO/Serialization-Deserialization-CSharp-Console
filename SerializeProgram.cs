using MySerializeClassLib;

Console.OutputEncoding = System.Text.Encoding.UTF8;

List<PC> Computers = new List<PC> {
    new PC("Asus", 39999, "S500MC"),
    new PC("Dell", 37990, "Precision 3650 v05"),
    new PC("Apple", 64999, "iMac 24"),
    new PC("Acer", 28000, "Aspire C24-1650")
    };

string Path = @"D:/listSerial.txt";

try
{
    PC.SerializeList(Path, Computers);
    Console.WriteLine("Массив було збережено");

    PC.SaveObjectsFiles(Computers);
    Console.WriteLine("Об'єкти було збережено у кожний файл окремо");
}
catch (Exception ex)
{
    PC.PrintMessage($"Помилка: {ex.Message}");
}