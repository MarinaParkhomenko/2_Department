using System;
using System.Collections.Generic;
using _2Department.Models;
using _2Department.Models.Enum;
using _2Department.XmlServices;

namespace _2Department.DataSeeding
{
    public class XmlDataSeeder
    {
        private readonly string _dirPath;
        private readonly Data _data;
        private readonly WriterXml _xmlWriter;

        public XmlDataSeeder(string dirPath, WriterXml xmlWriter)
        {
            _dirPath = dirPath;
            _xmlWriter = xmlWriter;
            _data = new Data();
        }

        public void EnsureDataSeeded()
        {
            EnsureEntitySeeded(_data.Teachers, Config.EntitiesFileNames[nameof(Teacher)], "Teachers");
            EnsureEntitySeeded(_data.InvitedTeachers, Config.EntitiesFileNames[nameof(Teacher)], "Invited Teachers");
            EnsureEntitySeeded(_data.Specialties, Config.EntitiesFileNames[nameof(Specialty)], "Specialties");
            EnsureEntitySeeded(_data.SubjectToSpecialties, Config.EntitiesFileNames[nameof(SubjectToSpecialty)], "SubjectToSpecialties");
            EnsureEntitySeeded(_data.Subjects, Config.EntitiesFileNames[nameof(Subject)], "Subjects");
        }

        private void EnsureEntitySeeded<T>(IEnumerable<T> data, string fileName, string rootElName)
        {
            var path = Path.Combine(_dirPath, fileName);
            if (!File.Exists(path))
                _xmlWriter.WriteRange(data, fileName, rootElName);
        }
    }
}
