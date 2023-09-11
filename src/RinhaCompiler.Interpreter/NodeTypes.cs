namespace RinhaCompiler.Interpreter;

public class File
{
    public required string Name { get; set; }
    public required Term Expression { get; set; }
    public required Location Location { get; set; }
}

public class Location
{
    public required uint Start { get; set; }
    public required uint End { get; set; }
    public required string Filename { get; set; }
}

public class Term
{
    public required Kind Kind { get; set; }
    public string? Str { get; set; }
    public int? Int { get; set; }
    public bool? Bool { get; set; }
    public Print? Print { get; set; }
    public BinaryOp? BinaryOp { get; set; }
    public required Location Location { get; set; }
}

public class Print
{
    public required Kind Kind { get; set; }
    public required Term Value { get; set; }
    public required Location Location { get; set; }
}

public class BinaryOp
{
    public required Kind Kind { get; set; }
    public required Term Lhs { get; set; }
    public required Term Rhs { get; set; }
    public required BinaryOpType Op { get; set; }
    public required Location Location { get; set; }
}

public enum BinaryOpType
{
    Add,
    Sub,
    Mul,
    Div,
    Rem,
    Eq,
    Neq,
    Lt,
    Gt,
    Lte,
    Gte,
    And,
    Or
}

public enum Kind
{
    Print,
    Str,
    Int,
    Binary,
    Bool
}

public enum ReturnType
{
    Void,
    Int,
    Str,
    Bool
}