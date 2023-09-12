namespace RinhaCompiler.Interpreter.Tests;

public class BinaryEvaluatorNegativeTests : BinaryEvaluatorBaseTest
{
    [Fact]
    public void BinaryEval_ArgumentOutOfRangeException()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 5 };
        var rhs = new Term { Kind = Kind.Int, Int = 3 };
        var term = GetBinaryTerm(lhs, rhs, (BinaryOpType)100);

        Assert.Throws<ArgumentOutOfRangeException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Bool, Kind.Int)]
    [InlineData(Kind.Bool, Kind.Str)]
    public void BinaryEval_EvaluateEquality_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Bool = true };
        var rhs = new Term { Kind = rhsKind, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Eq);

        var result = BinaryEvaluator.BinaryEval(term);
        Assert.True(result.Type == ReturnType.Bool);
        Assert.False(result.Value<bool>());
    }

    [Theory]
    [InlineData(Kind.Bool, Kind.Int)]
    [InlineData(Kind.Bool, Kind.Str)]
    public void BinaryEval_EvaluateInequality_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Bool = true };
        var rhs = new Term { Kind = rhsKind, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Neq);

        var result = BinaryEvaluator.BinaryEval(term);
        Assert.True(result.Type == ReturnType.Bool);
        Assert.True(result.Value<bool>());
    }

    [Theory]
    [InlineData(Kind.Bool, Kind.Int)]
    [InlineData(Kind.Bool, Kind.Str)]
    public void BinaryEval_EvaluateLessThan_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Bool = true };
        var rhs = new Term { Kind = rhsKind, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Lt);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Bool, Kind.Int)]
    [InlineData(Kind.Bool, Kind.Str)]
    public void BinaryEval_EvaluateGreaterThan_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Bool = true };
        var rhs = new Term { Kind = rhsKind, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Gt);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Int, Kind.Bool)]
    [InlineData(Kind.Str, Kind.Bool)]
    public void BinaryEval_EvaluateLessThanOrEqual_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Int = 5 };
        var rhs = new Term { Kind = rhsKind, Bool = true };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Lte);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Str, Kind.Bool)]
    [InlineData(Kind.Bool, Kind.Int)]
    public void BinaryEval_EvaluateGreaterThanOrEqual_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Str = "test" };
        var rhs = new Term { Kind = rhsKind, Int = 5 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Gte);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Int, Kind.Str)]
    [InlineData(Kind.Str, Kind.Int)]
    public void BinaryEval_EvaluateLogicalAnd_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Int = 1 };
        var rhs = new Term { Kind = rhsKind, Str = "test" };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.And);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Int, Kind.Str)]
    [InlineData(Kind.Str, Kind.Int)]
    public void BinaryEval_EvaluateLogicalOr_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Int = 1 };
        var rhs = new Term { Kind = rhsKind, Str = "test" };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Or);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Bool, Kind.Int)]
    [InlineData(Kind.Bool, Kind.Str)]
    public void BinaryEval_EvaluateSubtraction_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Bool = true };
        var rhs = new Term { Kind = rhsKind, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Sub);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Bool, Kind.Int)]
    [InlineData(Kind.Bool, Kind.Str)]
    public void BinaryEval_EvaluateRemainder_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Bool = true };
        var rhs = new Term { Kind = rhsKind, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Rem);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Bool, Kind.Int)]
    [InlineData(Kind.Bool, Kind.Str)]
    public void BinaryEval_EvaluateMultiplication_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Bool = true };
        var rhs = new Term { Kind = rhsKind, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Mul);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }

    [Theory]
    [InlineData(Kind.Bool, Kind.Int)]
    [InlineData(Kind.Bool, Kind.Str)]
    public void BinaryEval_EvaluateDivision_InvalidCases(Kind lhsKind, Kind rhsKind)
    {
        var lhs = new Term { Kind = lhsKind, Bool = true };
        var rhs = new Term { Kind = rhsKind, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Div);

        Assert.Throws<InvalidOperationException>(() => BinaryEvaluator.BinaryEval(term));
    }
}