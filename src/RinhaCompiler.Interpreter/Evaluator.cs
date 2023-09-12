namespace RinhaCompiler.Interpreter;

public class Evaluator
{
    public static Return Eval(Term term) => term.Kind switch
    {
        Kind.Print => ExecPrint(term.Print!),
        Kind.Str => new Return(ReturnType.Str, term.Str),
        Kind.Int => new Return(ReturnType.Int, term.Int),
        Kind.Binary => BinaryEvaluator.BinaryEval(term.BinaryOp!),
        Kind.Bool => new Return(ReturnType.Bool, term.Bool),
        _ => throw new ArgumentOutOfRangeException(nameof(term.Kind))
    };

    public static Return ExecPrint(Print print)
    {
        var @return = Eval(print.Value);
        Console.Write(@return.Value<object>());
        return new Return(ReturnType.Void);
    }
}