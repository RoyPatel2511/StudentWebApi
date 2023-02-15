using AutoMapper;
using Demostudentweb.Core.Domain.ResponseModel;
using Demostudentweb.Infra.Domain.Entities;
using Demostudentweb.Shared;

namespace Demostudentweb.Configuration
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()

        {
            CreateMap<PagedList<Student>, PagedList<StudentResponseModel>>();
             

            CreateMap<Student, StudentResponseModel>()
                .ForMember(x => x.CourseName, opt => opt.MapFrom(c => c.Course.CourseName));
        }
      
    }


}
