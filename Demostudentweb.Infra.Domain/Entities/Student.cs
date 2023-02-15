using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Infra.Domain.Entities
{
    public class Student : Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

       public string Photo { get; set; }
        public int CourseId { get; set; }
       
        public virtual Course Course { get; set; }
      

        public Student() 
        {

        }
        public Student(string name, string email, DateTime birthdate, int courseId,string photo)
        {
            Name = name;
            Email = email;
            Birthdate = birthdate;
            CourseId = courseId;
            Photo = photo;
            CreatedOn = DateTime.UtcNow;
            IsDeleted = false;
          

        }

        public Student Delete()
        {
            IsDeleted = true;
            UpdatedOn = DateTime.UtcNow;

            return this;
        }
        public Student Update(string name, string email, DateTime birthdate, int courseId, string photo)
        {
            Name = name;
            Email = email;
            Birthdate = birthdate;
            CourseId = courseId;
            Photo = photo;
            UpdatedOn = DateTime.UtcNow;
            return this;
        }
    }
}
