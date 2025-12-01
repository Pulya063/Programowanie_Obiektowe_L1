using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


class Program
{
    static void Main(string[] args)
    {
        ZapiszDaneDoPliku();
        OdczytajDaneZPliku();
        DopiszDaneDoPliku();
    }

    static void ZapiszDaneDoPliku()
    {
        Console.WriteLine("Podaj kilka linii tekstu (Enter na pustej linii kończy):");
        string filePath = "dane.txt";

        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                writer.WriteLine(input);
            }
        }

        Console.WriteLine("Dane zapisano.\n");
    }

    static void OdczytajDaneZPliku()
    {
        string filePath = "dane.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Plik nie istnieje.\n");
            return;
        }

        Console.WriteLine("Zawartość pliku:");
        foreach (string line in File.ReadAllLines(filePath))
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }

    static void DopiszDaneDoPliku()
    {
        Console.WriteLine("Podaj dane do dopisania (Enter na pustej linii kończy):");
        string filePath = "dane.txt";

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                writer.WriteLine(input);
            }
        }

        Console.WriteLine("Dane dopisano.\n");
    }
}

class Student
{
    string Imie { get; set; }
    string Nazwisko { get; set; }
    int[] Oceny { get; set; }

}
class Program {
    static void SerializujStudentowDoJson()
    {
        List<Student> students = new List<Student>()
        {
            new Student{ Imie = "Jan", Nazwisko = "Kowalski", Oceny = [4, 2, 3, 3, 5] },
            new Student{ Imie = "Robert", Nazwisko = "Lewandowski", Oceny = [2, 2, 1, 3, 5] },
            new Student{ Imie = "Vasia", Nazwisko = "Kowal", Oceny = [2, 2, 2, 2, 5] }
        };

        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });

        string filePath = "studenci.json";
        File.WriteAllText(filePath, json);

        Console.WriteLine("Lista studentów została zapisana do pliku studenci.json.");
    }
}

