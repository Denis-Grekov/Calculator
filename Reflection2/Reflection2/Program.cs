using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Reflection2;

class Program
{
    static void Main(string[] args)
    {
        

        try
        {
             var assembly = Assembly.GetExecutingAssembly();



            foreach (var type in assembly.GetTypes())
            {
                var className = type.Name; 

                foreach (var field in type.GetFields())
                {
                    var level = "default";
                    if (field.IsPublic)
                        level = "public";
                    else if (field.IsPrivate)
                        level = "private";

                    Console.WriteLine($"{className} {level} field {field.FieldType} {field.Name}");
                }

                foreach (var property in type.GetProperties())
                {
                    var access = property.GetAccessors().FirstOrDefault();

                    var level = "default";
                    if (access != null)
                    {
                        if (access.IsPublic)
                            level = "public";
                        else if (access.IsPrivate)
                            level = "private";
                    }

                    var getEnable = property.CanRead ? "GetEnable" : "GetDisable";
                    var setEnable = property.CanWrite ? "SetEnable" : "SetDisable";

                    Console.WriteLine($"{className} {level} property {property.PropertyType} {property.Name} {getEnable} {setEnable}");
                }
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
