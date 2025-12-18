using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyFleetManAPI.API.Filters
{
    public class HideRequestBodySchemaFilter //: IDocumentFilter
    {
        //public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        //{
        //    var removeKeys = swaggerDoc.Components.Schemas
        //    .Where(s => s.Key.Contains("Request") || s.Key.EndsWith("Input"))
        //    .Select(s => s.Key)
        //    .ToList();

        //    foreach (var key in removeKeys)
        //    {
        //        swaggerDoc.Components.Schemas.Remove(key);
        //    }
        //}
    }
}
