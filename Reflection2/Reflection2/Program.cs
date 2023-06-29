﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;

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

                foreach (var field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
                {
                    var level = GetAccessLevel(field);

                    Console.WriteLine($"{className} {level} field {field.FieldType} {field.Name}");
                }

                foreach (var property in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
                {
                    var level = GetAccessLevel(property.GetGetMethod(true) ?? property.GetSetMethod(true));

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

    static string GetAccessLevel(MethodInfo method)
    {
        if (method.IsPublic)
            return "public";
        else if (method.IsPrivate)
            return "private";
        else if (method.IsFamily)
            return "protected";
        else
            return "default";
    }

    static string GetAccessLevel(FieldInfo field)
    {
        if (field.IsPublic)
            return "public";
        else if (field.IsPrivate)
            return "private";
        else if (field.IsFamily)
            return "protected";
        else
            return "default";
    }
}
