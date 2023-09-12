using System.Text.Json;
using System.Text.Json.Serialization;

namespace RinhaCompiler.Interpreter;

public class TermConverter : JsonConverter<Term>
{
    public override Term? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);

        if (!doc.RootElement.TryGetProperty("kind", out var kindProperty))
            throw new JsonException("Invalid JSON structure for Term");

        var term = new Term
        {
            Kind = kindProperty.Deserialize(SourceGenerationContext.Default.Kind),
            // Location = doc.RootElement.GetProperty("location").Deserialize(SourceGenerationContext.Default.Location)!
        };

        switch (term.Kind)
        {
            case Kind.Print:
                term.Print = doc.RootElement.Deserialize(SourceGenerationContext.Default.Print);
                break;
            case Kind.Str:
                term.Str = doc.RootElement.GetProperty("value").GetString();
                break;
            case Kind.Int:
                term.Int = doc.RootElement.GetProperty("value").GetInt32();
                break;
            case Kind.Bool:
                term.Bool = doc.RootElement.GetProperty("value").GetBoolean();
                break;
            case Kind.Binary:
                term.BinaryOp = doc.RootElement.Deserialize(SourceGenerationContext.Default.BinaryOp);
                break;
            default:
                break;
        }

        return term;
    }

    public override void Write(Utf8JsonWriter writer, Term value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}