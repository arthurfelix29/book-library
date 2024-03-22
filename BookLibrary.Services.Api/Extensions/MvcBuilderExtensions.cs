using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookLibrary.Services.Api.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddJson(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder.AddJsonOptions(ops =>
            {
                ops.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                ops.JsonSerializerOptions.WriteIndented = true;
                ops.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                ops.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }
    }
}