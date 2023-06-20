using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите путь до файла: ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            string className = null;
            bool isInClass = false;

            foreach (string line in lines)
            {
                if (line.Contains("class"))
                {
                    int startIndex = line.IndexOf("class") + 5;
                    int endIndex = line.IndexOfAny(new char[] { ' ', ':' }, startIndex);

                    if (endIndex == -1)
                        endIndex = line.Length;

                    className = line.Substring(startIndex, endIndex - startIndex);
                    isInClass = true;
                }
                else if (isInClass && (line.Contains("public") || line.Contains("private") || line.Contains("protected") || line.Contains("internal")))
                {
                    string[] parts = line.Split(new char[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 3)
                    {
                        string accessModifier = parts[0];
                        string fieldType = parts[1];
                        string fieldName = parts[2];

                        Console.WriteLine($"{accessModifier} field {fieldName} {fieldType}");
                    }
                }
                else if (isInClass && line.Contains("{ get;") && line.Contains("set;"))
                {
                    string[] parts = line.Split(new char[] { ' ', '{', '}', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 3)
                    {
                        string accessModifier = parts[0];
                        string propertyType = parts[1];
                        string propertyName = parts[2];

                        Console.WriteLine($"{accessModifier} property {propertyName} {propertyType} GetEnable SetEnable");
                    }
                }
            }

            if (!isInClass)
            {
                Console.WriteLine("В файле не найден класс.");
            }
            else
            {
                Console.WriteLine($"В файле \"{filePath}\" найден класс {className}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при обработке файла:");
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }
}
