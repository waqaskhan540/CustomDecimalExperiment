using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApi;

public class StrictlyRoundedDecimalJsonConverter : JsonConverter<StrictlyRoundedDecimal>
{
    public override StrictlyRoundedDecimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Convert.ToDecimal(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, StrictlyRoundedDecimal value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((decimal)value);
    }
}