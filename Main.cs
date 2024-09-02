using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Person class to store personal information
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    static List<Person> people = new List<Person>();
    static int nextId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("CRUD Application");
            Console.WriteLine("1. Create Person");
            Console.WriteLine("2. Read People");
            Console.WriteLine("3. Update Person");
            Console.WriteLine("4. Delete Person");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    CreatePerson();
                    break;
                case "2":
                    ReadPeople();
                    break;
                case "3":
                    UpdatePerson();
                    break;
                case "4":
                    DeletePerson();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void CreatePerson()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());
        
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        
        Person person = new Person
        {
            Id = nextId++,
            Name = name,
            Age = age,
            Email = email
        };
        
        people.Add(person);
        Console.WriteLine("Person created. Press Enter to continue.");
        Console.ReadLine();
    }

    static void ReadPeople()
    {
        Console.WriteLine("People List:");
        foreach (var person in people)
        {
            Console.WriteLine($"ID: {person.Id}, Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");
        }
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void UpdatePerson()
    {
        Console.Write("Enter the ID of the person to update: ");
        int id = int.Parse(Console.ReadLine());
        
        Person person = people.FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            Console.WriteLine("Person not found. Press Enter to continue.");
            Console.ReadLine();
            return;
        }
        
        Console.Write("Enter new name (leave blank to keep current): ");
        string name = Console.ReadLine();
        if (!string.IsNullOrEmpty(name))
        {
            person.Name = name;
        }
        
        Console.Write("Enter new age (leave blank to keep current): ");
        string ageInput = Console.ReadLine();
        if (int.TryParse(ageInput, out int age))
        {
            person.Age = age;
        }
        
        Console.Write("Enter new email (leave blank to keep current): ");
        string email = Console.ReadLine();
        if (!string.IsNullOrEmpty(email))
        {
            person.Email = email;
        }
        
        Console.WriteLine("Person updated. Press Enter to continue.");
        Console.ReadLine();
    }

    static void DeletePerson()
    {
        Console.Write("Enter the ID of the person to delete: ");
        int id = int.Parse(Console.ReadLine());
        
        Person person = people.FirstOrDefault(p => p.Id == id);
        if (person != null)
        {
            people.Remove(person);
            Console.WriteLine("Person deleted. Press Enter to continue.");
        }
        else
        {
            Console.WriteLine("Person not found. Press Enter to continue.");
        }
        Console.ReadLine();
    }
}
