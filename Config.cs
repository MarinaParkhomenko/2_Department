using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2Department.Models;
using _2Department.Models.Enum;

namespace _2Department
{
    public static class Config
    {
        public static string XmlFilesDirPath = "../../../DataStorage";

        public static Dictionary<string, string> EntitiesFileNames = new Dictionary<string, string>()
        {
            { nameof(Specialty), "Specialty.xml" },
            { nameof(Subject), "Subject.xml" },
            { nameof(SubjectToSpecialty), "SubjectToSpecialty.xml" },
            { nameof(Teacher), "Teacher.xml" },
            { nameof(Teacher), "InvitedTeachers.xml" },
        };
    }
}
