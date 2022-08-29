using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using _2Department.XmlServices;
using _2Department.Models;
using _2Department.Models.Enum;
using _2Department.ViewModels;

namespace _2Department
{
    internal class Queries
    {
        private readonly Context _context;

        public Queries(Context context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            var teachers = from teacher in _context.Teachers.Root?.Elements()
                           select teacher.ToEntity<Teacher>();

            return teachers;
        }

        public IEnumerable<Specialty> GetSpecialties()
        {
            var specialties = from specialty in _context.Specialties.Root?.Elements()
                              select specialty.ToEntity<Specialty>();

            return specialties;
        }

        public IEnumerable<SubjectInfoViewModel> GetSubjects()
        {
            var subjects =
                from subject in _context.Subjects.Root.Elements()

                join teacher in _context.Teachers.Root.Elements()
                    on subject.Element("Id")?.Value equals teacher.Element("Id")?.Value

                join subjectToSpecialty in _context.SubjectToSpecialties.Root.Elements()
                    on subject.Element("Id")?.Value equals subjectToSpecialty.Element("Id")?.Value

                join specialty in _context.Specialties.Root.Elements()
                    on subjectToSpecialty.Element("Id")?.Value equals specialty.Element("Id")?.Value

                select new SubjectInfoViewModel()
                {
                    Subject = subject.ToSubject(),
                    Teacher = teacher.ToTeacher(),
                    Specialty = specialty.ToSpecialty()
                };

            return subjects;
        }

        public IEnumerable<TeacherSubjectViewModel> GetSubjectsAndTeachers()
        {
            var viewModel =
                from subject in _context.Subjects.Root.Elements()

                join teacher in _context.Teachers.Root.Elements()
                    on subject.Element("Id")?.Value equals teacher.Element("Id")?.Value

                select new TeacherSubjectViewModel()
                {
                    Subject = subject.ToSubject(),
                    Teacher = teacher.ToTeacher()
                };

            return viewModel;
        }

        public IEnumerable<TeacherSpecialtyViewModel> GetTeachersAndSpecialties()
        {
            var viewModel =
                from subject in _context.Subjects.Root.Elements()

                join teacher in _context.Teachers.Root.Elements()
                    on subject.Element("Id")?.Value equals teacher.Element("Id")?.Value

                join subjectToSpecialty in _context.SubjectToSpecialties.Root.Elements()
                    on subject.Element("Id")?.Value equals subjectToSpecialty.Element("Id")?.Value

                join specialty in _context.Specialties.Root.Elements()
                    on subjectToSpecialty.Element("Id")?.Value equals specialty.Element("Id")?.Value

                select new TeacherSpecialtyViewModel()
                {
                    Teacher = teacher.ToTeacher(),
                    Specialty = specialty.ToSpecialty()
                };

            return viewModel;
        }

        // get teacher who teach 2nd course
        public IEnumerable<TeacherSubjectViewModel> TeachersWhoTeach2Course()
        {
            var viewModel =
                from subject in _context.Subjects.Root.Elements()

                join teacher in _context.Teachers.Root.Elements()
                    on subject.Element("Id")?.Value equals teacher.Element("Id")?.Value

                where ((int)subject.Element("Course") == 2)
                select new TeacherSubjectViewModel
                {
                    Teacher = teacher.ToTeacher(),
                    Subject = subject.ToSubject()
                };

            return viewModel;
        }

        public IEnumerable<TeacherSubjectViewModel> SubjectsWhereTeacherNameStartsWithS()
        {
            var viewModel =
                from subject in _context.Subjects.Root.Elements()

                join teacher in _context.Teachers.Root.Elements()
                    on subject.Element("Id")?.Value equals teacher.Element("Id")?.Value

                where (teacher.Element("First name").Value.StartsWith("S"))
                select new TeacherSubjectViewModel
                {
                    Teacher = teacher.ToTeacher(),
                    Subject = subject.ToSubject()
                };

            return viewModel;
        }

        public IEnumerable<Subject> SubjectsSortedBySpecialties()
        {
            var subjects =
                from subject in _context.Subjects.Root.Elements()

                join subjectToSpecialty in _context.SubjectToSpecialties.Root.Elements()
                    on subject.Element("Id")?.Value equals subjectToSpecialty.Element("Id")?.Value

                join specialty in _context.Specialties.Root.Elements()
                    on subjectToSpecialty.Element("Id")?.Value equals specialty.Element("Id")?.Value

                orderby specialty.Element("Code").Value
                select subject.ToEntity<Subject>();

            return subjects;
        }

