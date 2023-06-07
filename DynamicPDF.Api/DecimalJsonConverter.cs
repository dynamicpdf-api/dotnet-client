using Newtonsoft.Json;
using System;

namespace DynamicPDF.Api
{
    internal class DecimalJsonConverter : JsonConverter<float?>
    {
        public override float? ReadJson(JsonReader reader, Type objectType, float? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, float? value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString());
        }
    }
}
