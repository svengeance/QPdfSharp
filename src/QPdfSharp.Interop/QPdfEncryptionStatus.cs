namespace QPdf.Interop;

[NativeTypeName("unsigned int")]
public enum QPdfEncryptionStatus : uint
{
    qpdf_es_encrypted = 1 << 0,
    qpdf_es_password_incorrect = 1 << 1,
}
