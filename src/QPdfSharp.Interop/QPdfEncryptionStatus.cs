namespace QPdfSharp.Interop;

[NativeTypeName("unsigned int")]
internal enum QPdfEncryptionStatus : uint
{
    qpdf_es_encrypted = 1 << 0,
    qpdf_es_password_incorrect = 1 << 1,
}
