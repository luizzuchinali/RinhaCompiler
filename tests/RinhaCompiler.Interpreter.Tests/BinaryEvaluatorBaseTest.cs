namespace RinhaCompiler.Interpreter.Tests;

public abstract class BinaryEvaluatorBaseTest
{
    protected static BinaryOp GetBinaryTerm(Term lhs, Term rhs, BinaryOpType type) =>
        new()
        {
            Kind = Kind.Binary,
            Lhs = lhs,
            Rhs = rhs,
            Op = type,
            // Location = new Location { Start = 0, End = 0, Filename = string.Empty }
        };
}