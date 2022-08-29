using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2Department.XmlServices;
using _2Department.Models;
using _2Department.Models.Enum;
using _2Department.ViewModels;

namespace _2Department.ConsoleServices
{
    public class ConsoleWriter
    {
        public void GetTeachers(IEnumerable<Teacher> list)
        {
            foreach (Teacher teacher in list)
            {
                Console.WriteLine(teacher.Id + ". " + teacher.FirstName + " " + teacher.LastName);
                Console.WriteLine();
            }
        }

        public void GetSpecialties(IEnumerable<Specialty> list)
        {
            foreach (Specialty specialty in list)
            {
                Console.WriteLine(specialty.Id + ". " + specialty.Code + " " + specialty.Name);
                Console.WriteLine();
            }
        }

        public void GetSubjects(IEnumerable<SubjectInfoViewModel> list)
        {
            foreach (SubjectInfoViewModel subject in list)
            {
                Console.WriteLine(subject.Subject.Id + ". " + subject.Subject.Name);
                Console.WriteLine(subject.Teacher.FirstName + " " + subject.Teacher.LastName);
                Console.WriteLine(subject.Subject.FormOfControl);
                Console.WriteLine(subject.Subject.Hours + " hours");
                Console.WriteLine("Course " + subject.Subject.Course);
                Console.WriteLine(subject.Specialty.Code + " " + subject.Specialty.Name);
                Console.WriteLine();
            }
        }

        public void GetSubjectsAndTeachers(IEnumerable<TeacherSubjectViewModel> list)
        {
            foreach (TeacherSubjectViewModel subject in list)
            {
                Console.WriteLine(subject.Subject.Id + ". " + subject.Subject.Name);
                Console.WriteLine(subject.Teacher.FirstName + " " + subject.Teacher.LastName);
                Console.WriteLine("Course " + subject.Subject.Course);
                Console.WriteLine();
            }
        }

        public void GetTeachersAndSpecialties(IEnumerable<TeacherSpecialtyViewModel> list)
        {
            foreach (TeacherSpecialtyViewModel teacher in list)
            {
                Console.WriteLine(teacher.Specialty.Id + ". " + teacher.Specialty.Name);
                Console.WriteLine(teacher.Teacher.FirstName + " " + teacher.Teacher.LastName);
                Console.WriteLine(teacher.Specialty.Code + " " + teacher.Specialty.Name);
                Console.WriteLine();
            }
        }

        public void TeachersWhoTeach2Course(IEnumerable<TeacherSubjectViewModel> list)
        {
            foreach (TeacherSubjectViewModel teacher in list)
            {
                Console.WriteLine(teacher.Subject.Id + ". " + teacher.Subject.Name);
                Console.WriteLine(teacher.Teacher.FirstName + " " + teacher.Teacher.LastName);
                Console.WriteLine("Course " + teacher.Subject.Course);
                Console.WriteLine();
            }
        }

        public void SubjectsWhereTeacherNameStartsWithS(IEnumerable<TeacherSubjectViewModel> list)
        {
            foreach (TeacherSubjectViewModel teacher in list)
            {
                Console.WriteLine(teacher.Subject.Id + ". " + teacher.Subject.Name);
                Console.WriteLine(teacher.Teacher.FirstName + " " + teacher.Teacher.LastName);
                Console.WriteLine();
            }
        }

        public void SubjectsSortedBySpecialties(IEnumerable<Subject> list)
        {
            foreach (Subject subject in list)
            {
                Console.WriteLine(subject.Id + ". " + subject.Name);
                Console.WriteLine(subject.FormOfControl);
                Console.WriteLine(subject.Hours + " hours");
                Console.WriteLine("Course " + subject.Course);
                Console.WriteLine();
            }
        }

        public void TeachersWith2OrMoreSubjects(IEnumerable<TeacherAndAmountViewModel> list)
        {
            foreach (TeacherAndAmountViewModel teacher in list)
            {
                Console.WriteLine(teacher.Teacher.Id + ". " 
                    + teacher.Teacher.FirstName + " " + teacher.Teacher.LastName);
                Console.WriteLine(teacher.Amount + " subjects");
                Console.WriteLine();
            }
        }

        public void SubjectsWhereYearsOfExp(IEnumerable<Subject> list)
        {
            foreach (Subject subject in list)
            {
                Console.WriteLine(subject.Id + ". " + subject.Name);
                Console.WriteLine(subject.Hours + " hours");
                Console.WriteLine("Course " + subject.Course);
                Console.WriteLine();
            }
        }

        public void TeachersAndSumHours(IEnumerable<TeacherAndAmountViewModel> list)
        {
            foreach (TeacherAndAmountViewModel teacher in list)
            {
                Console.WriteLine(teacher.Teacher.Id + ". "
                    + teacher.Teacher.FirstName + " " + teacher.Teacher.LastName);
                Console.WriteLine(teacher.Amount + " hours");
                Console.WriteLine();
            }
        }
    }
}
