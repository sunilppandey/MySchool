using MySchool.API.Mappings;
using System.Web.Http;

namespace MySchool.API.App_Start
{
    public class Bootstrapper
    {
        public static void Run(HttpConfiguration httpConfig)
        {
            // Configure Autofac
            AutofacWebapiConfig.Initialize(httpConfig);
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
    }
}