namespace QPdfSharp.Enums;

public enum QPdfObjectType : uint
{
    Uninitialized,
    Reserved,
    Null,
    Boolean,
    Integer,
    Real,
    String,
    Name,
    Array,
    Dictionary,
    Stream,
    Operator,
    InlineImage,
    Unresolved,
    Destroyed,
}
