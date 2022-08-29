using System;
using System.Xml.Linq;
using _2Department.Models;
using _2Department.Models.Enum;


namespace _2Department
{
    public static class Parser
    {
        public static Subject ToSubject(this XElement element)
        {
            return new Subject
            {
                Id = Convert.ToInt32(element.Element("Id")?.Value),
                Name = element.Element("Name")?.Value,
                TeacherId = Convert.ToInt32(element.Element("TeacherId")?.Value),
                FormOfControl = (FormOfControl)Enum.Parse(typeof(FormOfControl), 
                                element.Element("FormOfControl").Value),
                Hours = Convert.ToDecimal(element.Element("Hours")?.Value),
                Course = Convert.ToInt32(element.Element("Course")?.Value)
            };
        }

        public static Teacher ToTeacher(this XElement element)
        {
            return new Teacher
            {
                Id = Convert.ToInt32(element.Element("Id")?.Value),
                FirstName = element.Element("FirstName")?.Value,
                LastName = element.Element("LastName")?.Value
            };
        }

        public static Specialty ToSpecialty(this XElement element)
        {
            return new Specialty
            {
                Id = Convert.ToInt32(element.Element("Id")?.Value),
                Name = element.Element("Name")?.Value,
                Code = Convert.ToInt32(element.Element("Code")?.Value)
            };
        }

        public static SubjectToSpecialty ToSubjectToSpecialty(this XElement element)
        {
            return new SubjectToSpecialty
            {
                SubjectId = Convert.ToInt32(element.Element("SubjectId")?.Value),
                SpecialtyId = Convert.ToInt32(element.Element("SpecialtyId")?.Value)
            };
        }

    }
}
