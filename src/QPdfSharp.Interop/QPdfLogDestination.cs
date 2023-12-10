namespace QPdf.Interop;

[NativeTypeName("unsigned int")]
public enum QPdfLogDestination : uint
{
    qpdf_log_dest_default = 0,
    qpdf_log_dest_stdout = 1,
    qpdf_log_dest_stderr = 2,
    qpdf_log_dest_discard = 3,
    qpdf_log_dest_custom = 4,
}
