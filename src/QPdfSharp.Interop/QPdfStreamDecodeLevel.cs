namespace QPdf.Interop;

[NativeTypeName("unsigned int")]
public enum QPdfStreamDecodeLevel : uint
{
    qpdf_dl_none = 0,
    qpdf_dl_generalized,
    qpdf_dl_specialized,
    qpdf_dl_all,
}
