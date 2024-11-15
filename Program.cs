using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Plane
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string Producer { get; set; }
    public int Seats { get; set; }
    public double Max_speed { get; set; }
    public double Time { get; set; }
    public bool Toilet { get; set; }
    public bool Duty_free { get; set; }
}

class Program
{
    static List<Plane> Planes;

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Planes = new List<Plane>();

        if (!File.Exists("Plane.plane"))
        {
            Console.WriteLine("Файл 'Plane.plane' не знайдено.");
            return;
        }

        FileStream fs = new FileStream("Plane.plane", FileMode.Open);
        BinaryReader br = new BinaryReader(fs);
        try
        {
            Console.WriteLine("Читаємо дані з файлу...\n");
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                Plane plane1 = new Plane();
                for (int i = 0; i < 8; i++)
                {
                    switch (i)
                    {
                        case 0:
                            plane1.Name = br.ReadString();
                            break;
                        case 1:
                            plane1.Country = br.ReadString();
                            break;
                        case 2:
                            plane1.Producer = br.ReadString();
                            break;
                        case 3:
                            plane1.Seats = br.ReadInt32();
                            break;
                        case 4:
                            plane1.Max_speed = br.ReadDouble();
                            break;
                        case 5:
                            plane1.Time = br.ReadDouble();
                            break;
                        case 6:
                            plane1.Toilet = br.ReadBoolean();
                            break;
                        case 7:
                            plane1.Duty_free = br.ReadBoolean();
                            break;
                    }
                }
                Planes.Add(plane1);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сталась помилка: {0}", ex.Message);
        }
        finally
        {
            br.Close();
        }

        Console.WriteLine($"Несортований перелік літаків: {Planes.Count}");
        PrintPlanes();

        Planes.Sort((x, y) => x.Name.CompareTo(y.Name));
        Console.WriteLine($"Сортований перелік літаків: {Planes.Count}");
        PrintPlanes();

        Plane plane = new Plane
        {
            Name = "AndreanoCaruano",
            Country = "Diamond",
            Producer = "ProducerName",
            Seats = 25,
            Max_speed = 600.0,
            Time = 5.5,
            Toilet = true,
            Duty_free = false
        };

        Planes.Add(plane);
        Planes.Sort((x, y) => x.Name.CompareTo(y.Name));
        Console.WriteLine($"Перелік літаків: {Planes.Count}");
        PrintPlanes();

        Console.WriteLine("Видаляємо останнє значення");
        Planes.RemoveAt(Planes.Count - 1);
        Console.WriteLine($"Перелік літаків: {Planes.Count}");
        PrintPlanes();

        Console.ReadKey();
    }

    static void PrintPlanes()
    {
        foreach (var plane in Planes)
        {
            Console.WriteLine($"Name: {plane.Name}, Country: {plane.Country}, Producer: {plane.Producer}, Seats: {plane.Seats}, Max speed: {plane.Max_speed}, Time: {plane.Time}, Toilet: {plane.Toilet}, Duty free: {plane.Duty_free}");
        }
    }
}

