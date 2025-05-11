using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArchitectureApp.API.Extensions
{
    public class HideSchemasDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Components.Schemas.Clear(); // Clears the schema section only
        }
    }
}
