namespace QPdfSharp.Enums;

public enum QPdfErrorCode : uint
{
    qpdf_e_success = 0,
    qpdf_e_internal,
    qpdf_e_system,
    qpdf_e_unsupported,
    qpdf_e_password,
    qpdf_e_damaged_pdf,
    qpdf_e_pages,
    qpdf_e_object,
    qpdf_e_json,
    qpdf_e_linearization,
}
