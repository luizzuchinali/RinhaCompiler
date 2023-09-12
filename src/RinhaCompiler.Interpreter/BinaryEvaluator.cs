using System.Runtime.CompilerServices;

namespace RinhaCompiler.Interpreter;

public class BinaryEvaluator
{
    public static Return BinaryEval(BinaryOp term)
    {
        var lhs = Evaluator.Eval(term.Lhs);
        var rhs = Evaluator.Eval(term.Rhs);

        return term.Op switch
        {
            BinaryOpType.Add => EvaluateAddition(lhs, rhs),
            BinaryOpType.Sub => EvaluateSubtraction(lhs, rhs),
            BinaryOpType.Mul => EvaluateMultiplication(lhs, rhs),
            BinaryOpType.Div => EvaluateDivision(lhs, rhs),
            BinaryOpType.Rem => EvaluateRemainder(lhs, rhs),
            BinaryOpType.Eq => EvaluateEquality(lhs, rhs),
            BinaryOpType.Neq => EvaluateInequality(lhs, rhs),
            BinaryOpType.Lt => EvaluateLessThan(lhs, rhs),
            BinaryOpType.Gt => EvaluateGreaterThan(lhs, rhs),
            BinaryOpType.Lte => EvaluateLessThanOrEqual(lhs, rhs),
            BinaryOpType.Gte => EvaluateGreaterThanOrEqual(lhs, rhs),
            BinaryOpType.And => EvaluateLogicalAnd(lhs, rhs),
            BinaryOpType.Or => EvaluateLogicalOr(lhs, rhs),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateAddition(Return lhs, Return rhs) =>
        (lhs.Type, rhs.Type) switch
        {
            (ReturnType.Int, ReturnType.Int) => new Return(ReturnType.Int, lhs.Value<int>() + rhs.Value<int>()),
            (_, _) => new Return(ReturnType.Str, $"{lhs.Value<object>()}{rhs.Value<object>()}"),
        };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateSubtraction(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Int || rhs.Type != ReturnType.Int)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Int, lhs.Value<int>() - rhs.Value<int>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateMultiplication(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Int || rhs.Type != ReturnType.Int)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Int, lhs.Value<int>() * rhs.Value<int>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateDivision(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Int || rhs.Type != ReturnType.Int)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Int, lhs.Value<int>() / rhs.Value<int>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateRemainder(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Int || rhs.Type != ReturnType.Int)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Int, lhs.Value<int>() % rhs.Value<int>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateEquality(Return lhs, Return rhs) =>
        new Return(ReturnType.Bool, lhs.Value<object>()?.Equals(rhs.Value<object>()));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateInequality(Return lhs, Return rhs) =>
        new Return(ReturnType.Bool, !lhs.Value<object>()?.Equals(rhs.Value<object>()));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateLessThan(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Int || rhs.Type != ReturnType.Int)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Int, lhs.Value<int>() < rhs.Value<int>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateGreaterThan(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Int || rhs.Type != ReturnType.Int)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Int, lhs.Value<int>() > rhs.Value<int>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateLessThanOrEqual(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Int || rhs.Type != ReturnType.Int)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Int, lhs.Value<int>() <= rhs.Value<int>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateGreaterThanOrEqual(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Int || rhs.Type != ReturnType.Int)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Int, lhs.Value<int>() >= rhs.Value<int>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateLogicalAnd(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Bool || rhs.Type != ReturnType.Bool)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Bool, lhs.Value<bool>() && rhs.Value<bool>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Return EvaluateLogicalOr(Return lhs, Return rhs)
    {
        if (lhs.Type != ReturnType.Bool || rhs.Type != ReturnType.Bool)
            throw new InvalidOperationException("Invalid operators");

        return new Return(ReturnType.Bool, lhs.Value<bool>() || rhs.Value<bool>());
    }
}