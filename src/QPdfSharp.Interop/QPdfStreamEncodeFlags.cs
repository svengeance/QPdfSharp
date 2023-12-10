namespace QPdf.Interop;

[NativeTypeName("unsigned int")]
public enum QPdfStreamEncodeFlags : uint
{
    qpdf_ef_compress = 1 << 0,
    qpdf_ef_normalize = 1 << 1,
}
