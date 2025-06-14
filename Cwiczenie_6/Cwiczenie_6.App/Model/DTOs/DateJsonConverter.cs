using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cwiczenie_6.App.Model.DTOs;

public class DateJsonConverter : JsonConverter<DateTime>
{
    
    public const string DateFormat = "yyyy-MM-dd";
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)  
        => DateTime.ParseExact(reader.GetString(), DateFormat, null);
    

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) 
        => writer.WriteStringValue(value.ToString(DateFormat));
}