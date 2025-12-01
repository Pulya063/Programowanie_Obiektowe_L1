using System.Text.Json;

class Students
{
    static void Main(string[] args)
    {
        SerializujStudentowDoJson();
    }
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

class Student
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public int[] Oceny { get; set; }

}