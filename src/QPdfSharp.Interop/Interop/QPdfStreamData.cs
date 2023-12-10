namespace QPdfSharp.Interop;

[NativeTypeName("unsigned int")]
internal enum QPdfStreamData : uint
{
    qpdf_s_uncompress = 0,
    qpdf_s_preserve,
    qpdf_s_compress,
}
