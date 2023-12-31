namespace QPdfSharp.Enums;

public enum QPdfEncryptionStatus : uint
{
    Encrypted = 1 << 0,
    PasswordIncorrect = 1 << 1,
}