        public IEnumerable<Teacher> TeachersWhoDontTeach()
        {
            var teachers1 = _context.Teachers.Root.Elements()
                .Except(_context.Teachers.Root.Elements()
                .Join(_context.Subjects.Root?.Elements(),
                    teacher => (int)teacher.Element("TeacherId"),
                    subject => (int)subject.Element("Id"),
                    (teacher, subject) => teacher)
                .Select(teacher => teacher.ToTeacher()));

            var teachers2 = _context.InvitedTeachers.Root.Elements()
                .Except(_context.InvitedTeachers.Root.Elements()
                .Join(_context.Subjects.Root?.Elements(),
                    teacher => (int)teacher.Element("TeacherId"),
                    subject => (int)subject.Element("Id"),
                    (teacher, subject) => teacher)
                .Select(teacher => teacher.ToTeacher()));

            return teachers1.Union(teachers2);
        }
        //teachers with 2 or more subjcts
        public IEnumerable<TeacherAndAmountViewModel> TeachersWith2OrMoreSubjects()
        {
            return _context.Teachers.Root.Elements()
                .Join(_context.Subjects.Root.Elements(),
                    teacher => (int)teacher.Element("TeacherId"),
                    subject => (int)subject.Element("SubjectId"),
                    (teacher, subject) => new {
                        teacher = teacher.ToTeacher(),
                        subject = subject.ToSubject()
                    })
                .GroupBy(x => x.teacher)
                .Select(x => new TeacherAndAmountViewModel()
                {
                    Teacher = x.Key,
                    Amount = x.Count()
                })
                .Where(x => x.Amount > 1);
        }
        // take subjects where years of exp > smth

        public IEnumerable<Subject> SubjectsWhereYearsOfExp()
        {
            return _context.Subjects.Root.Elements()
                .Join(_context.Teachers.Root.Elements(),
                subject => (int)subject.Element("Id"),
                teacher => (int)teacher.Element("TeacherId"),
                (subject, teacher) => subject)
                .Select(subject => subject.ToEntity<Subject>());
        }
        // teachers and sum hours
        public IEnumerable<TeacherAndAmountViewModel> TeachersAndSumHours()
        {
            return _context.Teachers.Root.Elements()
                .Join(_context.Subjects.Root.Elements(),
                    teacher => (int)teacher.Element("TeacherId"),
                    subject => (int)subject.Element("SubjectId"),
                    (teacher, subject) => new
                    {
                        teacher = teacher.ToTeacher(),
                        subject = subject.ToSubject()
                    })
                .GroupBy(x => x.teacher)
                .Select(x => new TeacherAndAmountViewModel()
                {
                    Teacher = x.Key,
                    Amount = (double)x.Sum(y => y.subject.Hours)
                }) ;
        }












        public IEnumerable<Subject> SubjectsSortedByCourseDescending()
        {
            return  _context.Subjects.Root.Elements()
                .OrderByDescending(x => x.Element("Course").Value)
                .Select(x => x.ToEntity<Subject>());
        }


        public IEnumerable<Subject> SubjectsSortedByCourseThenByHours()
        {
            return _context.Subjects.Root.Elements()
                .OrderBy(x => x.Element("Course").Value)
                .ThenBy(x => x.Element("Hours").Value)
                .Select(x => x.ToEntity<Subject>());
        }

        public IEnumerable<Subject> TakeSubjectsWhere()
        {
            return _context.Subjects.Root.Elements().
                Where(x => ((int)x.Element("Hours")) >= 3).
                Select(x => x.ToEntity<Subject>());
                
        }

        public IEnumerable<Subject> TakeFirst3Subjects()
        {
            return _context.Subjects.Root.Elements().Take(3).
                Select(x => x.ToEntity<Subject>());
        }

        public IEnumerable<Subject> SubjectWhereFormOfControl()
        {
            return _context.Subjects.Root.Elements().
                Where(x => (FormOfControl)Enum.Parse(typeof(FormOfControl),
                                x.Element("FormOfControl").Value) == FormOfControl.notExam).
                Select(x => x.ToEntity<Subject>());
        }

        public decimal AverageHours()
        {
            return _context.Subjects.Root.Elements().
                Average(x => Convert.ToDecimal(x.Element("Hours")));
        }

        public int CountTeachers()
        {
            return _context.Subjects.Root.Elements().Count();
        }

        public decimal SumHoursFor2Course()
        {


        }

        public IEnumerable<Teacher> GetAllTeachers()
        {

        }
    }
}
