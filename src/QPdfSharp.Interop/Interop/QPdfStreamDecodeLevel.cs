namespace QPdfSharp.Interop;

[NativeTypeName("unsigned int")]
internal enum QPdfStreamDecodeLevel : uint
{
    qpdf_dl_none = 0,
    qpdf_dl_generalized,
    qpdf_dl_specialized,
    qpdf_dl_all,
}
