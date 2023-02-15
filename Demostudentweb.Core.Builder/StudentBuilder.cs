using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Infra.Domain.Entities;

namespace Demostudentweb.Core.Builder
{
    public class StudentBuilder
    {
        public  static Student Build(StudentRequestModel model,string photo)
        {
            return new Student(model.Name, model.Email, model.Birthdate, model.CourseId,photo);
        }
    }
}