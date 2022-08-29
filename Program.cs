using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using _2Department.XmlServices;
using _2Department.Models;
using _2Department.DataSeeding;
using _2Department.ConsoleServices;

namespace _2Department
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(Config.XmlFilesDirPath);
            context.EnsureDataSeeded();

            var menuWriter = new MenuWriter();


            while(true)
            {
                menuWriter.PrintMenu();
                Console.WriteLine("Your option: ");
            }

        }
    }
}