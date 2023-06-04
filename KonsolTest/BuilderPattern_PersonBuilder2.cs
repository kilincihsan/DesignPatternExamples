using DesignPatternExamples.Builders.PersonBuilder1;

namespace DesignPatternExamples.Builders.PersonBuilder2
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
        protected Person _person = new Person();

        public class Builder: PersonJobBuilder<Builder>
        {
        }

        public static Builder New => new Builder();

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

    public class PersonInfoBuilder<SELF>: PersonBuilder where SELF:PersonInfoBuilder<SELF>
    {
        public SELF SetName(string name)
        {
            _person.Name = name;
            return (SELF)this;
        }

        public SELF SetSurname(string surname)
        {
            _person.Surname = surname;
            return (SELF)this;
        }

        public SELF SetAge(int age)
        {
            _person.Age = age;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF>: PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF:PersonJobBuilder<SELF> {

        public SELF SetJobLevel(JobLevel jobLevel)
        {
            _person.JobLevel = jobLevel;
            return (SELF)this;
        }

        public SELF SetExperience(int experience)
        {
            _person.Experience = experience;
            return (SELF)this;
        }

        public SELF SetSalary(decimal salary)
        {
            _person.Salary = salary;
            return (SELF)this;
        }
    }

    public enum JobLevel
    {
        junior,
        mid,
        senior
    }

    public class BuilderPattern_PersonBuilder2
    {
        public static void Execute()
        {
            Console.WriteLine("\n##################### builder with recursive generics example - personbuilder 2 #####################");

            /* when you use inheritance between builders you can use recursive generics to return the derived class
             * normally this would not work because PersonBuilder will not return PersonJobBuilder
             * and we need to use recursive generics to solve this problem unlike usual approach in example PersonBuilder1;
            PersonBuilder pb = new PersonBuilder();
            pb.New.SetName("John").SetSurname("Doe").SetAge(12).SetJobLevel(JobLevel.senior).SetExperience(2).SetSalary(1000);
            Person p = pb.Build();
            Console.WriteLine(p.ToString());
            */

            Person person = PersonBuilder.New.SetName("John").SetSurname("Doe").SetAge(12).SetJobLevel(JobLevel.senior).SetExperience(2).SetSalary(1000).Build();
            Console.WriteLine(person);

        }
    }
}