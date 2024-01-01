namespace QPdfSharp.Enums;

public enum QPdfErrorCode : uint
{
    Success = 0,
    Internal,
    System,
    Unsupported,
    Password,
    DamagedPdf,
    Pages,
    Object,
    Json,
    Linearization,
}
