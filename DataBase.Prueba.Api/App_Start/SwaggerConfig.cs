using System.Web.Http;
using WebActivatorEx;
using DataBase.Prueba.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace DataBase.Prueba.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "FacturaServiceMongo.Api");
                    // modifico nombres, para el inicio del index 
                    c.IncludeXmlComments(string.Format(@"{0}\bin\DataBase.Prueba.Api.xml",
                    // copiar y pegar el enlace XML después de @"{0}\

                                      System.AppDomain.CurrentDomain.BaseDirectory));
                })
                .EnableSwaggerUi();
        }
    }
}
