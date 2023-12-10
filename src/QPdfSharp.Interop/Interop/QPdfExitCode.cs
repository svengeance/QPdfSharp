namespace QPdfSharp.Interop;

[NativeTypeName("unsigned int")]
internal enum QPdfExitCode : uint
{
    qpdf_exit_success = 0,
    qpdf_exit_error = 2,
    qpdf_exit_warning = 3,
    qpdf_exit_is_not_encrypted = 2,
    qpdf_exit_correct_password = 3,
}
