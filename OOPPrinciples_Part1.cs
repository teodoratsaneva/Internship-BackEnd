using System;
using System.ComponentModel;
using System.Reflection.PortableExecutable;

namespace School
{
    public class Person
    {
        public string Name { get; set; }
        public string Comment { get; set; }
    }

    public class Discipline
    {
        public string Name { get; set; }
        public int NumberOfLectures { get; set; }
        public int NumberOfExercises { get; set; }
        public string Comment { get; set; }
    }

    public class Student : Person
    {
        public int StudentId { get; set; }
    }

    public class Teacher : Person
    {
        List<Discipline> disciplines { get; set; }
    }

    public class Class
    {
        public string ClassIdentifier { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
    }

    public class School
    {
        public List<Class> Classes { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}

namespace Animal
{
    public class Animal
    {
        public uint Age { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public Animal(uint age, string name, string sex)
        {
            Age = age;
            Name = name;
            Sex = sex;
        }
    }

    public interface ISound
    {
        void Sound();
    }

    public class Dog : Animal, ISound
    {
        public Dog(uint age, string name, string sex) : base(age, name, sex) { }

        public void Sound()
        {
            Console.WriteLine("Woof!");
        }
    }

    public class Cat : Animal, ISound
    {
        public Cat(uint age, string name, string sex) : base(age, name, sex) { }

        public void Sound()
        {
            Console.WriteLine("Meow!");
        }
    }

    public class Kitten : Cat
    {
        public Kitten(uint age, string name) : base(age, name, "Female") { }
    }

    public class Tomcat : Cat
    {
        public Tomcat(uint age, string name) : base(age, name, "Male") { }
    }

    public class Frog : Animal, ISound
    {
        public Frog(uint age, string name, string sex) : base(age, name, sex) { }

        public void Sound()
        {
            Console.WriteLine("Rabbit!");
        }
    }

    public class Program
    {
        static float CalculateAverageAge<T>(T[] animals) where T : Animal
        {
            float sum = 0;

            foreach (T animal in animals)
            {
                sum += (float)animal.Age;
            }

            float result = sum / animals.Length;

            return result;
        }

        static void Main(string[] args)
        {
            Dog[] dogs = {
                new Dog(3, "Buddy", "Male"),
                new Dog(5, "Rex", "Male"),
                new Dog(2, "Daisy", "Female")
            };

            Frog[] frogs = {
                new Frog(1, "Frodo", "Male"),
                new Frog(2, "Lily", "Female"),
                new Frog(3, "Hopper", "Male")
            };

            Cat[] cats = {
                new Cat(2, "Whiskers", "Female"),
                new Cat(4, "Leo", "Male"),
                new Cat(1, "Mittens", "Female")
            };

            Kitten[] kittens = {
                new Kitten(6, "Fluffy"),
                new Kitten(8, "Snowball"),
                new Kitten(7, "Smokey")
            };

            Tomcat[] tomcats = {
                new Tomcat(5, "Tiger"),
                new Tomcat(4, "Simba")
            };

            Console.WriteLine(CalculateAverageAge(kittens));
            Console.WriteLine(CalculateAverageAge(tomcats));
            Console.WriteLine(CalculateAverageAge(cats));
            Console.WriteLine(CalculateAverageAge(frogs));
            Console.WriteLine(CalculateAverageAge(dogs));
        }
    }
}

namespace StrudentsAndWorkers
{
    public abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public class Student : Human
    {
        public uint Grade { get; set; }
        public Student(string firstName, string lastName, uint grade) : base(firstName, lastName)
        {
            Grade = grade;
        }
    }

    public class Worker : Human
    {
        public uint WeekSalary { get; set; }
        public uint WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, uint weekSalary, uint workHoursPerDay) : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkHoursPerDay = workHoursPerDay;
        }

        public float CalculateMoneyPerHour()
        {
            int workingDays = 5;
            return (float)WeekSalary / (WorkHoursPerDay * workingDays);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("John", "Doe", 85),
                new Student("Alice", "Smith", 92),
                new Student("Bob", "Johnson", 78),
                new Student("Emma", "Brown", 95),
                new Student("Michael", "Davis", 89),
                new Student("Olivia", "Wilson", 94),
                new Student("William", "Miller", 80),
                new Student("Sophia", "Lee", 88),
                new Student("James", "Taylor", 91),
                new Student("Charlotte", "Anderson", 87)
            };

            List<Student> sortedStudents = students.OrderBy(student => student.Grade).ToList();
            foreach (Student student in sortedStudents)
            {
                Console.WriteLine($"{student.FirstName} - {student.Grade}");
            }

            List<Worker> workers = new List<Worker>
            {
                new Worker("John", "Doe", 500, 40),
                new Worker("Alice", "Smith", 600, 35),
                new Worker("Bob", "Johnson", 480, 42),
                new Worker("Emma", "Brown", 550, 38),
                new Worker("Michael", "Davis", 520, 37),
                new Worker("Olivia", "Wilson", 530, 36),
                new Worker("William", "Miller", 490, 41),
                new Worker("Sophia", "Lee", 510, 39),
                new Worker("James", "Taylor", 540, 37),
                new Worker("Charlotte", "Anderson", 480, 43)
            };

            List<Worker> sortedWorkers = workers.OrderByDescending(worker => worker.CalculateMoneyPerHour()).ToList();

            foreach (Worker worker in sortedWorkers)
            {
                Console.WriteLine($"{worker.FirstName} - {worker.CalculateMoneyPerHour()}");
            }

            List<Human> mergedList = workers.Cast<Human>().Concat(students.Cast<Human>()).ToList();

            var sortedList = mergedList.OrderBy(human => human.FirstName).ThenBy(human => human.LastName).ToList();

            foreach (var human in sortedList)
            {
                Console.WriteLine($"{human.FirstName} {human.LastName}");
            }
        }
    }
}
