using System.Text.Json.Serialization;

namespace RinhaCompiler.Interpreter;

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    UseStringEnumConverter = true,
    Converters = new[] { typeof(TermConverter) }
)]
[JsonSerializable(typeof(Kind))]
[JsonSerializable(typeof(File))]
// [JsonSerializable(typeof(Location))]
[JsonSerializable(typeof(Term))]
[JsonSerializable(typeof(Print))]
[JsonSerializable(typeof(BinaryOp))]
[JsonSerializable(typeof(BinaryOpType))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}