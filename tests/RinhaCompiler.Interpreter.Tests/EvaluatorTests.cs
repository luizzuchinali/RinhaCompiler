using System.Diagnostics;

namespace RinhaCompiler.Interpreter.Tests;

public class EvaluatorTests
{
    [Fact]
    public void Eval_Print_WritesToConsole()
    {
        var term = new Term
        {
            Kind = Kind.Print,
            Print = new Print
            {
                Kind = Kind.Print,
                Value = new Term { Kind = Kind.Str, Str = "Hello, World!" }
            }
        };

        using var writer = new StringWriter();
        Console.SetOut(writer);

        var result = Evaluator.Eval(term);
        var output = writer.ToString();

        Assert.Contains("Hello, World!", output);
        Assert.Equal(ReturnType.Void, result.Type);
    }

    [Fact]
    public void Eval_Str_ReturnsCorrectValue()
    {
        var term = new Term
        {
            Kind = Kind.Str,
            Str = "Hello, World!"
        };

        var result = Evaluator.Eval(term);

        Assert.Equal(ReturnType.Str, result.Type);
        Assert.Equal("Hello, World!", result.Value<string>());
    }

    [Fact]
    public void Eval_Int_ReturnsIntType()
    {
        var term = new Term
        {
            Kind = Kind.Int,
            Int = 42
        };

        var result = Evaluator.Eval(term);

        Assert.Equal(ReturnType.Int, result.Type);
    }

    [Fact]
    public void Eval_Int_ReturnsCorrectValue()
    {
        var term = new Term
        {
            Kind = Kind.Int,
            Int = 42
        };

        var result = Evaluator.Eval(term);

        Assert.Equal(42, result.Value<int>());
    }

    [Fact]
    public void Eval_Binary_ReturnsCorrectValue()
    {
        var term = new Term
        {
            Kind = Kind.Binary,
            BinaryOp = new BinaryOp
            {
                Kind = Kind.Binary,
                Lhs = new Term { Kind = Kind.Int, Int = 5 },
                Rhs = new Term { Kind = Kind.Int, Int = 3 },
                Op = BinaryOpType.Add
            }
        };

        var result = Evaluator.Eval(term);

        Assert.Equal(ReturnType.Int, result.Type);
        Assert.Equal(8, result.Value<int>());
    }

    [Fact]
    public void Eval_Bool_ReturnsBoolType()
    {
        var term = new Term
        {
            Kind = Kind.Bool,
            Bool = true
        };

        var result = Evaluator.Eval(term);

        Assert.Equal(ReturnType.Bool, result.Type);
    }

    [Fact]
    public void Eval_Bool_ReturnsCorrectValue()
    {
        var term = new Term
        {
            Kind = Kind.Bool,
            Bool = true
        };

        var result = Evaluator.Eval(term);

        Assert.True(result.Value<bool>());
    }
}