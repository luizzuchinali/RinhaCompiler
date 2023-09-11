using System.Text.Json;
using RinhaCompiler.Interpreter;
using static System.Console;
using IOFile = System.IO.File;

var path = args[0];

if (!IOFile.Exists(path))
{
    WriteLine("file not exists");
    return 1;
}

var program = JsonSerializer.Deserialize(IOFile.ReadAllText(args[0]), SourceGenerationContext.Default.File);

Evaluator.Eval(program!.Expression);

return 0;