using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builders.FacetedBuilder_CV
{
    public class CV
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public DateTime GraduationDate { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Age)}={Age.ToString()}, {nameof(BirthDate)}={BirthDate.ToString()}, {nameof(PlaceOfBirth)}={PlaceOfBirth}, {nameof(PhoneNumber)}={PhoneNumber.ToString()}, {nameof(School)}={School}, {nameof(Degree)}={Degree}, {nameof(GraduationDate)}={GraduationDate.ToString()}, {nameof(Position)}={Position}, {nameof(Company)}={Company}, {nameof(StartDate)}={StartDate.ToString()}}}";
        }
    }

    /* faceted builder */
    public class CVBuilder
    {
        protected CV CV = new CV();

        public CVPersonalInfoBuilder Is => new CVPersonalInfoBuilder(CV);
        public CVPastEducationBuilder HasPastEducation => new CVPastEducationBuilder(CV);
        public CVWorkExperienceBuilder HasWorkExperience => new CVWorkExperienceBuilder(CV);

        public static implicit operator CV(CVBuilder cvBuilder)
        {
            return cvBuilder.CV;
        }
    }

    public class CVPersonalInfoBuilder : CVBuilder
    {
        public CVPersonalInfoBuilder(CV cv)
        {
            this.CV = cv;
        }

        public CVPersonalInfoBuilder Called(string name)
        {
            CV.Name = name;
            return this;
        }

        public CVPersonalInfoBuilder Aged(int age)
        {
            CV.Age = age;
            return this;
        }

        public CVPersonalInfoBuilder Born(DateTime birthDate)
        {
            CV.BirthDate = birthDate;
            return this;
        }

        public CVPersonalInfoBuilder BornAt(string placeOfBirth)
        {
            CV.PlaceOfBirth = placeOfBirth;
            return this;
        }

        public CVPersonalInfoBuilder WithPhoneNumber(int phoneNumber)
        {
            CV.PhoneNumber = phoneNumber;
            return this;
        }
    }

    public class CVPastEducationBuilder : CVBuilder
    {
        public CVPastEducationBuilder(CV cv)
        {
            this.CV = cv;     
        }
        public CVPastEducationBuilder WithSchool(string school)
        {
            CV.School = school;
            return this;
        }

        public CVPastEducationBuilder WithDegree(string degree)
        {
            CV.Degree = degree;
            return this;
        }

        public CVPastEducationBuilder GraduatedAt(DateTime graduationDate)
        {
            CV.GraduationDate = graduationDate;
            return this;
        }
    }

    public class CVWorkExperienceBuilder : CVBuilder
    {
        public CVWorkExperienceBuilder(CV cv)
        {
            this.CV = cv;
        }

        public CVWorkExperienceBuilder AsA(string position)
        {
            CV.Position = position;
            return this;
        }

        public CVWorkExperienceBuilder At(string company)
        {
            CV.Company = company;
            return this;
        }

        public CVWorkExperienceBuilder StartedAt(DateTime startDate)
        {
            CV.StartDate = startDate;
            return this;
        }
    }
        
    public class FacetedBuilder_CVBuilder
    {
        public static void Execute()
        {
            Console.WriteLine("\n##################### faceted builder pattern - CVbuilder #####################");

            CVBuilder cvBuilder = new CVBuilder();
            CV cv = cvBuilder.Is.Called("Monkey D. Luffy")
                .Aged(25)
                .Born(new DateTime(1997, 1, 1))
                .BornAt("Foosha Village")
                .WithPhoneNumber(123456789)
                .HasPastEducation.WithSchool("MIT")
                .WithDegree("Pirate King")
                .GraduatedAt(new DateTime(2017, 1, 1))
                .HasWorkExperience.AsA("Software Engineer")
                .At("Egghead Inc.")
                .StartedAt(new DateTime(2017, 1, 1));

            Console.WriteLine(cv);
        }
    }
}
