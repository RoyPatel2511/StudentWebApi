using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Infra.Domain.Entities
{
    public class Course
    {
        public Course() { }
        public Course(int id, string courseName)
        {
            Id = id;
            CourseName = courseName;
        }

        public int Id { get; set; }
        public string CourseName { get; set; }

    }


}
