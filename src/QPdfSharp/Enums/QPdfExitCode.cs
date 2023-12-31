namespace QPdfSharp.Enums;

public enum QPdfExitCode : uint
{
    Success = 0,
    Error = 2,
    Warning = 3,
    IsNotEncrypted = 2,
    CorrectPassword = 3,
}
