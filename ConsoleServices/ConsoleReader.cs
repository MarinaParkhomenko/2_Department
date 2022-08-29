using _2Department.XmlServices;
using _2Department.Models;
using _2Department.Models.Enum;
using _2Department.ViewModels;

namespace _2Department.ConsoleServices
{
    public class ConsoleReader
    {
        private readonly Context _context;
        private readonly XmlEntityReader _reader;

        public ConsoleReader(Context context, XmlProcessors.XmlEntityReader reader)
        {
            _context = context;
            _reader = reader;
        }

        public Teacher AddTeacher()
        {
            Console.WriteLine("Creating a teacher: ");
            var teacher = new Teacher();
            Console.Write("\tType teacher's id: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
                throw new InvalidCastException("Teacher's id must be an integer");
            teacher.Id = id;
            Console.Write("\tType first name: ");
            teacher.FirstName = Console.ReadLine();
            Console.Write("\tType last name: ");
            teacher.LastName = Console.ReadLine();

            return teacher;
        }

        public Specialty AddSpecialty()
        {
            Console.WriteLine("Creating a specialty: ");
            var specialty = new Specialty();
            Console.Write("\tType specialty id: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
                throw new InvalidCastException("Specailty id must be an integer");
            specialty.Id = id;
            Console.Write("\tType specialty code: ");
            if (!int.TryParse(Console.ReadLine(), out var code))
                throw new InvalidCastException("Specailty code must be an integer");
            specialty.Code = code;
            Console.Write("\tType the name of specialty: ");
            specialty.Name = Console.ReadLine();

            return specialty;
        }

        public Subject AddSubject()
        {
            Console.WriteLine("Creating a subject: ");
            var subject = new Subject();
            Console.Write("\tType subject id: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
                throw new InvalidCastException("Subject id must be an integer");
            subject.Id = id;
            Console.Write("\tType the name of subject: ");
            subject.Name = Console.ReadLine();
            Console.Write("\tType teacher's id: ");
            if (!int.TryParse(Console.ReadLine(), out var teacherid))
                throw new InvalidCastException("Teacher's id must be an integer");
            subject.TeacherId = teacherid;
            Console.Write($"\tType form of control: The options are " +
                $"{FormOfControl.Exam} and {FormOfControl.notExam}");
            subject.FormOfControl = (FormOfControl)Enum.Parse(typeof(FormOfControl),Console.ReadLine());
            Console.Write("\tType amount of hours: ");
            if (!decimal.TryParse(Console.ReadLine(), out var hours))
                throw new InvalidCastException("Hours must be decimal");
            subject.Hours = hours;
            Console.Write("\tType course: ");
            if (!int.TryParse(Console.ReadLine(), out var course))
                throw new InvalidCastException("Course must be an integer");
            subject.Course = course;

            return subject;
        }

        public SubjectToSpecialty AddSubjectSpecialty()
        {
            Console.WriteLine("Creating a subject-specialty connection: ");
            SubjectToSpecialty subject = new SubjectToSpecialty();
            Console.Write("\tType subject id: ");
            if (!int.TryParse(Console.ReadLine(), out var subjectid))
                throw new InvalidCastException("Subject id must be an integer");
            subject.SubjectId = subjectid;
            Console.Write("\tType specailty id: ");
            if (!int.TryParse(Console.ReadLine(), out var specailtyid))
                throw new InvalidCastException("Specialty id must be an integer");
            subject.SpecialtyId = specailtyid;

            return subject;
        }
    }
    
}
