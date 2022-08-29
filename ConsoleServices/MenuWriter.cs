using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Department.ConsoleServices
{
    public class MenuWriter
    {
        public void PrintMenu()
        {
            var sb = new StringBuilder();
            sb.Append("Options: \n");
            sb.Append("0. Add New Teacher \n");
            sb.Append("1. Add New Specialty \n");
            sb.Append("2. Add New Subject \n");
            sb.Append("3. Add New SubjectToSpecialty \n");
            Console.WriteLine(sb.ToString());
        }
    }
}
