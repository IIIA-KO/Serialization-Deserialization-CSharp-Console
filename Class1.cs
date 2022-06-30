using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MySerializeClassLib
{
    [DataContract]
    [Serializable]
    public class PC
    {
        [DataMember]
        public string Brand { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public int SerialNumber { get; private set; }

        [DataMember]
        public bool IsOn { get; set; }

        [NonSerialized]
        private Random Random;


        public PC()
        {
            Brand = string.Empty;
            Price = 0;
            Model = string.Empty;
            IsOn = false;

            Random = new Random();
            SerialNumber = Random.Next(10000, 1000000);
        }

        public PC(string brand, decimal price, string model)
        {
            Brand = brand;
            Price = price;
            Model = model;
            IsOn = false;

            Random = new Random();
            SerialNumber = Random.Next(10000, 1000000);
        }

        // Я не вигадав нічого краще, бо з формулювання завдання не зрозуміло,
        // що взагалі треба зробити цими методами
        public void TurnOn() => IsOn = true;

        public void TurnOff() => IsOn = false;

        public void Reboot() { TurnOff(); TurnOn(); }

        public override string ToString()
        {
            string ison = IsOn ? "On" : "Off";
            return $"| {Brand,-25} | {Model,-20} | {Price,-10} гривень | {SerialNumber,-10} | {ison,-5} |";
        }

        public static void PrintMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void SerializeList(string path, List<PC> computers)
        {
            try
            {
                if (File.Exists(path))
                    PrintMessage("Такий файл вже існує, дані буде перезаписано");

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.Create(path))
                {
                    binaryFormatter.Serialize(stream, computers);
                }
            }
            catch (Exception ex)
            {
                PrintMessage($"Помилка: {ex.Message}");
            }
        }

        public static List<PC> DeserializeList(string path)
        {
            List<PC> p = null;
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.OpenRead(path))
                {
                    p = binaryFormatter.Deserialize(stream) as List<PC>;
                }
            }
            catch (Exception ex)
            {
                PrintMessage($"Помилка: {ex.Message}");
            }
            return p;
        }

        public static void SaveObjectsFiles(List<PC> computers)
        {
            try
            {
                for (int i = 0; i < computers.Count; i++)
                {
                    string path = $"D:/object{i + 1}.txt";

                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    using (Stream stream = File.Create(path))
                    {
                        binaryFormatter.Serialize(stream, computers[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                PrintMessage($"Помилка: {ex.Message}");
            }
        }
        public static PC DeserializeObject(string path)
        {
            PC p = null;
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.OpenRead(path))
                {
                    p = binaryFormatter.Deserialize(stream) as PC;
                }
            }
            catch (Exception ex)
            {
                PrintMessage($"Помилка: {ex.Message}");
            }
            return p;
        }
    }
}