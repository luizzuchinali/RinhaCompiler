namespace RinhaCompiler.Interpreter;

public class Evaluator
{
    public static Return Eval(Term term) => term.Kind switch
    {
        Kind.Print => ExecPrint(term.Print!),
        Kind.Str => new Return(ReturnType.Str, term.Str),
        Kind.Int => new Return(ReturnType.Int, term.Int),
        Kind.Binary => ExecBinaryOp(term.BinaryOp!),
        Kind.Bool => new Return(ReturnType.Bool, term.Bool),
        _ => throw new ArgumentOutOfRangeException(nameof(term.Kind))
    };

    public static Return ExecPrint(Print print)
    {
        var @return = Eval(print.Value);
        Console.Write(@return.Value<object>());
        return new Return(ReturnType.Void);
    }

    public static Return ExecBinaryOp(BinaryOp term)
    {
        var lhs = Eval(term.Lhs);
        var rhs = Eval(term.Rhs);

        return term.Op switch
        {
            BinaryOpType.Add => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Int, ReturnType.Int) =>
                    new Return(ReturnType.Int, lhs.Value<int>() + rhs.Value<int>()),

                (_, _) => new Return(ReturnType.Str,
                    $"{lhs.Value<object>()}{rhs.Value<object>()}"),
            },
            BinaryOpType.Sub => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Int, ReturnType.Int) =>
                    new Return(ReturnType.Int, lhs.Value<int>() - rhs.Value<int>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            BinaryOpType.Mul => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Int, ReturnType.Int) =>
                    new Return(ReturnType.Int, lhs.Value<int>() * rhs.Value<int>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            BinaryOpType.Div => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Int, ReturnType.Int) =>
                    new Return(ReturnType.Int, lhs.Value<int>() / rhs.Value<int>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            BinaryOpType.Rem => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Int, ReturnType.Int) =>
                    new Return(ReturnType.Int, lhs.Value<int>() % rhs.Value<int>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            BinaryOpType.Eq => new Return(ReturnType.Bool, lhs.Equals(rhs)),
            BinaryOpType.Neq => new Return(ReturnType.Bool, !lhs.Equals(rhs)),
            BinaryOpType.Lt => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Int, ReturnType.Int) =>
                    new Return(ReturnType.Int, lhs.Value<int>() < rhs.Value<int>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            BinaryOpType.Gt => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Int, ReturnType.Int) =>
                    new Return(ReturnType.Int, lhs.Value<int>() > rhs.Value<int>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            BinaryOpType.Lte => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Int, ReturnType.Int) =>
                    new Return(ReturnType.Int, lhs.Value<int>() <= rhs.Value<int>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            BinaryOpType.Gte => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Int, ReturnType.Int) =>
                    new Return(ReturnType.Int, lhs.Value<int>() >= rhs.Value<int>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            BinaryOpType.And => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Bool, ReturnType.Bool) =>
                    new Return(ReturnType.Bool, lhs.Value<bool>() && rhs.Value<bool>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            BinaryOpType.Or => (lhs.Type, rhs.Type) switch
            {
                (ReturnType.Bool, ReturnType.Bool) =>
                    new Return(ReturnType.Bool, lhs.Value<bool>() || rhs.Value<bool>()),

                _ => throw new InvalidOperationException($"Invalid operators")
            },
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}