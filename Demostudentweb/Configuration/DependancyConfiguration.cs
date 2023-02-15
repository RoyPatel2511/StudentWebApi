using Demostudentweb.Core.Builder;
using Demostudentweb.Core.Contract;
using Demostudentweb.Core.Service;
using Demostudentweb.Core.Service.Helper;
using Demostudentweb.Infra.Contract;
using Demostudentweb.Infra.Repository;

namespace Demostudentweb.Configuration
{
    public static class DependancyConfiguration
    {
        public static void AddDependancy(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IUserRoleMapping, UserRoleMappingRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddTransient<IFileUploading,FileUploading>();
            services.AddTransient<GenerateToken>();


        }
    }
}   
