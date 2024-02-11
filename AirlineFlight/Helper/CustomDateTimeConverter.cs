using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace AirlineFlight;
/// <summary>
/// this CusomDateTimeConverted was created to customize datetime
/// </summary>
public class CustomDateTimeConverter: JsonConverter<DateTime>
{
    //DateTime is overriden for the read mode
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString()!);
    }

    // DateTime is overriden for the write mode 
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("dd-MM-yyyy"));
    }

}
