using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2Department.Models.Enum;

namespace _2Department.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public FormOfControl FormOfControl { get; set; }
        public decimal Hours { get; set; }
        public int Course { get; set; }

    }
}
