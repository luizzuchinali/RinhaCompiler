namespace RinhaCompiler.Interpreter.Tests;

public class BinaryEvaluatorPositiveTests : BinaryEvaluatorBaseTest
{
    [Fact]
    public void BinaryEval_EvaluateAddition()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 5 };
        var rhs = new Term { Kind = Kind.Int, Int = 3 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Add);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.Equal(8, result.Value<int>());
    }

    [Fact]
    public void BinaryEval_EvaluateAddition_StrReturn()
    {
        var lhs = new Term { Kind = Kind.Str, Str = "121" };
        var rhs = new Term { Kind = Kind.Int, Int = 3 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Add);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Str, result.Type);
        Assert.Equal(lhs.Str + rhs.Int, result.Value<string>());
    }

    [Fact]
    public void BinaryEval_EvaluateSubtraction()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 10 };
        var rhs = new Term { Kind = Kind.Int, Int = 3 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Sub);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.Equal(7, result.Value<int>());
    }

    [Fact]
    public void BinaryEval_EvaluateMultiplication()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 7 };
        var rhs = new Term { Kind = Kind.Int, Int = 4 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Mul);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.Equal(28, result.Value<int>());
    }

    [Fact]
    public void BinaryEval_EvaluateDivision()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 16 };
        var rhs = new Term { Kind = Kind.Int, Int = 4 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Div);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.Equal(4, result.Value<int>());
    }

    [Fact]
    public void BinaryEval_EvaluateRemainder()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 17 };
        var rhs = new Term { Kind = Kind.Int, Int = 5 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Rem);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.Equal(2, result.Value<int>());
    }

    [Fact]
    public void BinaryEval_EvaluateEquality()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 10 };
        var rhs = new Term { Kind = Kind.Int, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Eq);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Bool, result.Type);
        Assert.True(result.Value<bool>());
    }

    [Fact]
    public void BinaryEval_EvaluateInequality()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 5 };
        var rhs = new Term { Kind = Kind.Int, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Neq);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Bool, result.Type);
        Assert.True(result.Value<bool>());
    }

    [Fact]
    public void BinaryEval_EvaluateLessThan()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 5 };
        var rhs = new Term { Kind = Kind.Int, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Lt);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.True(result.Value<bool>());
    }

    [Fact]
    public void BinaryEval_EvaluateGreaterThan()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 10 };
        var rhs = new Term { Kind = Kind.Int, Int = 5 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Gt);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.True(result.Value<bool>());
    }

    [Fact]
    public void BinaryEval_EvaluateLessThanOrEqual()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 5 };
        var rhs = new Term { Kind = Kind.Int, Int = 10 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Lte);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.True(result.Value<bool>());
    }

    [Fact]
    public void BinaryEval_EvaluateGreaterThanOrEqual()
    {
        var lhs = new Term { Kind = Kind.Int, Int = 10 };
        var rhs = new Term { Kind = Kind.Int, Int = 5 };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Gte);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.True(result.Value<bool>());
    }

    [Fact]
    public void BinaryEval_EvaluateLogicalAnd()
    {
        var lhs = new Term { Kind = Kind.Bool, Bool = true };
        var rhs = new Term { Kind = Kind.Bool, Bool = false };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.And);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Bool, result.Type);
        Assert.False(result.Value<bool>());
    }

    [Fact]
    public void BinaryEval_EvaluateLogicalOr()
    {
        var lhs = new Term { Kind = Kind.Bool, Bool = true };
        var rhs = new Term { Kind = Kind.Bool, Bool = false };
        var term = GetBinaryTerm(lhs, rhs, BinaryOpType.Or);

        var result = BinaryEvaluator.BinaryEval(term);

        Assert.Equal(ReturnType.Bool, result.Type);
        Assert.True(result.Value<bool>());
    }
}