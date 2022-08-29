using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using _2Department.XmlServices;
using _2Department.Models;
using _2Department.DataSeeding;
using _2Department.ConsoleServices;

namespace _2Department
{
    internal class Context
    {
        private readonly string _dirPath;
        private readonly XmlDataSeeder _xmlDataSeeder;
        private readonly WriterXml _xmlWriter;

        public Context(string dirPath)
        {
            _dirPath = dirPath;
            _xmlWriter = new WriterXml(_dirPath);
            _xmlDataSeeder = new XmlDataSeeder(_dirPath, _xmlWriter);
        }

        public XDocument Specialties
        {
            get => GetXDocument(Path.Combine(_dirPath, Config.EntitiesFileNames[nameof(Specialty)]));
        }
        public XDocument Subjects
        {
            get => GetXDocument(Path.Combine(_dirPath, Config.EntitiesFileNames[nameof(Subject)]));
        }
        public XDocument SubjectToSpecialties
        {
            get => GetXDocument(Path.Combine(_dirPath, Config.EntitiesFileNames[nameof(SubjectToSpecialty)]));
        }
        public XDocument Teachers
        {
            get => GetXDocument(Path.Combine(_dirPath, Config.EntitiesFileNames[nameof(Teacher)]));
        }
        public XDocument InvitedTeachers
        {
            get => GetXDocument(Path.Combine(_dirPath, Config.EntitiesFileNames[nameof(Teacher)]));
        }

        public static XDocument GetXDocument(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);
            using (var nodeReader = new XmlNodeReader(doc))
            {
                return XDocument.Load(nodeReader);
            }
        }

        public void EnsureDataSeeded()
        {
            _xmlDataSeeder.EnsureDataSeeded();
        }
    }
}
