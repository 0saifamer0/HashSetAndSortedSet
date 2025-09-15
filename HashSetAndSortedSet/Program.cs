namespace HashSetAndSortedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            #region HashSet
            // HashSet with custom type
            HashSet<Person> peopleHash = new HashSet<Person>
            {
                new Person { Name = "Saif", Age = 30 },
                new Person { Name = "Fatma", Age = 25 },
                new Person { Name = "Naira", Age = 18 },
                new Person { Name = "Saif", Age = 30 } // Duplicate, ignored
            };

            Console.WriteLine("HashSet:");
            Console.WriteLine("---------");
            foreach (var person in peopleHash)
            {
                Console.WriteLine($"{person.Name}, {person.Age}"); // Unordered
            }
            #endregion

            #region SortedSet
            SortedSet<Person> peopleSorted = new SortedSet<Person>
            {
                new Person { Name = "Saif", Age = 30 },
                new Person { Name = "Fatma", Age = 25 },
                new Person { Name = "Naira", Age = 18 },
                new Person { Name = "Saif", Age = 30 } // Duplicate, ignored
            };

            Console.WriteLine("SortedSet:");
            Console.WriteLine("---------");
            foreach (var person in peopleSorted)
            {
                Console.WriteLine($"{person.Name}, {person.Age}"); // Sorted by age
            }
            #endregion
        }
    }

    class Person : IEquatable<Person>, IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // For HashSet
        public bool Equals(Person? other)
        {
            return other != null && this.Name == other.Name && this.Age == other.Age;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }

        // For SortedSet
        public int CompareTo(Person? other)
        {
            if (other == null)
                return 1;

            return this.Age.CompareTo(other.Age); // Sort by Age
        }
    }
}
