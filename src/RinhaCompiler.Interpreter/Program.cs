using File = System.IO.File;

var path = args[0];
if (!File.Exists(path))
{
    WriteLine("file not exists");
    return;
}

var program = JsonSerializer.Deserialize(File.ReadAllText(args[0]), SourceGenerationContext.Default.File);
if (program is null)
{
    WriteLine("Failed to parse ast");
    return;
}

Evaluator.Eval(program.Expression);