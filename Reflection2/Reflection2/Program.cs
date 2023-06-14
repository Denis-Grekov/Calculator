using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь до файла:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath);
            string className = GetClassName(fileContent);
            if (!string.IsNullOrEmpty(className))
            {
                Console.WriteLine($"В файле \"{filePath}\" найден класс {className}.");
                string classInfo = GetClassInfo(fileContent);
                Console.WriteLine(classInfo);
            }
            else
            {
                Console.WriteLine("В указанном файле не найден класс.");
            }
        }
        else
        {
            Console.WriteLine("Указанный файл не существует.");
        }

        Console.ReadLine();
    }

    static string GetClassName(string fileContent)
    {
        Regex classRegex = new Regex(@"class\s+([\w\d_]+)\b");
        Match match = classRegex.Match(fileContent);
        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        return null;
    }

    static string GetClassInfo(string fileContent)
    {
        Regex fieldRegex = new Regex(@"^\s*(public|private|protected)\s+(?!class)(\w+)\s+(\w+);", RegexOptions.Multiline);
        Regex propertyRegex = new Regex(@"^\s*(public|private|protected)\s+(\w+)\s+(\w+)\s+{\s+(get;)?\s+(set;)?\s+}", RegexOptions.Multiline);

        MatchCollection fieldMatches = fieldRegex.Matches(fileContent);
        MatchCollection propertyMatches = propertyRegex.Matches(fileContent);

        string classInfo = "";

        foreach (Match match in fieldMatches)
        {
            string accessModifier = match.Groups[1].Value;
            string fieldType = match.Groups[2].Value;
            string fieldName = match.Groups[3].Value;
            classInfo += $"{accessModifier} field {fieldName} {fieldType}\n";
        }

        foreach (Match match in propertyMatches)
        {
            string accessModifier = match.Groups[1].Value;
            string propertyType = match.Groups[2].Value;
            string propertyName = match.Groups[3].Value;
            bool isGetEnabled = !string.IsNullOrEmpty(match.Groups[4].Value);
            bool isSetEnabled = !string.IsNullOrEmpty(match.Groups[5].Value);

            string accessString = isGetEnabled ? "GetEnable" : "GetDisable";
            accessString += " ";

            if (isSetEnabled)
                accessString += isGetEnabled ? "SetEnable" : "SetDisable";
            else
                accessString += "SetDisable";

            classInfo += $"{accessModifier} property {propertyName} {propertyType} {accessString}\n";
        }

        return classInfo;
    }
}
