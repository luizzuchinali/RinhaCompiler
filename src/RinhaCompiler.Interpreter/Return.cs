namespace RinhaCompiler.Interpreter;

public readonly ref struct Return
{
    public readonly ReturnType Type { get; }
    private readonly object? _value;

    public Return(ReturnType type, object? value = default)
    {
        Type = type;
        _value = value;
    }

    public T? Value<T>() => (T?)_value;
}