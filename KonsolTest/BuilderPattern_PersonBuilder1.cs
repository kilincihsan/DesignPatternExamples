namespace DesignPatternExamples.Builders.PersonBuilder1
{
    public class Person
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public JobLevel JobLevel { get; set; }
        public int Experience { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}:{Name} {nameof(Surname)}:{Surname} {nameof(Age)}:{Age} {nameof(JobLevel)}:{JobLevel} {nameof(Experience)}:{Experience} {nameof(Salary)}:{Salary}";
        }
    }

    public class PersonBuilder
    {
        private Person _person = new Person();

        public PersonBuilder SetName(string name)
        {
            if (name == null)
                throw new System.Exception("Name is required");
            _person.Name = name;
            return this;
        }

        public PersonBuilder SetSurname(string surname)
        {
            _person.Surname = surname;
            return this;
        }

        public PersonBuilder SetAge(int age)
        {
            _person.Age = age;
            return this;
        }

        public PersonBuilder SetJobLevel(JobLevel jobLevel)
        {
            _person.JobLevel = jobLevel;
            return this;
        }

        public PersonBuilder SetExperience(int experience)
        {
            _person.Experience = experience;
            return this;
        }

        public PersonBuilder SetSalary(decimal salary)
        {
            _person.Salary = salary;
            return this;
        }

        public Person Build()
        {
            if (_person.Name == null)
                throw new System.Exception("Name is required");
            if (_person.Surname == null)
                throw new System.Exception("Surname is required");
            if (_person.Age == 0)
                throw new System.Exception("Age is required");
            if (_person.Experience == 0)
                throw new System.Exception("Experience is required");
            if (_person.Salary == 0)
                throw new System.Exception("Salary is required");

            return _person;
        }
    }

    public enum JobLevel
    {
        junior,
        mid,
        senior
    }

    public class BuilderPattern_PersonBuilder1
    {
        public static void Execute()
        {
            Console.WriteLine("##################### generic builder example - personbuilder #####################");

            PersonBuilder pb = new PersonBuilder();
            pb.SetName("John").SetSurname("Doe").SetAge(12).SetJobLevel(JobLevel.senior).SetExperience(2).SetSalary(1000);
            Person p = pb.Build();
            Console.WriteLine(p.ToString());
        }
    }
}