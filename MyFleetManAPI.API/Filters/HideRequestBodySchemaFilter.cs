using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyFleetManAPI.API.Filters
{
    public class HideRequestBodySchemaFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Remove all schemas (models)
            swaggerDoc.Components.Schemas.Clear();
        }
    }
}
