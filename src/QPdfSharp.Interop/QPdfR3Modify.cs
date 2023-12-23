namespace QPdfSharp.Interop;

[NativeTypeName("unsigned int")]
internal enum QPdfR3Modify : uint
{
    qpdf_r3m_all = 0,
    qpdf_r3m_annotate,
    qpdf_r3m_form,
    qpdf_r3m_assembly,
    qpdf_r3m_none,
}
